
        private const string CrmlsUserName = "UserName";
        private const string CrmlsPassword = "PassWord";
        private const string CrmlsDomain = "https://pt.rets.crmls.org";
        private const string CrmlsLoginRoute = "/contact/rets/login";
        private const string CrmlsLogoutRoute = "/contact/rets/logout";
        private const string CrmlsSearchRoute = "/contact/rets/search";
        private const string CrmlsDefaultQueryString = "SearchType=Property"
            + "&Class=Residential"
            + "&QueryType=DMQL2"
            + "&Format=COMPACT"
            + "&Select=ListingId,StandardStatus,StreetNumberNumeric,StreetNumber,StreetDirPrefix,StreetName,StreetDirSuffix,StreetSuffixModifier,StreetSuffix,City,StateOrProvince,PostalCode,ListPrice,BedroomsTotal,BathroomsFull,YearBuilt,LivingArea,LotSizeSquareFeet,HighSchoolDistrict"
            + "&Query=(City=|ALH,MP,SGAB),(ListPrice=750000-),(PropertySubType=|CONDO,SFR,TWNHS),(StandardStatus=|A),(BathroomsFull=2%2B),(BedroomsTotal=2%2B),(LivingArea=1100%2B)"
            + "&Count=1";

        public static string[] CrmlsSelectColumns = {
            "ListingId","ListingKeyNumeric","StandardStatus","StreetNumberNumeric","StreetNumber","StreetDirPrefix",
            "StreetName","StreetDirSuffix","StreetSuffixModifier","StreetSuffix","City",
            "StateOrProvince","PostalCode","ListPrice","BedroomsTotal","BathroomsFull",
            "YearBuilt","LivingArea","LotSizeSquareFeet","HighSchoolDistrict" };

        public static string[] CrmlsSelectColumnsDetails = {
            //Base
            "ListingId","ListingKeyNumeric","StandardStatus","StreetNumberNumeric","StreetNumber","StreetDirPrefix",
            "StreetName","StreetDirSuffix","StreetSuffixModifier","StreetSuffix","City",
            "StateOrProvince","PostalCode","ListPrice","BedroomsTotal","BathroomsFull",
            "YearBuilt","LivingArea","LotSizeSquareFeet","HighSchoolDistrict",
            //Details
            "433aCertifiedYN","AccessibilityFeatures","AdditionalParcelsDescription","AdditionalParcelsYN","AdNumber","Appliances","AppliancesYN","ArchitecturalStyle","Assessments",
            "AssessmentsYN","AssociationAmenities","AssociationFee","AssociationFee2","AssociationFee2Frequency","AssociationFeeFrequency","AssociationYN","AttachedGarageYN","BathroomsFullAndThreeQuarter",
            "BathroomsHalf","BathroomsOneQuarter","BathroomsThreeQuarter","BathroomsTotalInteger","BelowGradeFinishedArea","BelowGradeFinishedAreaUnits","BuilderModel","BuilderName","BuyerAgentAOR",
            "BuyerAgentBrokerKeyNumeric","BuyerAgentBrokerMlsId","BuyerAgentFirstName","BuyerAgentKeyNumeric","BuyerAgentLastName","BuyerAgentMainOfficeKeyNumeric","BuyerAgentMainOfficeMlsId",
            "BuyerAgentMlsId","BuyerAgentStateLicense","BuyerOfficeAOR","BuyerOfficeKeyNumeric","BuyerOfficeMlsId","BuyerOfficeName","BuyerOfficeStateLicense","CarportSpaces","CloseDate","ClosePrice",
            "CoBuyerAgentAOR","CoBuyerAgentBrokerKeyNumeric","CoBuyerAgentBrokerMlsId","CoBuyerAgentFirstName","CoBuyerAgentKeyNumeric","CoBuyerAgentLastName","CoBuyerAgentMainOfficeKeyNumeric",
            "CoBuyerAgentMlsId","CoBuyerAgentStateLicense","CoBuyerOfficeAOR","CoBuyerOfficeKeyNumeric","CoBuyerOfficeMlsId","CoBuyerOfficeName","CoBuyerOfficeStateLicense","CoListAgentAOR",
            "CoListAgentFirstName","CoListAgentKeyNumeric","CoListAgentLastName","CoListAgentMlsId","CoListAgentStateLicense","CoListOfficeAOR","CoListOfficeFax","CoListOfficeKeyNumeric",
            "CoListOfficeMlsId","CoListOfficeName","CoListOfficePhone","CoListOfficeStateLicense","CommonWalls","CommunityFeatures","ConstructionMaterials","Cooling","CoolingYN","Country",
            "CountyOrParish","CumulativeDaysOnMarket","DaysOnMarket","DeletedYN","DirectionFaces","Directions","DocumentNumber","DOH1","DOH2","DOH3","DoorFeatures","EatingArea","ElementarySchool", "ElementarySchool2",
            "ElementarySchoolOther","Elevation","EntryLevel","EntryLocation","Exclusions","ExteriorFeatures","FenceYN","Fencing","FireplaceFeatures","FireplaceYN","Flooring","FoundationDetails",
            "GarageSpaces","GreenEnergyEfficient","GreenEnergyGeneration","GreenIndoorAirQuality","GreenLocation","GreenSustainability","GreenWaterConservation","Heating","HeatingYN","HighSchool","HighSchool2",
            "Inclusions","InteriorFeatures","InternetAddressDisplayYN","InternetEntireListingDisplayYN","LandLeaseAmount","LandLeaseAmountFrequency","LandLeaseYN","LaundryFeatures","LaundryYN",
            "LeaseConsideredYN","Levels","License1","License2","License3","ListAgentAOR","ListAgentFirstName","ListAgentKeyNumeric","ListAgentLastName","ListAgentMlsId","ListAgentStateLicense",
            "ListingContractDate","ListOfficeKeyNumeric","ListOfficeMlsId","ListOfficeName","ListOfficeStateLicense","ListPriceLow","LivingAreaSource","LivingAreaUnits","LockBoxType",
            "LockBoxVersion","LotDimensionsSource","LotFeatures","LotSizeAcres","LotSizeArea","LotSizeDimensions","LotSizeSource","LotSizeUnits","MainLevelBathrooms","MainLevelBedrooms","MajorChangeType",
            "Make","MiddleOrJuniorSchool","MiddleOrJuniorSchool2","MiddleOrJuniorSchoolOther","MLSAreaMajor","ModificationTimestamp","NumberOfUnitsInCommunity","NumberRemotes","OffMarketTimestamp","OnMarketTimestamp",
            "OriginalEntryTimestamp","OriginalListPrice","OriginatingSystemID","OriginatingSystemKey","OriginatingSystemModificationTimestamp","OtherStructures","ParcelNumber","ParkingFeatures",
            "ParkingTotal","ParkingYN","PatioAndPorchFeatures","PatioYN","PhotosChangeTimestamp","PhotosCount","Points","PoolFeatures","PoolPrivateYN","PostalCodePlus4","PreviousListPrice",
            "PreviousStandardStatus","PricePerSquareFoot","PropertyAttachedYN","PropertyCondition","PropertySubType","PublicRemarks","PurchaseContractDate","RoadFrontageType","RoadSurfaceType",
            "Roof","RoomType","RVParkingDimensions","SecurityFeatures","SeniorCommunityYN","SerialU","SerialX","SerialXX","Sewer","SpaFeatures","SpaYN","SpecialListingConditions","SprinklersYN",
            "StatusChangeTimestamp","StoriesTotal","SubdivisionName","SubdivisionNameOther","TaxLot","TaxModel","TaxTract","TaxTractNumber","TractSubAreaCode","UncoveredSpaces","UnitNumber",
            "Utilities","View","ViewYN","VirtualTourURLBranded","VirtualTourURLUnbranded","VirtualTourURLUnbranded2","WalkScore","WaterfrontFeatures","WaterSource","WellDepth","WellGallonsPerMinute",
            "WellPumpHorsepower","WellReportYN","WindowFeatures","YearBuiltSource","Zoning"};


        private static RetsSession _libretsession = null;

        public bool LibretsLogin()
        {
            _libretsession = new RetsSession("https://pt.rets.crmls.org/contact/rets/login");

            // Set the flag to ignore SSL Cert Validation
            _libretsession.SetModeFlags(RetsSession.MODE_NO_SSL_VERIFY);

            // If something goes wrong and you need additional information
            // uncomment the line below to begin logging
            //retsSession.SetHttpLogName("c:\\temp\\rets.log");

            try
            {
                // Pass in the login credential provided by Dan
                bool success = _libretsession.Login(CrmlsUserName, CrmlsPassword);

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
            if (_libretsession != null)
            {
                _libretsession.Logout();
            }
        }

        public SearchRequest CreateSearchListings(string queryType, string queryString)
        {
            string query = null;
            if (queryString == "socal" && queryType == "aor")
            {
                query = "(ListAgentAOR=AR,AV,BB,BH,CD,CJ,CLAW,CRIS,CV,DAMLS,DW,EL,EV,EY,GA,HM,ID,IG,IN,ITEC,IV,MB,MU,OA,PD,PF,PT,PV,PW,RI,RS,SB,SI,SOCAL,SR,SU,WS),(ModificationTimestamp=2017-01-15T01:30:40+)";

            }
            else if (queryString == "recent" && queryType == "total")
            {
                DateTime now = DateTime.Now;
                string yesterday = now.AddDays(-2).ToString("yyyy-MM-ddT00:00:00+");
                query = "(ModificationTimestamp=" + yesterday + ")";

            }
            else if (queryType == "aor")
            {
                query = "(ListAgentAOR=" + queryString + "),(ModificationTimestamp=2017-01-15T01:30:40+)";

            }
            else if (queryType == "mlsid")
            {
                query = "(ListingId=" + queryString + ")";
            }
            var request = _libretsession.CreateSearchRequest("Property", "Residential", query);
            request.SetSelect(String.Join(",", CrmlsSelectColumnsDetails));
            return request;
        }

        public SearchRequest CreateSearchMedia(string queryType,string queryString)
        {
            string query = null;
            if (queryString == "socal" && queryType == "aor")
            {
                query = "(MemberAOR=AR,AV,BB,BH,CD,CJ,CLAW,CRIS,CV,DAMLS,DW,EL,EV,EY,GA,HM,ID,IG,IN,ITEC,IV,MB,MU,OA,PD,PF,PT,PV,PW,RI,RS,SB,SI,SOCAL,SR,SU,WS),(ModificationTimestamp=2017-01-15T01:30:40+)";

            }
            else if (queryString == "total" && queryType == "aor")
            {
                query = "(ModificationTimestamp=2017-01-15T01:30:40+)";

            }
            else if (queryString == "recent" && queryType == "total")
            {
                DateTime now = DateTime.Now;
                string yesterday = now.AddDays(-2).ToString("yyyy-MM-ddT00:00:00+");
                query = "(ModificationTimestamp=" + yesterday + ")";

            }
            else if (queryType == "aor")
            {
                query = "(MemberAOR=" + queryString + "),(ModificationTimestamp=2017-01-15T01:30:40+)";

            }
            else if (queryType == "recordkey")
            {
                query = "(ResourceRecordKeyNumeric=" + queryString + ")";
            }
            var request = _libretsession.CreateSearchRequest("Media", "Media", query);

            return request;
        }
        //Gets All Meta Data Information and Inserts into Table
        public List<MetaDataLookUp> GetMetaDataValues()
        {
            List<MetaDataLookUp> metaDataTypes = new List<MetaDataLookUp>();
            RetsMetadata metadata = _libretsession.GetMetadata();
            IEnumerable resources = metadata.GetAllResources();
            foreach (MetadataResource resource in resources)
            {
                int count = 0;
                MetaDataLookUp data = new MetaDataLookUp();
                string resourceName = resource.GetResourceID();
                data.Resource = resourceName;
                IEnumerable lookups = metadata.GetAllLookups(resourceName);
                foreach (MetadataLookup lookup in lookups)
                {
                    data.LookUpType = lookup.GetLookupName();
                    IEnumerable lookupTypes = metadata.GetAllLookupTypes(lookup);
                    List<MetaDataLookUpValues> valueList = new List<MetaDataLookUpValues>();
                    foreach (MetadataLookupType lookupType in lookupTypes)
                    {
                        MetaDataLookUpValues value = new MetaDataLookUpValues();
                        value.LookUpValue = lookupType.GetValue();
                        value.ShortValue = lookupType.GetShortValue();
                        value.LongValue = lookupType.GetLongValue();
                        try
                        {
                            using (SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                            {
                                using (SqlCommand cmd = new SqlCommand("dbo.MetaDataLookup_Insert", conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add("@MetaDataResource", SqlDbType.NVarChar).Value = data.Resource;
                                    cmd.Parameters.Add("@MetaDataType", SqlDbType.NVarChar).Value = data.LookUpType;
                                    cmd.Parameters.Add("@MetaDataValue", SqlDbType.NVarChar).Value = value.LookUpValue;
                                    cmd.Parameters.Add("@LongValue", SqlDbType.NVarChar).Value = value.LongValue;
                                    cmd.Parameters.Add("@ShortValue", SqlDbType.NVarChar).Value = value.ShortValue;
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                    Debug.WriteLine(string.Format("MetaData added Successfully {0}" , count));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                        valueList.Add(value);
                    }
                    data.MetaDataLookUpValue = valueList;
                    metaDataTypes.Add(data);
                }
            }
            return metaDataTypes;
        }

        //Gets Listings Details From Rets
        public List<ResidentialDetails> LibRetsListingsSearch(string queryType, string queryString)
        {
            List<ResidentialDetails> listResDetails = null;
            if (_libretsession == null)
            {
                if (!LibretsLogin())
                {
                    throw new ApplicationException("login has Failed");
                }
            }
            try
            {
                SearchRequest request = CreateSearchListings(queryType,queryString);
                SearchResultSet results = _libretsession.Search(request);

                Debug.WriteLine("Record count: " + results.GetCount());

                while (results.HasNext())
                {
                    ResidentialDetails rowData = new ResidentialDetails();
                    DataMapperDetails(results, rowData);

                    if (listResDetails == null)
                    {
                        listResDetails = new List<ResidentialDetails>();
                    }
                    listResDetails.Add(rowData);
                }
                return listResDetails;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        //Send Listings Data To SQL
        public List<bool> UpsertListings(List<ResidentialDetails> results)
        {
            int Id = 0;
            List<bool> messageList = new List<bool>();
            bool message;
            ResidentialDetails result = new ResidentialDetails();
            for (int i = 0; i < results.Count; i++)
            {
                DataProvider.ExecuteNonQuery(GetConnection, "dbo.Listings_Details_Upsert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {

                    result = results[i];
                    ParamMapper(result, paramCollection);
                    SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    p.Direction = System.Data.ParameterDirection.Output;
                    paramCollection.Add(p);
                    message = true;
                    messageList.Add(message);

                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out Id);

                }
                );
            }
            return messageList;

        }

        //Gets Media Details from Rets
        public List<ListingMediaDetails> LibRetsMediaSearch(string queryType, string queryString)
        {
            if (_libretsession == null)
            {
                if (!LibretsLogin())
                {
                    throw new ApplicationException("login has Failed");
                }
            }
            try
            {
                SearchRequest request = CreateSearchMedia(queryType, queryString);
                SearchResultSet results = _libretsession.Search(request);

                List<ListingMediaDetails> mediaList = new List<ListingMediaDetails>();

                Debug.WriteLine("Record count: " + results.GetCount());
                while (results.HasNext())
                {
                    ListingMediaDetails rowData = new ListingMediaDetails();

                    int startingIndex = 0;
                    int temp;
                    //decimal tempDec;
                    string tempString;
                    string tempDT;

                    rowData.FileSize = results.GetString(startingIndex++);
                    tempString = results.GetString(startingIndex++);
                    if (!string.IsNullOrWhiteSpace(tempString))
                    {
                        rowData.Approved = tempString.Substring(0).ToUpper() == "1" ? true : false;
                    }
                    tempString = results.GetString(startingIndex++);
                    if (!string.IsNullOrWhiteSpace(tempString))
                    {
                        rowData.ResourceName = tempString.Substring(0).ToUpper() == "1" ? true : false;
                    }
                    rowData.ImageOf = results.GetString(startingIndex++);
                    rowData.ChangedByMemberId = results.GetString(startingIndex++);
                    rowData.ChangedByMemberKeyNumeric = results.GetString(startingIndex++);
                    tempString = results.GetString(startingIndex++);
                    if (!string.IsNullOrWhiteSpace(tempString))
                    {
                        Int32.TryParse(tempString, out temp);
                        rowData.ClassName = temp;
                    }
                    tempString = results.GetString(startingIndex++);
                    if (!string.IsNullOrWhiteSpace(tempString))
                    {
                        rowData.DeletedYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
                    }
                    rowData.ImageHeight = results.GetString(startingIndex++);
                    rowData.ImageWidth = results.GetString(startingIndex++);
                    rowData.LongDescription = results.GetString(startingIndex++);
                    rowData.MediaHtml = results.GetString(startingIndex++);
                    rowData.MediaKey = results.GetString(startingIndex++);
                    tempDT = results.GetString(startingIndex++);
                    if (!string.IsNullOrWhiteSpace(tempDT))
                    {
                        rowData.MediaModificationTimestamp = DateTime.Parse(tempDT);
                    }
                    rowData.MediaObjectId = results.GetString(startingIndex++);
                    rowData.MediaUrl = results.GetString(startingIndex++);
                    rowData.MemberAor = results.GetString(startingIndex++);
                    rowData.MediaType = results.GetString(startingIndex++);
                    tempDT = results.GetString(startingIndex++);
                    if (!string.IsNullOrWhiteSpace(tempDT))
                    {
                        rowData.ModificationTimestamp = DateTime.Parse(tempDT);
                    }
                    rowData.OfficeMlsId = results.GetString(startingIndex++);
                    tempString = results.GetString(startingIndex++);
                    if (!string.IsNullOrWhiteSpace(tempString))
                    {
                        Int32.TryParse(tempString, out temp);
                        rowData.Order = temp;
                    }
                    rowData.OriginatingSystemMediaKey = results.GetString(startingIndex++);
                    rowData.OriginatingSystemId = results.GetString(startingIndex++);
                    rowData.ResourceRecordId = results.GetString(startingIndex++);
                    rowData.ResourceRecordKeyNumeric = results.GetString(startingIndex++);
                    tempString = results.GetString(startingIndex++);
                    if (!string.IsNullOrWhiteSpace(tempString))
                    {
                        Int32.TryParse(tempString, out temp);
                        rowData.ShortDescription = temp;
                    }

                    mediaList.Add(rowData);
                }
                return mediaList;

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        //Send Media Details to SQL
        public List<bool> UpsertMedia(List<ListingMediaDetails> results)
        {
            List<bool> messageList = new List<bool>();
            bool message;
            ListingMediaDetails result = new ListingMediaDetails();
            for (int i = 0; i < results.Count; i++)
            {
                DataProvider.ExecuteNonQuery(GetConnection, "dbo.ListingMedia_Upsert"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {

                    result = results[i];
                    MediaParamMapper(result, paramCollection);
                    message = true;
                    messageList.Add(message);

                }
                );
            }
            return messageList;
        }

        public List<MlsLookup> SelectAllMlsLookup()
        {
            List<MlsLookup> lookupList = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.MlsLookup_SelectAll"
                , inputParamMapper: null
                , map: delegate (IDataReader reader, short set)
                {
                    MlsLookup lookup = LookupMapper(reader);
                    if (lookupList == null)
                    {
                        lookupList = new List<MlsLookup>();
                    }
                    lookupList.Add(lookup);
                });
            return lookupList;
        }

        private static MlsLookup LookupMapper(IDataReader reader)
        {
            MlsLookup lookup = new Domain.MlsLookup();
            int startingIndex = 0;
            lookup.Id = reader.GetSafeInt32(startingIndex++);
            lookup.LongValue = reader.GetSafeString(startingIndex++);
            lookup.ShortValue = reader.GetSafeString(startingIndex++);
            return lookup;
        }

        //Sends search paramerters to sql table to get data to user
        public List<ResidentialDetails> SearchTable(SearchDetailsRequest request)
        {
            List<ResidentialDetails> results = null;
            Dictionary<int, ResidentialDetails > resultsDictionary = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Listings_SearchFilters"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", request.Id);
                    paramCollection.AddWithValue("@MlsListingId", request.MlsListingId);
                    paramCollection.AddWithValue("@Zip", request.PostalCode);
                    paramCollection.AddWithValue("@PriceMax", request.MaxPrice);
                    paramCollection.AddWithValue("@PriceMin", request.MinPrice);
                    paramCollection.AddWithValue("@BedsMax", request.MaxBeds);
                    paramCollection.AddWithValue("@BedsMin", request.MinBeds);
                    paramCollection.AddWithValue("@BathsTotMax", request.MaxBaths);
                    paramCollection.AddWithValue("@BathsTotMin", request.MinBaths);
                    paramCollection.AddWithValue("@BathsFull34", request.Full34Baths);
                    paramCollection.AddWithValue("@Baths34", request.Baths34);
                    paramCollection.AddWithValue("@BathsFull", request.FullBaths);
                    paramCollection.AddWithValue("@BathsHalf", request.HalfBaths);
                    paramCollection.AddWithValue("@BathsQuart", request.QuartBaths);
                    paramCollection.AddWithValue("@SeniorComm", request.SeniorComm);
                    paramCollection.AddWithValue("@LotSizeAreaMax", request.MaxLotSizeSqft);
                    paramCollection.AddWithValue("@LotSizeAreaMin", request.MinLotSizeSqft);
                    paramCollection.AddWithValue("@LivingAreaMax", request.MaxLivingAreaSqft);
                    paramCollection.AddWithValue("@LivingAreaMin", request.MinLivingAreaSqft);                    
                    paramCollection.AddWithValue("@GarageSpaces", request.GarageSpaces);
                    paramCollection.AddWithValue("@PropAttached", request.PropAttached);              
                    paramCollection.AddWithValue("@YearBuiltMax", request.MaxYearBuilt);
                    paramCollection.AddWithValue("@YearBuiltMin", request.MinYearBuilt);
                    paramCollection.AddWithValue("@County", request.County);
                    paramCollection.AddWithValue("@City", request.City);
                    paramCollection.AddWithValue("@MLSArea", request.MLSArea);
                    paramCollection.AddWithValue("@Status", request.Status);
                    paramCollection.AddWithValue("@Subdivision", request.Subdivision);
                    paramCollection.AddWithValue("@Cert433A", request.Cert433A);
                    paramCollection.AddWithValue("@PropSubType", request.PropSubType);
                    paramCollection.AddWithValue("@SpecialCond", request.SpecialCond);
                    paramCollection.AddWithValue("@TopRows", request.ShowingAmount);                    
                    paramCollection.AddWithValue("@actionCnty", request.CountyAction);
                    paramCollection.AddWithValue("@actionCity", request.CityAction);
                    paramCollection.AddWithValue("@actionMls", request.MlsAreaAction);
                    paramCollection.AddWithValue("@actionPropSub", request.ProbSubAction);
                    paramCollection.AddWithValue("@actionSpecCond", request.SpecCondAction);


                    paramCollection.AddWithValue("@Cooling", request.Cooling);
                    paramCollection.AddWithValue("@Heating", request.Heating);
                    paramCollection.AddWithValue("@Level", request.Level);
                    paramCollection.AddWithValue("@AccsbltyFeat", request.AccsbltyFeat);
                    paramCollection.AddWithValue("@ParkingFeat", request.ParkingFeat);
                    paramCollection.AddWithValue("@LotFeat", request.LotFeat);
                    paramCollection.AddWithValue("@HoaAmnty", request.HoaAmnty);
                    paramCollection.AddWithValue("@Assessment", request.Assessment);

                    paramCollection.AddWithValue("@CoolingAction", request.CoolingAction);
                    paramCollection.AddWithValue("@HeatingAction", request.HeatingAction);
                    paramCollection.AddWithValue("@LevelAction", request.LevelAction);
                    paramCollection.AddWithValue("@AccsbltyFeatAction", request.AccsbltyFeatAction);
                    paramCollection.AddWithValue("@ParkingFeatAction", request.ParkingFeatAction);
                    paramCollection.AddWithValue("@LotFeatAction", request.LotFeatAction);
                    paramCollection.AddWithValue("@HoaAmntyAction", request.HoaAmntyAction);
                    paramCollection.AddWithValue("@AssessmentAction", request.AssessmentAction);

                    //paramCollection.AddWithValue("@HoaFee", request.HoaFee);
                    //paramCollection.AddWithValue("@HoaFeeFreq", request.HoaFeeFreq);
                    paramCollection.AddWithValue("@LandLease", request.LandLease);
                    paramCollection.AddWithValue("@LeaseConsd", request.LeaseConsd);

                    //paramCollection.AddWithValue("@HoaFeeFreqAction", request.HoaFeeFreqAction);

                }, map: delegate (IDataReader reader, short set)
                {
                    switch (set)
                    {
                        case 0:
                            ResidentialDetails result = ResultMapperDetails(reader);
                            if (results == null)
                            {
                                results = new List<ResidentialDetails>();
                            }
                            if (resultsDictionary == null)
                            {
                                resultsDictionary = new Dictionary<int, ResidentialDetails>();
                            }
                            results.Add(result);
                            resultsDictionary.Add(result.Id.Value, result);
                            break;
                        case 1:
                            int parentListingId = 0;
                            ListingMediaBase listingMediaBase = MapListingMediaBase(reader, out parentListingId);
                            ResidentialDetails parent = resultsDictionary[parentListingId];
                            if (parent.ListingMedia == null)
                            {
                                parent.ListingMedia = new List<ListingMediaBase>();
                            }
                            parent.ListingMedia.Add(listingMediaBase);
                            break;
                        case 2:
                            break;
                    }
                });
            return results;
        }

        public List<ResidentialDetails> SearchTableLocalized(LocalizedParams request)
        {
            List<ResidentialDetails> results = null;
            Dictionary<int, ResidentialDetails> resultsDictionary = null;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Listings_SearchFiltersLocalized"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", request.Id);
                    paramCollection.AddWithValue("@MlsListingId", null);
                    paramCollection.AddWithValue("@Zip", null);
                    paramCollection.AddWithValue("@PriceMax", null);
                    paramCollection.AddWithValue("@PriceMin", null);
                    paramCollection.AddWithValue("@BedsMax", null);
                    paramCollection.AddWithValue("@BedsMin", null);
                    paramCollection.AddWithValue("@BathsTotMax", null);
                    paramCollection.AddWithValue("@BathsTotMin", null);
                    paramCollection.AddWithValue("@BathsFull34", null);
                    paramCollection.AddWithValue("@Baths34", null);
                    paramCollection.AddWithValue("@BathsFull", null);
                    paramCollection.AddWithValue("@BathsHalf", null);
                    paramCollection.AddWithValue("@BathsQuart", null);
                    paramCollection.AddWithValue("@SeniorComm", null);
                    paramCollection.AddWithValue("@LotSizeAreaMax", null);
                    paramCollection.AddWithValue("@LotSizeAreaMin", null);
                    paramCollection.AddWithValue("@LivingAreaMax", null);
                    paramCollection.AddWithValue("@LivingAreaMin", null);
                    paramCollection.AddWithValue("@GarageSpaces", null);
                    paramCollection.AddWithValue("@PropAttached", null);
                    paramCollection.AddWithValue("@YearBuiltMax", null);
                    paramCollection.AddWithValue("@YearBuiltMin", null);
                    paramCollection.AddWithValue("@County", null);
                    paramCollection.AddWithValue("@City", null);
                    paramCollection.AddWithValue("@MLSArea", null);
                    paramCollection.AddWithValue("@Status", null);
                    paramCollection.AddWithValue("@Subdivision", null);
                    paramCollection.AddWithValue("@Cert433A", null);
                    paramCollection.AddWithValue("@PropSubType", null);
                    paramCollection.AddWithValue("@SpecialCond", null);
                    paramCollection.AddWithValue("@TopRows", 400);
                    paramCollection.AddWithValue("@actionCnty", null);
                    paramCollection.AddWithValue("@actionCity", null);
                    paramCollection.AddWithValue("@actionMls", null);
                    paramCollection.AddWithValue("@actionPropSub", null);
                    paramCollection.AddWithValue("@actionSpecCond", null);


                    paramCollection.AddWithValue("@Cooling", null);
                    paramCollection.AddWithValue("@Heating", null);
                    paramCollection.AddWithValue("@Level", null);
                    paramCollection.AddWithValue("@AccsbltyFeat", null);
                    paramCollection.AddWithValue("@ParkingFeat", null);
                    paramCollection.AddWithValue("@LotFeat", null);
                    paramCollection.AddWithValue("@HoaAmnty", null);
                    paramCollection.AddWithValue("@Assessment", null);

                    paramCollection.AddWithValue("@CoolingAction", null);
                    paramCollection.AddWithValue("@HeatingAction", null);
                    paramCollection.AddWithValue("@LevelAction", null);
                    paramCollection.AddWithValue("@AccsbltyFeatAction", null);
                    paramCollection.AddWithValue("@ParkingFeatAction", null);
                    paramCollection.AddWithValue("@LotFeatAction", null);
                    paramCollection.AddWithValue("@HoaAmntyAction", null);
                    paramCollection.AddWithValue("@AssessmentAction", null);

                    //paramCollection.AddWithValue("@HoaFee", request.HoaFee);
                    //paramCollection.AddWithValue("@HoaFeeFreq", request.HoaFeeFreq);
                    paramCollection.AddWithValue("@LandLease", null);
                    paramCollection.AddWithValue("@LeaseConsd", null);
                    paramCollection.AddWithValue("@PreferredLanguage", request.PreferredLanguage);

                }, map: delegate (IDataReader reader, short set)
                {
                    switch (set)
                    {
                        case 0:
                            ResidentialDetails result = ResultMapperDetails(reader);
                            if (results == null)
                            {
                                results = new List<ResidentialDetails>();
                            }
                            if (resultsDictionary == null)
                            {
                                resultsDictionary = new Dictionary<int, ResidentialDetails>();
                            }
                            results.Add(result);
                            resultsDictionary.Add(result.Id.Value, result);
                            break;
                        case 1:
                            int parentListingId = 0;
                            ListingMediaBase listingMediaBase = MapListingMediaBase(reader, out parentListingId);
                            ResidentialDetails parent = resultsDictionary[parentListingId];
                            if (parent.ListingMedia == null)
                            {
                                parent.ListingMedia = new List<ListingMediaBase>();
                            }
                            parent.ListingMedia.Add(listingMediaBase);
                            break;
                        case 2:
                            break;
                    }
                });
            return results;
        }

        private ListingMediaBase MapListingMediaBase(IDataReader reader, out int parentListingId)
        {
            ListingMediaBase l = new ListingMediaBase();
            int startingIndex = 0;
            parentListingId = reader.GetSafeInt32(startingIndex++);
            startingIndex++;
            l.MediaUrl = reader.GetSafeString(startingIndex++);
            //if (l.MediaUrl.StartsWith("https", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    l.MediaUrl = l.MediaUrl.Substring(6);
            //}
            //if (l.MediaUrl.StartsWith("http", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    l.MediaUrl = l.MediaUrl.Substring(5);
            //}
            l.MediaType = reader.GetSafeString(startingIndex++);
            l.Order = reader.GetSafeInt32(startingIndex++);
            return l;
        }

        private static void DataMapper(SearchResultSet results, ResidentialBase rowData)
        {
            int startingIndex = 0;
            int temp;
            decimal tempDec;
            rowData.MlsListingId = results.GetString(startingIndex++);
            Int32.TryParse(results.GetString(startingIndex++), out temp);
            rowData.StandardStatus = results.GetString(startingIndex++);
            Int32.TryParse(results.GetString(startingIndex++), out temp);
            rowData.StreetNumberNumeric = temp;
            rowData.StreetNumber = results.GetString(startingIndex++);
            rowData.StreetDirPrefix = results.GetString(startingIndex++);
            rowData.StreetName = results.GetString(startingIndex++);
            rowData.StreetDirSuffix = results.GetString(startingIndex++);
            rowData.StreetSuffixModifier = results.GetString(startingIndex++);
            rowData.StreetSuffix = results.GetString(startingIndex++);
            rowData.City = results.GetString(startingIndex++);
            rowData.StateOrProvince = results.GetString(startingIndex++);
            rowData.PostalCode = results.GetString(startingIndex++);
            Int32.TryParse(results.GetString(startingIndex++), out temp);
            rowData.ListPrice = temp;
            Int32.TryParse(results.GetString(startingIndex++), out temp);
            rowData.BedroomsTotal = temp;
            Int32.TryParse(results.GetString(startingIndex++), out temp);
            rowData.BathroomsFull = temp;
            Int32.TryParse(results.GetString(startingIndex++), out temp);
            rowData.YearBuilt = temp;
            Int32.TryParse(results.GetString(startingIndex++), out temp);
            rowData.LivingArea = temp;
            Decimal.TryParse(results.GetString(startingIndex++), out tempDec);
            rowData.LotSizeSquareFeet = tempDec;
            rowData.HighSchoolDistrict = results.GetString(startingIndex++);
        }

        private static void DataMapperDetails(SearchResultSet results, ResidentialDetails rowData)
        {

            int startingIndex = 0;
            int temp;
            decimal tempDec;
            string tempString;
            string tempDT;

            //Base
            rowData.MlsListingId = results.GetString(startingIndex++);
            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.ListingKeyNumeric = temp;
            }

            rowData.StandardStatus = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.StreetNumberNumeric = temp;
            }

            rowData.StreetNumber = results.GetString(startingIndex++);
            rowData.StreetDirPrefix = results.GetString(startingIndex++);
            rowData.StreetName = results.GetString(startingIndex++);
            rowData.StreetDirSuffix = results.GetString(startingIndex++);
            rowData.StreetSuffixModifier = results.GetString(startingIndex++);
            rowData.StreetSuffix = results.GetString(startingIndex++);
            rowData.City = results.GetString(startingIndex++);
            rowData.StateOrProvince = results.GetString(startingIndex++);
            rowData.PostalCode = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.ListPrice = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BedroomsTotal = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BathroomsFull = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.YearBuilt = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.LivingArea = temp;
            }


            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.LotSizeSquareFeet = tempDec;
            }

            rowData.HighSchoolDistrict = results.GetString(startingIndex++);
            //rowData.MainMediaURL = results.GetString(startingIndex++);

            //Details

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData._433aCertifiedYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }



            rowData.AccessibilityFeatures = results.GetString(startingIndex++);
            rowData.AdditionalParcelsDescription = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.AdditionalParcelsYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.AdNumber = results.GetString(startingIndex++);
            rowData.Appliances = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.AppliancesYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.ArchitecturalStyle = results.GetString(startingIndex++);
            rowData.Assessments = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.AssessmentsYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }


            rowData.AssociationAmenities = results.GetString(startingIndex++);


            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.AssociationFee = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.AssociationFee2 = temp;
            }


            rowData.AssociationFee2Frequency = results.GetString(startingIndex++);
            rowData.AssociationFeeFrequency = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.AssociationYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.AttachedGarageYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }


            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BathroomsFullAndThreeQuarter = temp;
            }


            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BathroomsHalf = temp;
            }



            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BathroomsOneQuarter = temp;
            }



            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BathroomsThreeQuarter = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BathroomsTotalInteger = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BelowGradeFinishedArea = temp;
            }

            rowData.BelowGradeFinishedAreaUnits = results.GetString(startingIndex++);
            rowData.BuilderModel = results.GetString(startingIndex++);
            rowData.BuilderName = results.GetString(startingIndex++);
            rowData.BuyerAgentAOR = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BuyerAgentBrokerKeyNumeric = temp;
            }

            rowData.BuyerAgentBrokerMlsId = results.GetString(startingIndex++);
            rowData.BuyerAgentFirstName = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BuyerAgentKeyNumeric = temp;
            }

            rowData.BuyerAgentLastName = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BuyerAgentMainOfficeKeyNumeric = temp;
            }

            rowData.BuyerAgentMainOfficeMlsId = results.GetString(startingIndex++);
            rowData.BuyerAgentMlsId = results.GetString(startingIndex++);
            rowData.BuyerAgentStateLicense = results.GetString(startingIndex++);
            rowData.BuyerOfficeAOR = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.BuyerOfficeKeyNumeric = temp;
            }

            rowData.BuyerOfficeMlsId = results.GetString(startingIndex++);
            rowData.BuyerOfficeName = results.GetString(startingIndex++);
            rowData.BuyerOfficeStateLicense = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.CarportSpaces = tempDec;
            }

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.CloseDate = DateTime.Parse(tempDT);
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.ClosePrice = temp;
            }

            rowData.CoBuyerAgentAOR = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.CoBuyerAgentBrokerKeyNumeric = temp;
            }

            rowData.CoBuyerAgentBrokerMlsId = results.GetString(startingIndex++);
            rowData.CoBuyerAgentFirstName = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.CoBuyerAgentKeyNumeric = temp;
            }

            rowData.CoBuyerAgentLastName = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.CoBuyerAgentMainOfficeKeyNumeric = temp;
            }

            rowData.CoBuyerAgentMlsId = results.GetString(startingIndex++);
            rowData.CoBuyerAgentStateLicense = results.GetString(startingIndex++);
            rowData.CoBuyerOfficeAOR = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.CoBuyerOfficeKeyNumeric = temp;
            }
            rowData.CoBuyerOfficeMlsId = results.GetString(startingIndex++);
            rowData.CoBuyerOfficeName = results.GetString(startingIndex++);
            rowData.CoBuyerOfficeStateLicense = results.GetString(startingIndex++);
            rowData.CoListAgentAOR = results.GetString(startingIndex++);
            rowData.CoListAgentFirstName = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.CoListAgentKeyNumeric = temp;
            }
            rowData.CoListAgentLastName = results.GetString(startingIndex++);
            rowData.CoListAgentMlsId = results.GetString(startingIndex++);
            rowData.CoListAgentStateLicense = results.GetString(startingIndex++);
            rowData.CoListOfficeAOR = results.GetString(startingIndex++);
            rowData.CoListOfficeFax = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.CoListOfficeKeyNumeric = temp;
            }
            rowData.CoListOfficeMlsId = results.GetString(startingIndex++);
            rowData.CoListOfficeName = results.GetString(startingIndex++);
            rowData.CoListOfficePhone = results.GetString(startingIndex++);
            rowData.CoListOfficeStateLicense = results.GetString(startingIndex++);
            rowData.CommonWalls = results.GetString(startingIndex++);
            rowData.CommunityFeatures = results.GetString(startingIndex++);
            rowData.ConstructionMaterials = results.GetString(startingIndex++);
            rowData.Cooling = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.CoolingYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.Country = results.GetString(startingIndex++);
            rowData.CountyOrParish = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.CumulativeDaysOnMarket = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.DaysOnMarket = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.DeletedYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.DirectionFaces = results.GetString(startingIndex++);
            rowData.Directions = results.GetString(startingIndex++);
            rowData.DocumentNumber = results.GetString(startingIndex++);
            rowData.DOH1 = results.GetString(startingIndex++);
            rowData.DOH2 = results.GetString(startingIndex++);
            rowData.DOH3 = results.GetString(startingIndex++);
            rowData.DoorFeatures = results.GetString(startingIndex++);
            rowData.EatingArea = results.GetString(startingIndex++);
            rowData.ElementarySchool = results.GetString(startingIndex++);
            rowData.ElementarySchool2 = results.GetString(startingIndex++);
            rowData.ElementarySchoolOther = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.Elevation = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.EntryLevel = temp;
            }
            rowData.EntryLocation = results.GetString(startingIndex++);
            rowData.Exclusions = results.GetString(startingIndex++);
            rowData.ExteriorFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.FenceYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.Fencing = results.GetString(startingIndex++);
            rowData.FireplaceFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.FireplaceYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.Flooring = results.GetString(startingIndex++);
            rowData.FoundationDetails = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.GarageSpaces = tempDec;
            }
            rowData.GreenEnergyEfficient = results.GetString(startingIndex++);
            rowData.GreenEnergyGeneration = results.GetString(startingIndex++);
            rowData.GreenIndoorAirQuality = results.GetString(startingIndex++);
            rowData.GreenLocation = results.GetString(startingIndex++);
            rowData.GreenSustainability = results.GetString(startingIndex++);
            rowData.GreenWaterConservation = results.GetString(startingIndex++);
            rowData.Heating = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.HeatingYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.HighSchool = results.GetString(startingIndex++);
            rowData.HighSchool2 = results.GetString(startingIndex++);
            rowData.Inclusions = results.GetString(startingIndex++);
            rowData.InteriorFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.InternetAddressDisplayYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.InternetEntireListingDisplayYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.LandLeaseAmount = temp;
            }

            rowData.LandLeaseAmountFrequency = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.LandLeaseYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.LaundryFeatures = results.GetString(startingIndex++);


            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.LaundryYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.LeaseConsideredYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.Levels = results.GetString(startingIndex++);
            rowData.License1 = results.GetString(startingIndex++);
            rowData.License2 = results.GetString(startingIndex++);
            rowData.License3 = results.GetString(startingIndex++);
            rowData.ListAgentAOR = results.GetString(startingIndex++);
            rowData.ListAgentFirstName = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.ListAgentKeyNumeric = temp;
            }
            rowData.ListAgentLastName = results.GetString(startingIndex++);
            rowData.ListAgentMlsId = results.GetString(startingIndex++);
            rowData.ListAgentStateLicense = results.GetString(startingIndex++);

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.ListingContractDate = DateTime.Parse(tempDT);
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.ListOfficeKeyNumeric = temp;
            }

            rowData.ListOfficeMlsId = results.GetString(startingIndex++);
            rowData.ListOfficeName = results.GetString(startingIndex++);
            rowData.ListOfficeStateLicense = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.ListPriceLow = tempDec;
            }
            rowData.LivingAreaSource = results.GetString(startingIndex++);
            rowData.LivingAreaUnits = results.GetString(startingIndex++);
            rowData.LockBoxType = results.GetString(startingIndex++);
            rowData.LockBoxVersion = results.GetString(startingIndex++);
            rowData.LotDimensionsSource = results.GetString(startingIndex++);
            rowData.LotFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.LotSizeAcres = tempDec;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.LotSizeArea = tempDec;
            }
            rowData.LotSizeDimensions = results.GetString(startingIndex++);
            rowData.LotSizeSource = results.GetString(startingIndex++);
            rowData.LotSizeUnits = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.MainLevelBathrooms = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.MainLevelBedrooms = temp;
            }
            rowData.MajorChangeType = results.GetString(startingIndex++);
            rowData.Make = results.GetString(startingIndex++);
            rowData.MiddleOrJuniorSchool = results.GetString(startingIndex++);
            rowData.MiddleOrJuniorSchool2 = results.GetString(startingIndex++);
            rowData.MiddleOrJuniorSchoolOther = results.GetString(startingIndex++);
            rowData.MLSAreaMajor = results.GetString(startingIndex++);

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.ModificationTimestamp = DateTime.Parse(tempDT);
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.NumberOfUnitsInCommunity = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.NumberRemotes = temp;
            }

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.OffMarketTimestamp = DateTime.Parse(tempDT);
            }

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.OnMarketTimestamp = DateTime.Parse(tempDT);
            }

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.OriginalEntryTimestamp = DateTime.Parse(tempDT);
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.OriginalListPrice = temp;
            }
            rowData.OriginatingSystemID = results.GetString(startingIndex++);
            rowData.OriginatingSystemKey = results.GetString(startingIndex++);

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.OriginatingSystemModificationTimestamp = DateTime.Parse(tempDT);
            }

            rowData.OtherStructures = results.GetString(startingIndex++);
            rowData.ParcelNumber = results.GetString(startingIndex++);
            rowData.ParkingFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.ParkingTotal = tempDec;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.ParkingYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.PatioAndPorchFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.PatioYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.PhotosChangeTimestamp = DateTime.Parse(tempDT);
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.PhotosCount = temp;
            }

            rowData.Points = results.GetString(startingIndex++);
            rowData.PoolFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.PoolPrivateYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.PostalCodePlus4 = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.PreviousListPrice = temp;
            }
            rowData.PreviousStandardStatus = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.PricePerSquareFoot = tempDec;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.PropertyAttachedYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.PropertyCondition = results.GetString(startingIndex++);
            rowData.PropertySubType = results.GetString(startingIndex++);
            rowData.PublicRemarks = results.GetString(startingIndex++);

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.PurchaseContractDate = DateTime.Parse(tempDT);

            }
            rowData.RoadFrontageType = results.GetString(startingIndex++);
            rowData.RoadSurfaceType = results.GetString(startingIndex++);
            rowData.Roof = results.GetString(startingIndex++);
            rowData.RoomType = results.GetString(startingIndex++);
            rowData.RVParkingDimensions = results.GetString(startingIndex++);
            rowData.SecurityFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.SeniorCommunityYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }


            rowData.SerialU = results.GetString(startingIndex++);
            rowData.SerialX = results.GetString(startingIndex++);
            rowData.SerialXX = results.GetString(startingIndex++);
            rowData.Sewer = results.GetString(startingIndex++);
            rowData.SpaFeatures = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.SpaYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            rowData.SpecialListingConditions = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.SprinklersYN = tempString.Substring(0).ToUpper() == "1" ? true : false;
            }

            tempDT = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempDT))
            {
                rowData.StatusChangeTimestamp = DateTime.Parse(tempDT);

            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.StoriesTotal = temp;
            }
            rowData.SubdivisionName = results.GetString(startingIndex++);
            rowData.SubdivisionNameOther = results.GetString(startingIndex++);
            rowData.TaxLot = results.GetString(startingIndex++);
            rowData.TaxModel = results.GetString(startingIndex++);
            rowData.TaxTract = results.GetString(startingIndex++);
            rowData.TaxTractNumber = results.GetString(startingIndex++);
            rowData.TractSubAreaCode = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                decimal.TryParse(tempString, out tempDec);
                rowData.UncoveredSpaces = tempDec;
            }
            rowData.UnitNumber = results.GetString(startingIndex++);
            rowData.Utilities = results.GetString(startingIndex++);
            rowData.View = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.ViewYN = tempString.Substring(0).ToUpper() == "1" ? true : false;

            }
            rowData.VirtualTourURLBranded = results.GetString(startingIndex++);
            rowData.VirtualTourURLUnbranded = results.GetString(startingIndex++);
            rowData.VirtualTourURLUnbranded2 = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.WalkScore = temp;
            }
            rowData.WaterfrontFeatures = results.GetString(startingIndex++);
            rowData.WaterSource = results.GetString(startingIndex++);

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Int32.TryParse(tempString, out temp);
                rowData.WellDepth = temp;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.WellGallonsPerMinute = tempDec;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                Decimal.TryParse(tempString, out tempDec);
                rowData.WellPumpHorsepower = tempDec;
            }

            tempString = results.GetString(startingIndex++);
            if (!string.IsNullOrWhiteSpace(tempString))
            {
                rowData.WellReportYN = tempString.Substring(0).ToUpper() == "1" ? true : false;

            }

            rowData.WindowFeatures = results.GetString(startingIndex++);
            rowData.YearBuiltSource = results.GetString(startingIndex++);
            rowData.Zoning = results.GetString(startingIndex++);
        }

        private static void ParamMapper(ResidentialDetails result, SqlParameterCollection paramCollection)
        {
            //Base
            paramCollection.AddWithValue("@ListingKeyNumeric", result.ListingKeyNumeric);
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

        private static ResidentialDetails ResultMapperDetails(IDataReader reader)
        {

            ResidentialDetails result = new ResidentialDetails();

            int ordinal = 0;
            //Details
            // result.row = reader.GetSafeInt64Nullable(ordinal++);
            result.Id = reader.GetSafeInt32(ordinal++);
            result.ListingKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.StandardStatus = reader.GetSafeString(ordinal++);
            result.StreetNumberNumeric = reader.GetSafeInt32(ordinal++);
            result.StreetNumber = reader.GetSafeString(ordinal++);
            result.StreetDirPrefix = reader.GetSafeString(ordinal++);
            result.StreetName = reader.GetSafeString(ordinal++);
            result.StreetDirSuffix = reader.GetSafeString(ordinal++);
            result.StreetSuffixModifier = reader.GetSafeString(ordinal++);
            result.StreetSuffix = reader.GetSafeString(ordinal++);
            result.StateOrProvince = reader.GetSafeString(ordinal++);
            result.YearBuilt = reader.GetSafeInt32(ordinal++);
            result.HighSchoolDistrict = reader.GetSafeString(ordinal++);
            result.MainMediaURL = reader.GetSafeString(ordinal++);
            result.HasOpenHouse = reader.GetSafeBool(ordinal++);
            result.DisplayOrder = reader.GetSafeInt32(ordinal++);
            result.MlsListingId = reader.GetSafeString(ordinal++);
            result.FavoritesId = reader.GetSafeString(ordinal++);
            ordinal++; //incrementing for StreetAddresss
            result.AddressLine1 = reader.GetSafeString(ordinal++);
            result.AddressLine2 = reader.GetSafeString(ordinal++);
            result.City = reader.GetSafeString(ordinal++);
            result.PostalCode = reader.GetSafeString(ordinal++);
            result.ListPrice = reader.GetSafeInt32(ordinal++);
            result.BedroomsTotal = reader.GetSafeInt32(ordinal++);
            result.BathroomsFull = reader.GetSafeInt32(ordinal++);
            result.LivingArea = reader.GetSafeInt32(ordinal++);
            result.LotSizeSquareFeet = reader.GetSafeDecimal(ordinal++);
            //Details
            result._433aCertifiedYN = reader.GetSafeBool(ordinal++);
            result.AccessibilityFeatures = reader.GetSafeString(ordinal++);
            result.AdditionalParcelsDescription = reader.GetSafeString(ordinal++);
            result.AdditionalParcelsYN = reader.GetSafeBool(ordinal++);
            result.AdNumber = reader.GetSafeString(ordinal++);
            result.Appliances = reader.GetSafeString(ordinal++);
            result.AppliancesYN = reader.GetSafeBool(ordinal++);
            result.ArchitecturalStyle = reader.GetSafeString(ordinal++);
            result.Assessments = reader.GetSafeString(ordinal++);
            result.AssessmentsYN = reader.GetSafeBool(ordinal++);
            result.AssociationAmenities = reader.GetSafeString(ordinal++);
            result.AssociationFee = reader.GetSafeInt32(ordinal++);
            result.AssociationFee2 = reader.GetSafeInt32(ordinal++);
            result.AssociationFee2Frequency = reader.GetSafeString(ordinal++);
            result.AssociationFeeFrequency = reader.GetSafeString(ordinal++);
            result.AssociationYN = reader.GetSafeBool(ordinal++);
            result.AttachedGarageYN = reader.GetSafeBool(ordinal++);
            result.BathroomsFullAndThreeQuarter = reader.GetSafeInt32(ordinal++);
            result.BathroomsHalf = reader.GetSafeInt32(ordinal++);
            result.BathroomsOneQuarter = reader.GetSafeInt32(ordinal++);
            result.BathroomsThreeQuarter = reader.GetSafeInt32(ordinal++);
            result.BathroomsTotalInteger = reader.GetSafeInt32(ordinal++);
            result.BelowGradeFinishedArea = reader.GetSafeInt32(ordinal++);
            result.BelowGradeFinishedAreaUnits = reader.GetSafeString(ordinal++);
            result.BuilderModel = reader.GetSafeString(ordinal++);
            result.BuilderName = reader.GetSafeString(ordinal++);
            result.BuyerAgentAOR = reader.GetSafeString(ordinal++);
            result.BuyerAgentBrokerKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.BuyerAgentBrokerMlsId = reader.GetSafeString(ordinal++);
            result.BuyerAgentFirstName = reader.GetSafeString(ordinal++);
            result.BuyerAgentKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.BuyerAgentLastName = reader.GetSafeString(ordinal++);
            result.BuyerAgentMainOfficeKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.BuyerAgentMainOfficeMlsId = reader.GetSafeString(ordinal++);
            result.BuyerAgentMlsId = reader.GetSafeString(ordinal++);
            result.BuyerAgentStateLicense = reader.GetSafeString(ordinal++);
            result.BuyerOfficeAOR = reader.GetSafeString(ordinal++);
            result.BuyerOfficeKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.BuyerOfficeMlsId = reader.GetSafeString(ordinal++);
            result.BuyerOfficeName = reader.GetSafeString(ordinal++);
            result.BuyerOfficeStateLicense = reader.GetSafeString(ordinal++);
            result.CarportSpaces = reader.GetSafeDecimal(ordinal++);
            result.CloseDate = reader.GetSafeDateTime(ordinal++);
            result.ClosePrice = reader.GetSafeInt32(ordinal++);
            result.CoBuyerAgentAOR = reader.GetSafeString(ordinal++);
            result.CoBuyerAgentBrokerKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.CoBuyerAgentBrokerMlsId = reader.GetSafeString(ordinal++);
            result.CoBuyerAgentFirstName = reader.GetSafeString(ordinal++);
            result.CoBuyerAgentKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.CoBuyerAgentLastName = reader.GetSafeString(ordinal++);
            result.CoBuyerAgentMainOfficeKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.CoBuyerAgentMlsId = reader.GetSafeString(ordinal++);
            result.CoBuyerAgentStateLicense = reader.GetSafeString(ordinal++);
            result.CoBuyerOfficeAOR = reader.GetSafeString(ordinal++);
            result.CoBuyerOfficeKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.CoBuyerOfficeMlsId = reader.GetSafeString(ordinal++);
            result.CoBuyerOfficeName = reader.GetSafeString(ordinal++);
            result.CoBuyerOfficeStateLicense = reader.GetSafeString(ordinal++);
            result.CoListAgentAOR = reader.GetSafeString(ordinal++);
            result.CoListAgentFirstName = reader.GetSafeString(ordinal++);
            result.CoListAgentKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.CoListAgentLastName = reader.GetSafeString(ordinal++);
            result.CoListAgentMlsId = reader.GetSafeString(ordinal++);
            result.CoListAgentStateLicense = reader.GetSafeString(ordinal++);
            result.CoListOfficeAOR = reader.GetSafeString(ordinal++);
            result.CoListOfficeFax = reader.GetSafeString(ordinal++);
            result.CoListOfficeKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.CoListOfficeMlsId = reader.GetSafeString(ordinal++);
            result.CoListOfficeName = reader.GetSafeString(ordinal++);
            result.CoListOfficePhone = reader.GetSafeString(ordinal++);
            result.CoListOfficeStateLicense = reader.GetSafeString(ordinal++);
            result.CommonWalls = reader.GetSafeString(ordinal++);
            result.CommunityFeatures = reader.GetSafeString(ordinal++);
            result.ConstructionMaterials = reader.GetSafeString(ordinal++);
            result.Cooling = reader.GetSafeString(ordinal++);
            result.CoolingYN = reader.GetSafeBool(ordinal++);
            result.Country = reader.GetSafeString(ordinal++);
            result.CountyOrParish = reader.GetSafeString(ordinal++);
            result.CumulativeDaysOnMarket = reader.GetSafeInt32(ordinal++);
            result.DaysOnMarket = reader.GetSafeInt32(ordinal++);
            result.DeletedYN = reader.GetSafeBool(ordinal++);
            result.DirectionFaces = reader.GetSafeString(ordinal++);
            result.Directions = reader.GetSafeString(ordinal++);
            result.DocumentNumber = reader.GetSafeString(ordinal++);
            result.DOH1 = reader.GetSafeString(ordinal++);
            result.DOH2 = reader.GetSafeString(ordinal++);
            result.DOH3 = reader.GetSafeString(ordinal++);
            result.DoorFeatures = reader.GetSafeString(ordinal++);
            result.EatingArea = reader.GetSafeString(ordinal++);
            result.ElementarySchool = reader.GetSafeString(ordinal++);
            result.ElementarySchool2 = reader.GetSafeString(ordinal++);
            result.ElementarySchoolOther = reader.GetSafeString(ordinal++);
            result.Elevation = reader.GetSafeInt32(ordinal++);
            result.EntryLevel = reader.GetSafeInt32(ordinal++);
            result.EntryLocation = reader.GetSafeString(ordinal++);
            result.Exclusions = reader.GetSafeString(ordinal++);
            result.ExteriorFeatures = reader.GetSafeString(ordinal++);
            result.FenceYN = reader.GetSafeBool(ordinal++);
            result.Fencing = reader.GetSafeString(ordinal++);
            result.FireplaceFeatures = reader.GetSafeString(ordinal++);
            result.FireplaceYN = reader.GetSafeBool(ordinal++);
            result.Flooring = reader.GetSafeString(ordinal++);
            result.FoundationDetails = reader.GetSafeString(ordinal++);
            result.GarageSpaces = reader.GetSafeDecimal(ordinal++);
            result.GreenEnergyEfficient = reader.GetSafeString(ordinal++);
            result.GreenEnergyGeneration = reader.GetSafeString(ordinal++);
            result.GreenIndoorAirQuality = reader.GetSafeString(ordinal++);
            result.GreenLocation = reader.GetSafeString(ordinal++);
            result.GreenSustainability = reader.GetSafeString(ordinal++);
            result.GreenWaterConservation = reader.GetSafeString(ordinal++);
            result.Heating = reader.GetSafeString(ordinal++);
            result.HeatingYN = reader.GetSafeBool(ordinal++);
            result.HighSchool = reader.GetSafeString(ordinal++);
            result.HighSchool2 = reader.GetSafeString(ordinal++);
            result.Inclusions = reader.GetSafeString(ordinal++);
            result.InteriorFeatures = reader.GetSafeString(ordinal++);
            result.InternetAddressDisplayYN = reader.GetSafeBool(ordinal++);
            result.InternetEntireListingDisplayYN = reader.GetSafeBool(ordinal++);
            result.LandLeaseAmount = reader.GetSafeInt32(ordinal++);
            result.LandLeaseAmountFrequency = reader.GetSafeString(ordinal++);
            result.LandLeaseYN = reader.GetSafeBool(ordinal++);
            result.LaundryFeatures = reader.GetSafeString(ordinal++);
            result.LaundryYN = reader.GetSafeBool(ordinal++);
            result.LeaseConsideredYN = reader.GetSafeBool(ordinal++);
            result.Levels = reader.GetSafeString(ordinal++);
            result.License1 = reader.GetSafeString(ordinal++);
            result.License2 = reader.GetSafeString(ordinal++);
            result.License3 = reader.GetSafeString(ordinal++);
            result.ListAgentAOR = reader.GetSafeString(ordinal++);
            result.ListAgentFirstName = reader.GetSafeString(ordinal++);
            result.ListAgentKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.ListAgentLastName = reader.GetSafeString(ordinal++);
            result.ListAgentMlsId = reader.GetSafeString(ordinal++);
            result.ListAgentStateLicense = reader.GetSafeString(ordinal++);
            result.ListingContractDate = reader.GetSafeDateTime(ordinal++);
            result.ListOfficeKeyNumeric = reader.GetSafeInt32(ordinal++);
            result.ListOfficeMlsId = reader.GetSafeString(ordinal++);
            result.ListOfficeName = reader.GetSafeString(ordinal++);
            result.ListOfficeStateLicense = reader.GetSafeString(ordinal++);
            result.ListPriceLow = reader.GetSafeDecimal(ordinal++);
            result.LivingAreaSource = reader.GetSafeString(ordinal++);
            result.LivingAreaUnits = reader.GetSafeString(ordinal++);
            result.LockBoxType = reader.GetSafeString(ordinal++);
            result.LockBoxVersion = reader.GetSafeString(ordinal++);
            result.LotDimensionsSource = reader.GetSafeString(ordinal++);
            result.LotFeatures = reader.GetSafeString(ordinal++);
            result.LotSizeAcres = reader.GetSafeDecimal(ordinal++);
            result.LotSizeArea = reader.GetSafeDecimal(ordinal++);
            result.LotSizeDimensions = reader.GetSafeString(ordinal++);
            result.LotSizeSource = reader.GetSafeString(ordinal++);
            result.LotSizeUnits = reader.GetSafeString(ordinal++);
            result.MainLevelBathrooms = reader.GetSafeInt32(ordinal++);
            result.MainLevelBedrooms = reader.GetSafeInt32(ordinal++);
            result.MajorChangeType = reader.GetSafeString(ordinal++);
            result.Make = reader.GetSafeString(ordinal++);
            result.MiddleOrJuniorSchool = reader.GetSafeString(ordinal++);
            result.MiddleOrJuniorSchool2 = reader.GetSafeString(ordinal++);
            result.MiddleOrJuniorSchoolOther = reader.GetSafeString(ordinal++);
            result.MLSAreaMajor = reader.GetSafeString(ordinal++);
            result.ModificationTimestamp = reader.GetSafeDateTime(ordinal++);
            result.NumberOfUnitsInCommunity = reader.GetSafeInt32(ordinal++);
            result.NumberRemotes = reader.GetSafeInt32(ordinal++);
            result.OffMarketTimestamp = reader.GetSafeDateTime(ordinal++);
            result.OnMarketTimestamp = reader.GetSafeDateTime(ordinal++);
            result.OriginalEntryTimestamp = reader.GetSafeDateTime(ordinal++);
            result.OriginalListPrice = reader.GetSafeInt32(ordinal++);
            result.OriginatingSystemID = reader.GetSafeString(ordinal++);
            result.OriginatingSystemKey = reader.GetSafeString(ordinal++);
            result.OriginatingSystemModificationTimestamp = reader.GetSafeDateTime(ordinal++);
            result.OtherStructures = reader.GetSafeString(ordinal++);
            result.ParcelNumber = reader.GetSafeString(ordinal++);
            result.ParkingFeatures = reader.GetSafeString(ordinal++);
            result.ParkingTotal = reader.GetSafeDecimal(ordinal++);
            result.ParkingYN = reader.GetSafeBool(ordinal++);
            result.PatioAndPorchFeatures = reader.GetSafeString(ordinal++);
            result.PatioYN = reader.GetSafeBool(ordinal++);
            result.PhotosChangeTimestamp = reader.GetSafeDateTime(ordinal++);
            result.PhotosCount = reader.GetSafeInt32(ordinal++);
            result.Points = reader.GetSafeString(ordinal++);
            result.PoolFeatures = reader.GetSafeString(ordinal++);
            result.PoolPrivateYN = reader.GetSafeBool(ordinal++);
            result.PostalCodePlus4 = reader.GetSafeString(ordinal++);
            result.PreviousListPrice = reader.GetSafeInt32(ordinal++);
            result.PreviousStandardStatus = reader.GetSafeString(ordinal++);
            result.PricePerSquareFoot = reader.GetSafeDecimal(ordinal++);
            result.PropertyAttachedYN = reader.GetSafeBool(ordinal++);
            result.PropertyCondition = reader.GetSafeString(ordinal++);
            result.PropertySubType = reader.GetSafeString(ordinal++);
            result.PublicRemarks = reader.GetSafeString(ordinal++);
            result.PurchaseContractDate = reader.GetSafeDateTime(ordinal++);
            result.RoadFrontageType = reader.GetSafeString(ordinal++);
            result.RoadSurfaceType = reader.GetSafeString(ordinal++);
            result.Roof = reader.GetSafeString(ordinal++);
            result.RoomType = reader.GetSafeString(ordinal++);
            result.RVParkingDimensions = reader.GetSafeString(ordinal++);
            result.SecurityFeatures = reader.GetSafeString(ordinal++);
            result.SeniorCommunityYN = reader.GetSafeBool(ordinal++);
            result.SerialU = reader.GetSafeString(ordinal++);
            result.SerialX = reader.GetSafeString(ordinal++);
            result.SerialXX = reader.GetSafeString(ordinal++);
            result.Sewer = reader.GetSafeString(ordinal++);
            result.SpaFeatures = reader.GetSafeString(ordinal++);
            result.SpaYN = reader.GetSafeBool(ordinal++);
            result.SpecialListingConditions = reader.GetSafeString(ordinal++);
            result.SprinklersYN = reader.GetSafeBool(ordinal++);
            result.StatusChangeTimestamp = reader.GetSafeDateTime(ordinal++);
            result.StoriesTotal = reader.GetSafeInt32(ordinal++);
            result.SubdivisionName = reader.GetSafeString(ordinal++);
            result.SubdivisionNameOther = reader.GetSafeString(ordinal++);
            result.TaxLot = reader.GetSafeString(ordinal++);
            result.TaxModel = reader.GetSafeString(ordinal++);
            result.TaxTract = reader.GetSafeString(ordinal++);
            result.TaxTractNumber = reader.GetSafeString(ordinal++);
            result.TractSubAreaCode = reader.GetSafeString(ordinal++);
            result.UncoveredSpaces = reader.GetSafeDecimal(ordinal++);
            result.UnitNumber = reader.GetSafeString(ordinal++);
            result.Utilities = reader.GetSafeString(ordinal++);
            result.View = reader.GetSafeString(ordinal++);
            result.ViewYN = reader.GetSafeBool(ordinal++);
            result.VirtualTourURLBranded = reader.GetSafeString(ordinal++);
            result.VirtualTourURLUnbranded = reader.GetSafeString(ordinal++);
            result.VirtualTourURLUnbranded2 = reader.GetSafeString(ordinal++);
            result.WalkScore = reader.GetSafeInt32(ordinal++);
            result.WaterfrontFeatures = reader.GetSafeString(ordinal++);
            result.WaterSource = reader.GetSafeString(ordinal++);
            result.WellDepth = reader.GetSafeInt32(ordinal++);
            result.WellGallonsPerMinute = reader.GetSafeDecimal(ordinal++);
            result.WellPumpHorsepower = reader.GetSafeDecimal(ordinal++);
            result.WellReportYN = reader.GetSafeBool(ordinal++);
            result.WindowFeatures = reader.GetSafeString(ordinal++);
            result.YearBuiltSource = reader.GetSafeString(ordinal++);
            result.Zoning = reader.GetSafeString(ordinal++);
            result.DateCreated = reader.GetSafeDateTime(ordinal++);
            result.DateModified = reader.GetSafeDateTime(ordinal++);
            result.Latitude = reader.GetSafeDecimal(ordinal++);
            result.Longitude = reader.GetSafeDecimal(ordinal++);
            return result;
        }

        //MediaParamMapper
        private static void MediaParamMapper(ListingMediaDetails result, SqlParameterCollection paramCollection)
        {
            paramCollection.AddWithValue("@Approved", result.Approved);
            paramCollection.AddWithValue("@ChangedByMemberId", result.ChangedByMemberId);
            paramCollection.AddWithValue("@ChangedByMemberKeyNumeric", result.ChangedByMemberKeyNumeric);
            paramCollection.AddWithValue("@ClassName", result.ClassName);
            paramCollection.AddWithValue("@DeletedYN", result.DeletedYN);
            paramCollection.AddWithValue("@FileSize", result.FileSize);
            paramCollection.AddWithValue("@ImageHeight", result.ImageHeight);
            paramCollection.AddWithValue("@ImageOf", result.ImageOf);
            paramCollection.AddWithValue("@ImageWidth", result.ImageWidth);
            paramCollection.AddWithValue("@LongDescription", result.LongDescription);
            paramCollection.AddWithValue("@MediaHtml", result.MediaHtml);
            paramCollection.AddWithValue("@MediaKey", result.MediaKey);
            paramCollection.AddWithValue("@MediaModificationTimestamp", result.MediaModificationTimestamp);
            paramCollection.AddWithValue("@MediaObjectId", result.MediaObjectId);
            paramCollection.AddWithValue("@MediaType", result.MediaType);
            paramCollection.AddWithValue("@MediaUrl", result.MediaUrl);
            paramCollection.AddWithValue("@MemberAor", result.MemberAor);
            paramCollection.AddWithValue("@ModificationTimestamp", result.ModificationTimestamp);
            paramCollection.AddWithValue("@OfficeMlsId", result.OfficeMlsId);
            paramCollection.AddWithValue("@Order", result.Order);
            paramCollection.AddWithValue("@OriginatingSystemId", result.OriginatingSystemId);
            paramCollection.AddWithValue("@OriginatingSystemMediaKey", result.OriginatingSystemMediaKey);
            paramCollection.AddWithValue("@ResourceName", result.ResourceName);
            paramCollection.AddWithValue("@ResourceRecordId", result.ResourceRecordId);
            paramCollection.AddWithValue("@ResourceRecordKeyNumeric", result.ResourceRecordKeyNumeric);
            paramCollection.AddWithValue("@ShortDescription", result.ShortDescription);
        }

        public static void BatchMediaUpsert(string queryType,string queryString)
        {
            MlsService _mlsService = new MlsService();
            List<ListingMediaDetails> results = _mlsService.LibRetsMediaSearch(queryType,queryString);
            List<bool> message = _mlsService.UpsertMedia(results);
        }

        public static void BatchListingsUpsert(string queryType, string queryString)
        {
            MlsService _mlsService = new MlsService();
            List<ResidentialDetails> results = _mlsService.LibRetsListingsSearch(queryType,queryString);
            List<bool> message = _mlsService.UpsertListings(results);
        }
    }
}
