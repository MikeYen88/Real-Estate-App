        //Creates CSV from Stored Procedure
        public void CreateCsv()
        {
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string LogFolder = @"C:\SF.Code\C25\Sabio.Web\SampleData";
            try
            {
                string FileNamePart = "Geocodes";
                string DestinationFolder = @"C:\SF.Code\C25\Sabio.Web\SampleData";
                string StoredProcedure = "dbo.Listings_SelectAddressForGeocode";
                string FileDelimiter = ",";
                string FileExtension = ".csv";

                SqlConnection SQLConnection = new SqlConnection();
                SQLConnection.ConnectionString = "Data Source=sabiodata4.cdzsexgreyji.us-west-2.rds.amazonaws.com;Database=C25;User Id=C25_User;Password=Sabiopass1!;";

                string query = "EXEC " + StoredProcedure;
                SqlCommand cmd = new SqlCommand(query, SQLConnection);
                cmd.CommandTimeout = 0;
                SQLConnection.Open();
                DataTable d_table = new DataTable();
                d_table.Load(cmd.ExecuteReader());
                SQLConnection.Close();
                string FileFullPath = DestinationFolder + "\\" + FileNamePart + "_" + datetime + FileExtension;
                StreamWriter sw = null;
                sw = new StreamWriter(FileFullPath, false);
                int ColumnCount = d_table.Columns.Count;
                foreach (DataRow dr in d_table.Rows)
                {
                    for (int ir = 0; ir < ColumnCount; ir++)
                    {
                        if (!Convert.IsDBNull(dr[ir]))
                        {
                            sw.Write(dr[ir].ToString());
                        }
                        if (ir < ColumnCount - 1)
                        {
                            sw.Write(FileDelimiter);
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }
            catch (Exception exception)
            {
                // Create Log File for Errors
                using (StreamWriter sw = File.CreateText(LogFolder
                    + "\\" + "ErrorLog_" + datetime + ".log"))
                {
                    sw.WriteLine(exception.ToString());

                }

            }

        }
