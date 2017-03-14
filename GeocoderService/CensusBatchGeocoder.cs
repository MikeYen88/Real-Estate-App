        private const string censusBatchGeoCodeUri = "https://geocoding.geo.census.gov/geocoder/locations/addressbatch";
        private static string connectionString = "SQL Connection String";
        private static string filePath = "example/file/path";
        private const string table = "dbo.ExampleTable";
        private const string storedProc = "dbo.ExampleStoredProc";
        
        //benchmark 4 = Current Benchmark , 9 = 2010 Census Benchmark , 8 =  ACS2016 Benchmark
        public void GeocodeAddresses(int benchmark)
        {
            int count = GetCountFromDb(table);
            int remainder = count % 1000;
            for (int i = 0; i < count - remainder; i += 1000)
            {
                Debug.WriteLine(string.Format("Processing rows {0} to {1}", i.ToString(), (i + 999).ToString()) + " : " + DateTime.UtcNow);
                DataTable addresses = GetAddresses(i, i + 999);
                ExportRowsToFile(addresses);
                string result = SendAddressesToApi(filePath, benchmark);
                UpdateGeocodeToDb(result);
                DeleteExistingFile();
                Debug.WriteLine(string.Format("Finished rows {0} to {1}", i.ToString(), (i + 999).ToString()));
            }
            if (remainder > 0)
            {
                int rangeStart = count - remainder;
                int rangeEnd = count;
                DataTable addresses = GetAddresses(rangeStart, rangeEnd);
                ExportRowsToFile(addresses);
                string result = SendAddressesToApi(filePath, benchmark);
                UpdateGeocodeToDb(result);
                DeleteExistingFile();
            }

        }
        //private methods
        private static int GetCountFromDb(string table)
        {

            SqlDataAdapter da = null;
            DataTable data = new DataTable();
            string countQuery = string.Format("SELECT COUNT(*) FROM {0}", table);
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(countQuery, conn))
                    {
                        conn.Open();
                        da = new SqlDataAdapter(cmd);
                        da.Fill(data);
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Application", string.Format("SQL Error {0}", ex.Message));
                if (da != null)
                {
                    da.Dispose();
                }
                throw (ex);
            }
            try
            {
                return int.Parse(data.Rows[0].ItemArray[0].ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Application", string.Format("Error parsing row count of Address Table. Error {0}", ex.Message));
                return -1;
            }
        }
        private static DataTable GetAddresses(int firstIndex, int lastIndex)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@FirstIndex", SqlDbType.Int).Value = firstIndex;
                        cmd.Parameters.Add("@LastIndex", SqlDbType.Int).Value = lastIndex;
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        data.Load(dr);
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Application", string.Format("Error writing inbound data to DataTable {0}", exp.Message));

                if (data != null)
                    data.Dispose();

                throw (exp);
            }
            return data;

        }
        private static void ExportRowsToFile(DataTable table)
        {
            // Convert rows to CSV format and write to file
            string csv = ToCsv(table);
            File.WriteAllText(filePath, csv);
        }
        private static string ToCsv(DataTable table)
        {
            StringBuilder result = new StringBuilder();

            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    result.Append(row[i].ToString().Replace(",", "").Replace("   ", " ").Replace("  ", " ").Trim());
                    if (i == table.Columns.Count - 1)
                    {
                        result.Append(Environment.NewLine);
                    }
                    else
                    {
                        result.Append(",");
                    }

                }
            }
            return result.ToString();
        }
        private static string SendAddressesToApi(string csvPath, int benchmark)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = true;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(censusBatchGeoCodeUri);
                MultipartFormDataContent content = new MultipartFormDataContent();

                ByteArrayContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));
                fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "addressFile",
                    FileName = "exampleNameOfFile.csv"
                };
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                content.Add(fileContent);

                StringContent benchMarkContent = new StringContent(benchmark.ToString());
                benchMarkContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "benchmark"
                };
                content.Add(benchMarkContent);

                try
                {
                    HttpResponseMessage result = client.PostAsync("", content).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;
                    return resultContent;
                }
                catch (Exception ex)
                {
                    string resultContent = ex.Message;

                    return resultContent;
                }
            }
        }
        private static string UpdateGeocodeToDb(string csv)
        {
            DataTable dt = CsvToDataTable(csv);
            SqlDataAdapter da = null;
            foreach (DataRow row in dt.Rows)
            {
                int addressId = int.Parse((string)row[0]);
                Boolean Match = (string)row[2] == "Match" || (string)row[2] == "Tie" ? true : false;

                if (Match)
                {
                    Double lat = Double.Parse((string)row[5]);
                    Double lng = Double.Parse((string)row[6]);
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand("dbo.Listings_UpdateLatLng", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@Longitude", SqlDbType.Float).Value = lng;
                                cmd.Parameters.Add("@Latitude", SqlDbType.Float).Value = lat;
                                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = addressId;
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        System.Diagnostics.EventLog.WriteEntry("Application", string.Format("Error writing inbound data to DB  {0}", exp.Message));

                        if (da != null)
                            da.Dispose();

                        throw (exp);
                    }
                }
            }
            return "";
        }
        private static DataTable CsvToDataTable(string csv)
        {
            DataTable datatable = new DataTable();

            datatable.Columns.Add("id");
            datatable.Columns.Add("address");
            datatable.Columns.Add("match");
            datatable.Columns.Add("matchtype");
            datatable.Columns.Add("correctedAddress");
            datatable.Columns.Add("lat");
            datatable.Columns.Add("lng");
            datatable.Columns.Add("zip");
            datatable.Columns.Add("side");

            try
            {
                string[] tableData = csv.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string row in tableData)
                {
                    DataRow datarow = datatable.NewRow();
                    string[] stringRow = row.Split(new string[] { "\",\"" }, StringSplitOptions.None);
                    datarow["id"] = stringRow[0].Replace("\"", "");
                    datarow["address"] = stringRow[1] != null ? stringRow[1] : null; ;
                    datarow["match"] = stringRow[2] != null ? stringRow[2] : null; ;
                    if (stringRow.Length > 3)
                    {
                        datarow["matchtype"] = stringRow[3] != null ? stringRow[3] : null;
                        datarow["correctedAddress"] = stringRow[4] != null ? stringRow[4] : null;
                        string[] latLng = stringRow[5].Split(',');
                        datarow["lat"] = latLng[0] != null ? latLng[0] : null;
                        datarow["lng"] = latLng[1] != null ? latLng[1] : null;
                        datarow["zip"] = stringRow[6] != null ? stringRow[6] : null;
                        datarow["side"] = stringRow[7] != null ? stringRow[7] : null;
                    }

                    datatable.Rows.Add(datarow);
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine("Application", string.Format("Error writing inbound data to DataTable {0}", exp.Message));

                if (datatable != null)
                    datatable.Dispose();

                throw (exp);
            }



            return datatable;
        }
        private static void DeleteExistingFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
