using librets;
using Newtonsoft.Json;
using Sabio.Data;
using Sabio.Web.Domain;
using Sabio.Web.Models.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;

namespace Sabio.Web.Services
{
    public class ListingService : BaseService, IListingService
    {
        private const string CrmlsUserName = "DANTUTOLO";
        private const string CrmlsPassword = "4t5vMc^t";
        private const string CrmlsDomain = "https://pt.rets.crmls.org";
        private const string CrmlsLoginRoute = "/contact/rets/login";
        private const string CrmlsLogoutRoute = "/contact/rets/logout";
        private const string CrmlsSearchRoute = "/contact/rets/search";
        //private const string CrmlsDefaultQueryString = "SearchType=Property"
        //    + "&Class=Residential">>
        //    + "&QueryType=DMQL2"
        //    + "&Format=COMPACT"
        //    + "&Select=ListingId,StandardStatus,StreetNumberNumeric,StreetNumber,StreetDirPrefix,StreetName,StreetDirSuffix,StreetSuffixModifier,StreetSuffix,City,StateOrProvince,PostalCode,ListPrice,BedroomsTotal,BathroomsFull,YearBuilt,LivingArea,LotSizeSquareFeet,HighSchoolDistrict"
        //    + "&Query=(City=|ALH,MP,SGAB),(ListPrice=750000-),(PropertySubType=|CONDO,SFR,TWNHS),(StandardStatus=|A),(BathroomsFull=2%2B),(BedroomsTotal=2%2B),(LivingArea=1100%2B)"
        //    + "&Count=1";



        //private static CredentialCache _credentialCache = null;

        private static RetsSession _libretsSession = null;

        // This attempts to use the Librets C++ library from a GitHub Repo
        public bool LibretsLogin()
        {
            _libretsSession = new RetsSession("https://pt.rets.crmls.org/contact/rets/login");

            // Set the flag to ignore SSL Cert Validation
            _libretsSession.SetModeFlags(RetsSession.MODE_NO_SSL_VERIFY);

            // If something goes wrong and you need additional information
            // uncomment the line below to begin logging
            //retsSession.SetHttpLogName("c:\\temp\\rets.log");

            try
            {
                // Pass in the login credential provided by Dan
                bool success = _libretsSession.Login(CrmlsUserName, CrmlsPassword);

                if (success) // If it worked
                {
                    Debug.WriteLine("Successfully logged in!!!");
                    return true;
                }
                else // If it failed
                {
                    Debug.WriteLine("Failed to login...");
                    return false;
                }
            }
            catch (Exception ex) // If something went completly wrong
            {
                Debug.WriteLine(ex.Message, ex);
                return false;
            }
        }

        public void LibretsLogout()
        {
            if (_libretsSession != null)
            {
                _libretsSession.Logout();
            }
        }

        public SearchRequest CreateRequest(string mlsListingId)
        {
            SearchRequest request = null;
            string query = string.Empty;
            if (!String.IsNullOrWhiteSpace(mlsListingId))
            {
                query = "(ListingId=|" + mlsListingId + ")";
                request = _libretsSession.CreateSearchRequest("Property", "Residential", query);
            }
            //acutal data
            return request;
        }

        public List<string> GetByListingId(string mlsListingId)
        {
            List<string> rowData = new List<string>();
            if (_libretsSession == null)
            {
                if (!LibretsLogin())
                {
                    throw new ApplicationException("Librets login failed");
                }
            }
            try
            {
                SearchRequest request = CreateRequest(mlsListingId);
                SearchResultSet result = _libretsSession.Search(request);
                Debug.WriteLine("Record count: " + result.GetCount());
                IEnumerable columns = result.GetColumns();

                while (result.HasNext())
                {
                    foreach (string column in columns)
                    {
                        rowData.Add(column + ":" + result.GetString(column));
                    }
                }
                return (rowData);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        public int InsertListing(ResidentialBaseAddRequest model)
        {
            int id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Listings_Insert", delegate (SqlParameterCollection paramCollection)
            {
                SetListingParams(model, paramCollection);
                SqlParameter l = new SqlParameter("@Id", SqlDbType.Int);
                l.Direction = ParameterDirection.Output;
                paramCollection.Add(l);
            }
            , delegate (SqlParameterCollection param)
            {
                int.TryParse(param["@Id"].Value.ToString(), out id);
            });
            return id;
        }

        public List<ResidentialBase> GetAll()
        {
            List<ResidentialBase> list = new List<ResidentialBase>();
            DataProvider.ExecuteCmd(GetConnection, "dbo.Listings_SelectAll"
               , inputParamMapper: null
               , map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
               {
                   ResidentialBase l = new Domain.ResidentialBase();

                   int startingIndex = 1;

                   startingIndex = GetListingDomainFields(reader, l, startingIndex);

                   list.Add((ResidentialBase)l);
               }
               );
            return list;
        }

        public List<int> UpsertListingsFromCsv(List<ResidentialDetailsAddRequest> modelList)
        {
            ResidentialDetailsAddRequest target;
            List<int> idList = new List<int>();
            for (int i = 0; i < modelList.Count; i++)
            {
                int id = 0;
                DataProvider.ExecuteNonQuery(GetConnection, "dbo.Listings_UpsertFromCsv"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    target = modelList[i];
                    ParamMapper(target, paramCollection);

                    SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    p.Direction = System.Data.ParameterDirection.Output;
                    paramCollection.Add(p);
                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out id);
                    idList.Add(id);
                });
            }
            return idList;
        }

        public List<MetaDataLookUpValues> GetOptions()
        {
            List<MetaDataLookUpValues> options = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.MetaDataLookup_GetOptions"
                , inputParamMapper: null
                , map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
                      {
                          if (options == null)
                          {
                              options = new List<MetaDataLookUpValues>();
                          }
                          int index = 0;
                          MetaDataLookUpValues option = new MetaDataLookUpValues();
                          option.LookUpValue = reader.GetSafeString(index++);
                          option.ShortValue = reader.GetSafeString(index++);
                          option.LongValue = reader.GetSafeString(index++);
                          options.Add(option);
                      });
            return options;
        }

        private static int GetListingDomainFields(IDataReader reader, ResidentialBase l, int startingIndex)
        {

            l.MlsListingId = reader.GetSafeString(startingIndex++);
            l.ListingKeyNumeric = reader.GetSafeInt32(startingIndex++);
            l.AddressLine1 = reader.GetSafeString(startingIndex++);
            l.AddressLine2 = reader.GetSafeString(startingIndex++);
            l.City = reader.GetSafeString(startingIndex++);
            l.StateOrProvince = reader.GetSafeString(startingIndex++);
            l.PostalCode = reader.GetSafeString(startingIndex++);
            l.BedroomsTotal = reader.GetSafeInt32(startingIndex++);
            l.BathroomsFull = reader.GetSafeInt32(startingIndex++);
            l.LivingArea = reader.GetSafeInt32(startingIndex++);
            l.LotSizeSquareFeet = reader.GetSafeInt32(startingIndex++);
            l.HighSchoolDistrict = reader.GetSafeString(startingIndex++);
            l.YearBuilt = reader.GetSafeInt32(startingIndex++);
            l.ListPrice = reader.GetSafeInt32(startingIndex++);
            l.MainMediaURL = reader.GetSafeString(startingIndex++);
            l.HasOpenHouse = reader.GetSafeBool(startingIndex++);
            l.StandardStatus = reader.GetSafeString(startingIndex++);
            return startingIndex;
        }
        private static void SetListingParams(ResidentialBaseAddRequest model, SqlParameterCollection paramCollection)
        {

            paramCollection.AddWithValue("@MlsListingId", model.MlsListingId);
            paramCollection.AddWithValue("@AddressLine1", model.AddressLine1);
            paramCollection.AddWithValue("@AddressLine2", model.AddressLine2);
            paramCollection.AddWithValue("@City", model.City);
            paramCollection.AddWithValue("@StateOrProvince", model.StateOrProvince);
            paramCollection.AddWithValue("@PostalCode", model.PostalCode);
            paramCollection.AddWithValue("@ListPrice", model.ListPrice);
            paramCollection.AddWithValue("@BedroomsTotal", model.BedroomsTotal);
            paramCollection.AddWithValue("@BathroomsFull", model.BathroomsFull);
            paramCollection.AddWithValue("@LivingArea", model.LivingArea);
            paramCollection.AddWithValue("@LotSizeSquareFeet", model.LotSizeSquareFeet);
            paramCollection.AddWithValue("@ListingKeyNumeric", model.ListingKeyNumeric);
            paramCollection.AddWithValue("@StandardStatus", model.StandardStatus);
            paramCollection.AddWithValue("@YearBuilt", model.YearBuilt);
            paramCollection.AddWithValue("@HighSchoolDistrict", model.HighSchoolDistrict);
            paramCollection.AddWithValue("@MainMediaURL", model.MainMediaURL);
            paramCollection.AddWithValue("@HasOpenHouse", model.HasOpenHouse);
        }
        private static void ParamMapper(ResidentialDetailsAddRequest result, SqlParameterCollection paramCollection)
        {
            //Base
            //paramCollection.AddWithValue("@ListingKeyNumeric", result.ListingKeyNumeric);
            paramCollection.AddWithValue("@StandardStatus", result.StandardStatus);
            paramCollection.AddWithValue("@StreetNumberNumeric", result.StreetNumberNumeric);
            paramCollection.AddWithValue("@StreetNumber", result.StreetNumber);
            paramCollection.AddWithValue("@StreetDirPrefix", result.StreetDirPrefix);
            paramCollection.AddWithValue("@StreetName", result.StreetName);
            paramCollection.AddWithValue("@StreetDirSuffix", result.StreetDirSuffix);
            paramCollection.AddWithValue("@StreetSuffixModifier", result.StreetSuffixModifier);
            paramCollection.AddWithValue("@StreetSuffix", result.StreetSuffix);
            paramCollection.AddWithValue("@StateOrProvince", result.StateOrProvince);
            paramCollection.AddWithValue("@YearBuilt", result.YearBuilt);
            paramCollection.AddWithValue("@HighSchoolDistrict", result.HighSchoolDistrict);
            paramCollection.AddWithValue("@MainMediaURL", result.MainMediaURL);
            paramCollection.AddWithValue("@HasOpenHouse", result.HasOpenHouse);
            paramCollection.AddWithValue("@DisplayOrder", result.DisplayOrder);
            paramCollection.AddWithValue("@MlsListingId", result.MlsListingId);
            paramCollection.AddWithValue("@FavoritesId", result.FavoritesId);
            paramCollection.AddWithValue("@StreetAddress", result.StreetAddress);
            paramCollection.AddWithValue("@AddressLine1", result.AddressLine1);
            paramCollection.AddWithValue("@AddressLine2", result.AddressLine2);
            paramCollection.AddWithValue("@City", result.City);
            paramCollection.AddWithValue("@PostalCode", result.PostalCode);
            paramCollection.AddWithValue("@ListPrice", result.ListPrice);
            paramCollection.AddWithValue("@BedroomsTotal", result.BedroomsTotal);
            paramCollection.AddWithValue("@BathroomsFull", result.BathroomsFull);
            paramCollection.AddWithValue("@LivingArea", result.LivingArea);
            paramCollection.AddWithValue("@LotSizeSquareFeet", result.LotSizeSquareFeet);


            //Details
            paramCollection.AddWithValue("@_433aCertifiedYN", result._433aCertifiedYN);
            paramCollection.AddWithValue("@AccessibilityFeatures", result.AccessibilityFeatures);
            paramCollection.AddWithValue("@AdditionalParcelsDescription", result.AdditionalParcelsDescription);
            paramCollection.AddWithValue("@AdditionalParcelsYN", result.AdditionalParcelsYN);
            paramCollection.AddWithValue("@AdNumber", result.AdNumber);
            paramCollection.AddWithValue("@Appliances", result.Appliances);
            paramCollection.AddWithValue("@AppliancesYN", result.AppliancesYN);
            paramCollection.AddWithValue("@ArchitecturalStyle", result.ArchitecturalStyle);
            paramCollection.AddWithValue("@Assessments", result.Assessments);
            paramCollection.AddWithValue("@AssessmentsYN", result.AssessmentsYN);
            paramCollection.AddWithValue("@AssociationAmenities", result.AssociationAmenities);
            paramCollection.AddWithValue("@AssociationFee", result.AssociationFee);
            paramCollection.AddWithValue("@AssociationFee2", result.AssociationFee2);
            paramCollection.AddWithValue("@AssociationFee2Frequency", result.AssociationFee2Frequency);
            paramCollection.AddWithValue("@AssociationFeeFrequency", result.AssociationFeeFrequency);
            paramCollection.AddWithValue("@AssociationYN", result.AssociationYN);
            paramCollection.AddWithValue("@AttachedGarageYN", result.AttachedGarageYN);
            paramCollection.AddWithValue("@BathroomsFullAndThreeQuarter", result.BathroomsFullAndThreeQuarter);
            paramCollection.AddWithValue("@BathroomsHalf", result.BathroomsHalf);
            paramCollection.AddWithValue("@BathroomsOneQuarter", result.BathroomsOneQuarter);
            paramCollection.AddWithValue("@BathroomsThreeQuarter", result.BathroomsThreeQuarter);
            paramCollection.AddWithValue("@BathroomsTotalInteger", result.BathroomsTotalInteger);
            paramCollection.AddWithValue("@BelowGradeFinishedArea", result.BelowGradeFinishedArea);
            paramCollection.AddWithValue("@BelowGradeFinishedAreaUnits", result.BelowGradeFinishedAreaUnits);
            paramCollection.AddWithValue("@BuilderModel", result.BuilderModel);
            paramCollection.AddWithValue("@BuilderName", result.BuilderName);
            paramCollection.AddWithValue("@BuyerAgentAOR", result.BuyerAgentAOR);
            paramCollection.AddWithValue("@BuyerAgentBrokerKeyNumeric", result.BuyerAgentBrokerKeyNumeric);
            paramCollection.AddWithValue("@BuyerAgentBrokerMlsId", result.BuyerAgentBrokerMlsId);
            paramCollection.AddWithValue("@BuyerAgentFirstName", result.BuyerAgentFirstName);
            paramCollection.AddWithValue("@BuyerAgentKeyNumeric", result.BuyerAgentKeyNumeric);
            paramCollection.AddWithValue("@BuyerAgentLastName", result.BuyerAgentLastName);
            paramCollection.AddWithValue("@BuyerAgentMainOfficeKeyNumeric", result.BuyerAgentMainOfficeKeyNumeric);
            paramCollection.AddWithValue("@BuyerAgentMainOfficeMlsId", result.BuyerAgentMainOfficeMlsId);
            paramCollection.AddWithValue("@BuyerAgentMlsId", result.BuyerAgentMlsId);
            paramCollection.AddWithValue("@BuyerAgentStateLicense", result.BuyerAgentStateLicense);
            paramCollection.AddWithValue("@BuyerOfficeAOR", result.BuyerOfficeAOR);
            paramCollection.AddWithValue("@BuyerOfficeKeyNumeric", result.BuyerOfficeKeyNumeric);
            paramCollection.AddWithValue("@BuyerOfficeMlsId", result.BuyerOfficeMlsId);
            paramCollection.AddWithValue("@BuyerOfficeName", result.BuyerOfficeName);
            paramCollection.AddWithValue("@BuyerOfficeStateLicense", result.BuyerOfficeStateLicense);
            paramCollection.AddWithValue("@CarportSpaces", result.CarportSpaces);
            paramCollection.AddWithValue("@CloseDate", result.CloseDate);
            paramCollection.AddWithValue("@ClosePrice", result.ClosePrice);
            paramCollection.AddWithValue("@CoBuyerAgentAOR", result.CoBuyerAgentAOR);
            paramCollection.AddWithValue("@CoBuyerAgentBrokerKeyNumeric", result.CoBuyerAgentBrokerKeyNumeric);
            paramCollection.AddWithValue("@CoBuyerAgentBrokerMlsId", result.CoBuyerAgentBrokerMlsId);
            paramCollection.AddWithValue("@CoBuyerAgentFirstName", result.CoBuyerAgentFirstName);
            paramCollection.AddWithValue("@CoBuyerAgentKeyNumeric", result.CoBuyerAgentKeyNumeric);
            paramCollection.AddWithValue("@CoBuyerAgentLastName", result.CoBuyerAgentLastName);
            paramCollection.AddWithValue("@CoBuyerAgentMainOfficeKeyNumeric", result.CoBuyerAgentMainOfficeKeyNumeric);
            paramCollection.AddWithValue("@CoBuyerAgentMlsId", result.CoBuyerAgentMlsId);
            paramCollection.AddWithValue("@CoBuyerAgentStateLicense", result.CoBuyerAgentStateLicense);
            paramCollection.AddWithValue("@CoBuyerOfficeAOR", result.CoBuyerOfficeAOR);
            paramCollection.AddWithValue("@CoBuyerOfficeKeyNumeric", result.CoBuyerOfficeKeyNumeric);
            paramCollection.AddWithValue("@CoBuyerOfficeMlsId", result.CoBuyerOfficeMlsId);
            paramCollection.AddWithValue("@CoBuyerOfficeName", result.CoBuyerOfficeName);
            paramCollection.AddWithValue("@CoBuyerOfficeStateLicense", result.CoBuyerOfficeStateLicense);
            paramCollection.AddWithValue("@CoListAgentAOR", result.CoListAgentAOR);
            paramCollection.AddWithValue("@CoListAgentFirstName", result.CoListAgentFirstName);
            paramCollection.AddWithValue("@CoListAgentKeyNumeric", result.CoListAgentKeyNumeric);
            paramCollection.AddWithValue("@CoListAgentLastName", result.CoListAgentLastName);
            paramCollection.AddWithValue("@CoListAgentMlsId", result.CoListAgentMlsId);
            paramCollection.AddWithValue("@CoListAgentStateLicense", result.CoListAgentStateLicense);
            paramCollection.AddWithValue("@CoListOfficeAOR", result.CoListOfficeAOR);
            paramCollection.AddWithValue("@CoListOfficeFax", result.CoListOfficeFax);
            paramCollection.AddWithValue("@CoListOfficeKeyNumeric", result.CoListOfficeKeyNumeric);
            paramCollection.AddWithValue("@CoListOfficeMlsId", result.CoListOfficeMlsId);
            paramCollection.AddWithValue("@CoListOfficeName", result.CoListOfficeName);
            paramCollection.AddWithValue("@CoListOfficePhone", result.CoListOfficePhone);
            paramCollection.AddWithValue("@CoListOfficeStateLicense", result.CoListOfficeStateLicense);
            paramCollection.AddWithValue("@CommonWalls", result.CommonWalls);
            paramCollection.AddWithValue("@CommunityFeatures", result.CommunityFeatures);
            paramCollection.AddWithValue("@ConstructionMaterials", result.ConstructionMaterials);
            paramCollection.AddWithValue("@Cooling", result.Cooling);
            paramCollection.AddWithValue("@CoolingYN", result.CoolingYN);
            paramCollection.AddWithValue("@Country", result.Country);
            paramCollection.AddWithValue("@CountyOrParish", result.CountyOrParish);
            paramCollection.AddWithValue("@CumulativeDaysOnMarket", result.CumulativeDaysOnMarket);
            paramCollection.AddWithValue("@DaysOnMarket", result.DaysOnMarket);
            paramCollection.AddWithValue("@DeletedYN", result.DeletedYN);
            paramCollection.AddWithValue("@DirectionFaces", result.DirectionFaces);
            paramCollection.AddWithValue("@Directions", result.Directions);
            paramCollection.AddWithValue("@DocumentNumber", result.DocumentNumber);
            paramCollection.AddWithValue("@DOH1", result.DOH1);
            paramCollection.AddWithValue("@DOH2", result.DOH2);
            paramCollection.AddWithValue("@DOH3", result.DOH3);
            paramCollection.AddWithValue("@DoorFeatures", result.DoorFeatures);
            paramCollection.AddWithValue("@EatingArea", result.EatingArea);
            paramCollection.AddWithValue("@ElementarySchool", result.ElementarySchool2);
            paramCollection.AddWithValue("@ElementarySchool2", result.ElementarySchool2);
            paramCollection.AddWithValue("@ElementarySchoolOther", result.ElementarySchoolOther);
            paramCollection.AddWithValue("@Elevation", result.Elevation);
            paramCollection.AddWithValue("@EntryLevel", result.EntryLevel);
            paramCollection.AddWithValue("@EntryLocation", result.EntryLocation);
            paramCollection.AddWithValue("@Exclusions", result.Exclusions);
            paramCollection.AddWithValue("@ExteriorFeatures", result.ExteriorFeatures);
            paramCollection.AddWithValue("@FenceYN", result.FenceYN);
            paramCollection.AddWithValue("@Fencing", result.Fencing);
            paramCollection.AddWithValue("@FireplaceFeatures", result.FireplaceFeatures);
            paramCollection.AddWithValue("@FireplaceYN", result.FireplaceYN);
            paramCollection.AddWithValue("@Flooring", result.Flooring);
            paramCollection.AddWithValue("@FoundationDetails", result.FoundationDetails);
            paramCollection.AddWithValue("@GarageSpaces", result.GarageSpaces);
            paramCollection.AddWithValue("@GreenEnergyEfficient", result.GreenEnergyEfficient);
            paramCollection.AddWithValue("@GreenEnergyGeneration", result.GreenEnergyGeneration);
            paramCollection.AddWithValue("@GreenIndoorAirQuality", result.GreenIndoorAirQuality);
            paramCollection.AddWithValue("@GreenLocation", result.GreenLocation);
            paramCollection.AddWithValue("@GreenSustainability", result.GreenSustainability);
            paramCollection.AddWithValue("@GreenWaterConservation", result.GreenWaterConservation);
            paramCollection.AddWithValue("@Heating", result.Heating);
            paramCollection.AddWithValue("@HeatingYN", result.HeatingYN);
            paramCollection.AddWithValue("@HighSchool", result.HighSchool);
            paramCollection.AddWithValue("@HighSchool2", result.HighSchool2);
            paramCollection.AddWithValue("@Inclusions", result.Inclusions);
            paramCollection.AddWithValue("@InteriorFeatures", result.InteriorFeatures);
            paramCollection.AddWithValue("@InternetAddressDisplayYN", result.InternetAddressDisplayYN);
            paramCollection.AddWithValue("@InternetEntireListingDisplayYN", result.InternetEntireListingDisplayYN);
            paramCollection.AddWithValue("@LandLeaseAmount", result.LandLeaseAmount);
            paramCollection.AddWithValue("@LandLeaseAmountFrequency", result.LandLeaseAmountFrequency);
            paramCollection.AddWithValue("@LandLeaseYN", result.LandLeaseYN);
            paramCollection.AddWithValue("@LaundryFeatures", result.LaundryFeatures);
            paramCollection.AddWithValue("@LaundryYN", result.LaundryYN);
            paramCollection.AddWithValue("@LeaseConsideredYN", result.LeaseConsideredYN);
            paramCollection.AddWithValue("@Levels", result.Levels);
            paramCollection.AddWithValue("@License1", result.License1);
            paramCollection.AddWithValue("@License2", result.License2);
            paramCollection.AddWithValue("@License3", result.License3);
            paramCollection.AddWithValue("@ListAgentAOR", result.ListAgentAOR);
            paramCollection.AddWithValue("@ListAgentFirstName", result.ListAgentFirstName);
            paramCollection.AddWithValue("@ListAgentKeyNumeric", result.ListAgentKeyNumeric);
            paramCollection.AddWithValue("@ListAgentLastName", result.ListAgentLastName);
            paramCollection.AddWithValue("@ListAgentMlsId", result.ListAgentMlsId);
            paramCollection.AddWithValue("@ListAgentStateLicense", result.ListAgentStateLicense);
            paramCollection.AddWithValue("@ListingContractDate", result.ListingContractDate);
            paramCollection.AddWithValue("@ListOfficeKeyNumeric", result.ListOfficeKeyNumeric);
            paramCollection.AddWithValue("@ListOfficeMlsId", result.ListOfficeMlsId);
            paramCollection.AddWithValue("@ListOfficeName", result.ListOfficeName);
            paramCollection.AddWithValue("@ListOfficeStateLicense", result.ListOfficeStateLicense);
            paramCollection.AddWithValue("@ListPriceLow", result.ListPriceLow);
            paramCollection.AddWithValue("@LivingAreaSource", result.LivingAreaSource);
            paramCollection.AddWithValue("@LivingAreaUnits", result.LivingAreaUnits);
            paramCollection.AddWithValue("@LockBoxType", result.LockBoxType);
            paramCollection.AddWithValue("@LockBoxVersion", result.LockBoxVersion);
            paramCollection.AddWithValue("@LotDimensionsSource", result.LotDimensionsSource);
            paramCollection.AddWithValue("@LotFeatures", result.LotFeatures);
            paramCollection.AddWithValue("@LotSizeAcres", result.LotSizeAcres);
            paramCollection.AddWithValue("@LotSizeArea", result.LotSizeArea);
            paramCollection.AddWithValue("@LotSizeDimensions", result.LotSizeDimensions);
            paramCollection.AddWithValue("@LotSizeSource", result.LotSizeSource);
            paramCollection.AddWithValue("@LotSizeUnits", result.LotSizeUnits);
            paramCollection.AddWithValue("@MainLevelBathrooms", result.MainLevelBathrooms);
            paramCollection.AddWithValue("@MainLevelBedrooms", result.MainLevelBedrooms);
            paramCollection.AddWithValue("@MajorChangeType", result.MajorChangeType);
            paramCollection.AddWithValue("@Make", result.Make);
            paramCollection.AddWithValue("@MiddleOrJuniorSchool", result.MiddleOrJuniorSchool2);
            paramCollection.AddWithValue("@MiddleOrJuniorSchool2", result.MiddleOrJuniorSchool2);
            paramCollection.AddWithValue("@MiddleOrJuniorSchoolOther", result.MiddleOrJuniorSchoolOther);
            paramCollection.AddWithValue("@MLSAreaMajor", result.MLSAreaMajor);
            paramCollection.AddWithValue("@ModificationTimestamp", result.ModificationTimestamp);
            paramCollection.AddWithValue("@NumberOfUnitsInCommunity", result.NumberOfUnitsInCommunity);
            paramCollection.AddWithValue("@NumberRemotes", result.NumberRemotes);
            paramCollection.AddWithValue("@OffMarketTimestamp", result.OffMarketTimestamp);
            paramCollection.AddWithValue("@OnMarketTimestamp", result.OnMarketTimestamp);
            paramCollection.AddWithValue("@OriginalEntryTimestamp", result.OriginalEntryTimestamp);
            paramCollection.AddWithValue("@OriginalListPrice", result.OriginalListPrice);
            paramCollection.AddWithValue("@OriginatingSystemID", result.OriginatingSystemID);
            paramCollection.AddWithValue("@OriginatingSystemKey", result.OriginatingSystemKey);
            paramCollection.AddWithValue("@OriginatingSystemModificationTimestamp", result.OriginatingSystemModificationTimestamp);
            paramCollection.AddWithValue("@OtherStructures", result.OtherStructures);
            paramCollection.AddWithValue("@ParcelNumber", result.ParcelNumber);
            paramCollection.AddWithValue("@ParkingFeatures", result.ParkingFeatures);
            paramCollection.AddWithValue("@ParkingTotal", result.ParkingTotal);
            paramCollection.AddWithValue("@ParkingYN", result.ParkingYN);
            paramCollection.AddWithValue("@PatioAndPorchFeatures", result.PatioAndPorchFeatures);
            paramCollection.AddWithValue("@PatioYN", result.PatioYN);
            paramCollection.AddWithValue("@PhotosChangeTimestamp", result.PhotosChangeTimestamp);
            paramCollection.AddWithValue("@PhotosCount", result.PhotosCount);
            paramCollection.AddWithValue("@Points", result.Points);
            paramCollection.AddWithValue("@PoolFeatures", result.PoolFeatures);
            paramCollection.AddWithValue("@PoolPrivateYN", result.PoolPrivateYN);
            paramCollection.AddWithValue("@PostalCodePlus4", result.PostalCodePlus4);
            paramCollection.AddWithValue("@PreviousListPrice", result.PreviousListPrice);
            paramCollection.AddWithValue("@PreviousStandardStatus", result.PreviousStandardStatus);
            paramCollection.AddWithValue("@PricePerSquareFoot", result.PricePerSquareFoot);
            paramCollection.AddWithValue("@PropertyAttachedYN", result.PropertyAttachedYN);
            paramCollection.AddWithValue("@PropertyCondition", result.PropertyCondition);
            paramCollection.AddWithValue("@PropertySubType", result.PropertySubType);
            paramCollection.AddWithValue("@PublicRemarks", result.PublicRemarks);
            paramCollection.AddWithValue("@PurchaseContractDate", result.PurchaseContractDate);
            paramCollection.AddWithValue("@RoadFrontageType", result.RoadFrontageType);
            paramCollection.AddWithValue("@RoadSurfaceType", result.RoadSurfaceType);
            paramCollection.AddWithValue("@Roof", result.Roof);
            paramCollection.AddWithValue("@RoomType", result.RoomType);
            paramCollection.AddWithValue("@RVParkingDimensions", result.RVParkingDimensions);
            paramCollection.AddWithValue("@SecurityFeatures", result.SecurityFeatures);
            paramCollection.AddWithValue("@SeniorCommunityYN", result.SeniorCommunityYN);
            paramCollection.AddWithValue("@SerialU", result.SerialU);
            paramCollection.AddWithValue("@SerialX", result.SerialX);
            paramCollection.AddWithValue("@SerialXX", result.SerialXX);
            paramCollection.AddWithValue("@Sewer", result.Sewer);
            paramCollection.AddWithValue("@SpaFeatures", result.SpaFeatures);
            paramCollection.AddWithValue("@SpaYN", result.SpaYN);
            paramCollection.AddWithValue("@SpecialListingConditions", result.SpecialListingConditions);
            paramCollection.AddWithValue("@SprinklersYN", result.SprinklersYN);
            paramCollection.AddWithValue("@StatusChangeTimestamp", result.StatusChangeTimestamp);
            paramCollection.AddWithValue("@StoriesTotal", result.StoriesTotal);
            paramCollection.AddWithValue("@SubdivisionName", result.SubdivisionName);
            paramCollection.AddWithValue("@SubdivisionNameOther", result.SubdivisionNameOther);
            paramCollection.AddWithValue("@TaxLot", result.TaxLot);
            paramCollection.AddWithValue("@TaxModel", result.TaxModel);
            paramCollection.AddWithValue("@TaxTract", result.TaxTract);
            paramCollection.AddWithValue("@TaxTractNumber", result.TaxTractNumber);
            paramCollection.AddWithValue("@TractSubAreaCode", result.TractSubAreaCode);
            paramCollection.AddWithValue("@UncoveredSpaces", result.UncoveredSpaces);
            paramCollection.AddWithValue("@UnitNumber", result.UnitNumber);
            paramCollection.AddWithValue("@Utilities", result.Utilities);
            paramCollection.AddWithValue("@MlsView", result.View);
            paramCollection.AddWithValue("@ViewYN", result.ViewYN);
            paramCollection.AddWithValue("@VirtualTourURLBranded", result.VirtualTourURLBranded);
            paramCollection.AddWithValue("@VirtualTourURLUnbranded", result.VirtualTourURLUnbranded);
            paramCollection.AddWithValue("@VirtualTourURLUnbranded2", result.VirtualTourURLUnbranded2);
            paramCollection.AddWithValue("@WalkScore", result.WalkScore);
            paramCollection.AddWithValue("@WaterfrontFeatures", result.WaterfrontFeatures);
            paramCollection.AddWithValue("@WaterSource", result.WaterSource);
            paramCollection.AddWithValue("@WellDepth", result.WellDepth);
            paramCollection.AddWithValue("@WellGallonsPerMinute", result.WellGallonsPerMinute);
            paramCollection.AddWithValue("@WellPumpHorsepower", result.WellPumpHorsepower);
            paramCollection.AddWithValue("@WellReportYN", result.WellReportYN);
            paramCollection.AddWithValue("@WindowFeatures", result.WindowFeatures);
            paramCollection.AddWithValue("@YearBuiltSource", result.YearBuiltSource);
            paramCollection.AddWithValue("@Zoning", result.Zoning);

        }

        public List<AgentListingAndMedia> SelectByMlsId(AgentListingAndMediaRequest model)
        {
            List<AgentListingAndMedia> list = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Listings_SelectByMlsId", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@ListAgentMlsId", model.ListAgentMlsId);
                paramCollection.AddWithValue("@CoListAgentMlsId", model.CoListAgentMlsId);
                paramCollection.AddWithValue("@StandardStatus", model.StandardStatus);
            }, map: delegate (IDataReader reader, short set)
            {
                AgentListingAndMedia listing = new AgentListingAndMedia();
                listing = MapAgentListingAndMedia(reader);

                if (list == null)
                {
                    list = new List<AgentListingAndMedia>();
                }
                list.Add(listing);
            }

            );
            return list;
        }

        public List<AgentListingAndMedia> GetByOfficeMlsId (OfficeListAndMediaRequest model)
        {
            List<AgentListingAndMedia> list = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Listings_GetByOfficeMlsId", inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@ListOfficeMlsId", model.ListOfficeMlsId);
                paramCollection.AddWithValue("@StandardStatus", model.StandardStatus);
            }, map: delegate (IDataReader reader, short set)
            {
                AgentListingAndMedia listing = new AgentListingAndMedia();
                listing = MapAgentListingAndMedia(reader);

                if (list == null)
                {
                    list = new List<AgentListingAndMedia>();
                }
                list.Add(listing);
            }

            );
            return list;
        }

        public static AgentListingAndMedia MapAgentListingAndMedia(IDataReader reader)
        {
            int index = 0;
            AgentListingAndMedia listing = new AgentListingAndMedia();
            listing.Id = reader.GetSafeInt32(index++);
            listing.ListingKeyNumeric = reader.GetSafeInt32(index++);
            listing.StreetAddress = reader.GetSafeString(index++);
            listing.City = reader.GetSafeString(index++);
            listing.PostalCode = reader.GetSafeString(index++);
            listing.ListPrice = reader.GetSafeInt32(index++);
            listing.BedroomsTotal = reader.GetSafeInt32(index++);
            listing.BathroomsFull = reader.GetSafeInt32(index++);
            listing.LivingArea = reader.GetSafeInt32(index++);
            listing.LotSizeSquareFeet = reader.GetSafeDecimal(index++);
            listing.MediaUrl = reader.GetSafeString(index++);
            listing.MediaUrl = listing.MediaUrl.Insert(4, "s");
            listing.MediaType = reader.GetSafeString(index++);
            return listing;
        }
    }
}



//GetByListingId is formated based on this
//public static string LibretsSearch(string query)//id
//{
//    List<List<string>> resultArrays = new List<List<string>>();
//    if (_libretsSession == null)
//    {
//        if (!LibretsLogin())
//        {
//            throw new ApplicationException("Librets login failed");
//        }
//    }
//    try
//    {
//        SearchRequest req = CreateSearchRequest(query);
//        SearchResultSet results = _libretsSession.Search(req);

//        Debug.WriteLine("Record count: " + results.GetCount());
//        IEnumerable columns = results.GetColumns();
//        while (results.HasNext())
//        {
//            List<string> rowData = new List<string>();
//            foreach (string column in columns)
//            {
//                rowData.Add(results.GetString(column));
//            }
//            resultArrays.Add(rowData);
//        }
//        return JsonConvert.SerializeObject(resultArrays);
//    }
//    catch (Exception ex)
//    {
//        throw new ApplicationException(ex.Message, ex);
//    }
//}




//public static SearchRequest CreateSearchRequest(string query)
//{
//    if (!String.IsNullOrWhiteSpace(query))
//    {
//        //query = "(City=|ALH,MP,SGAB),(ListPrice=750000-)";
//        query = "(City=|ALH),(ListPrice=750000-)";
//    }
// public SearchRequest CreateSearchRequest(string searchType, string searchClass, string query);
//    var request = _libretsSession.CreateSearchRequest("Property",
//        "Residential",
//        query);
//    request.SetSelect(String.Join(",", CrmlsSelectColumns));

//    return request;