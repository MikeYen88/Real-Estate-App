//Califronia Bureau of Real Estate
private const string licenseUrl = "http://www2.dre.ca.gov/PublicASP/";

public LicenseInfo grabData(string licenseNumber)
        {
            string url = licenseUrl;
            string agent = "SALESPERSON";
            string broker = "BROKER";
            string office = "CORPORATION;
            if (licenseNumber.Length == 8)
            {
                url += "pplinfo.asp?License_id=" + licenseNumber;
            }

            HtmlWeb web = new HtmlWeb();
            HtmlDocument html = web.Load(url);
            LicenseInfo license = new LicenseInfo();
            var rows = html.DocumentNode.SelectNodes("//table//tr");
            if (rows != null && rows.Count > 0)
            {
                var cell = rows[0].SelectNodes(".//td");
                switch (cell[1].InnerText)
                {
                    case agent:
                        AgentMapper(license, rows);
                        break;
                    case broker:
                        BrokerMapper(license, rows);
                        break;
                    case office:
                        OfficeMapper(license, rows);
                        break;
                }
            }


            return license;

        }
        private static void AgentMapper(LicenseInfo agent, HtmlNodeCollection rows)
        {
            foreach (var row in rows)
            {
                var cells = row.SelectNodes(".//td");
                for (int i = 0; i < cells.Count; i++)
                {

                    switch (cells[i].InnerText)
                    {
                        case "License Type:":
                            agent.LicenseType = cells[i + 1].InnerText;
                            break;
                        case "Name:":
                            agent.Name = cells[i + 1].InnerText;
                            break;
                        case "Mailing Address:":
                            agent.Address = cells[i + 1].InnerText;
                            break;
                        case "License ID:":
                            agent.LicenseId = cells[i + 1].InnerText;
                            break;
                        case "Expiration Date:":
                            agent.ExpirationDate = Convert.ToDateTime(cells[i + 1].InnerText);
                            break;
                        case "License Status:":
                            agent.LicenseStatus = cells[i + 1].InnerText;
                            break;
                        case "Employing Broker:":
                            var cell = cells[i + 1].InnerHtml;
                            agent.EmployingBroker = cells[i + 1].InnerText.Substring(12, 8);
                            break;
                    }
                }
            }
        }
        private static void BrokerMapper(LicenseInfo broker, HtmlNodeCollection rows)
        {
            List<string> officeIds = new List<string>();
            List<string> agentIds = new List<string>();
            List<string> misc = new List<string>();
            foreach (var row in rows)
            {
                var cells = row.SelectNodes(".//td");
                for (int i = 0; i < cells.Count; i++)
                {
                    switch (cells[i].InnerText)
                    {
                        case "License Type:":
                            broker.LicenseType = cells[i + 1].InnerText;
                            break;
                        case "Name:":
                            broker.Name = cells[i + 1].InnerText;
                            break;
                        case "Mailing Address:":
                            broker.Address = cells[i + 1].InnerHtml.Replace("<font face=\"Verdana,Arial,Helvetica\" size=\"2\">", "").Replace("<br>", " ").Replace("</font>", "");
                            break;
                        case "License ID:":
                            broker.LicenseId = cells[i + 1].InnerText;
                            break;
                        case "Expiration Date:":
                            broker.ExpirationDate = Convert.ToDateTime(cells[i + 1].InnerText);
                            break;
                        case "License Status:":
                            broker.LicenseStatus = cells[i + 1].InnerText;
                            break;
                        case "Main Office:":
                            broker.MainOffice = cells[i + 1].InnerHtml.Replace("<font face=\"Verdana,Arial,Helvetica\" size=\"2\">", "").Replace("<br>", " ").Replace("</font>", "");
                            break;
                        case "DBA:":
                            broker.Dba = cells[i + 1].InnerText;
                            break;
                        case "Branches:":
                            broker.Branches = cells[i + 1].InnerText;
                            break;
                        case "Affiliated Licensed Corporation(s):":
                            if (cells[i + 1].InnerText.Contains("EXPIRED") || cells[i + 1].InnerText.Contains("CANCELED"))
                            {
                                break;
                            }
                            else
                            {
                                officeIds.Add(cells[i + 1].InnerText);
                            }
                            break;
                        case "SALESPERSONS":
                            agentIds.Add(cells[i + 1].InnerText.Substring(0, 8));
                            break;
                        case "":
                            misc.Add(cells[i + 1].InnerText);
                            break;
                    }
                }
            }
            filterOfficeIds(misc, broker, agentIds, officeIds);
            broker.AffiliatedOfficeId = officeIds;
            broker.AgentIds = agentIds;
        }
        private static void filterOfficeIds(List<string> ids, LicenseInfo info, List<string> agentIds, List<string> officeIds)
        {
            for (int j = 0; j < ids.Count; j++)
            {
                if (ids[j].Contains("Officer") && !ids[j].Contains("EXPIRED") && !ids[j].Contains("CANCELED")) 
                {
                    ids[j] = ids[j].Substring(0, 8);
                    officeIds.Add(ids[j]);
                }
                if (ids[j].Contains("License"))
                {
                    ids[j] = ids[j].Substring(0, 8);
                    agentIds.Add(ids[j]);
                }
            }
        }
        private static void OfficeMapper(LicenseInfo office, HtmlNodeCollection rows)
        {
            bool hasSeperateAgentsPage = false;
            string agentsPage = null;
            List<string> officerIds = null;
            List<string> misc = new List<string>();
            List<string> agentIds = null;
            foreach (var row in rows)
            {
                var cells = row.SelectNodes(".//td");
                for (int i = 0; i < cells.Count; i++)
                {

                    switch (cells[i].InnerText)
                    {
                        case "License Type:":
                            office.LicenseType = cells[i + 1].InnerText;
                            break;
                        case "Name:":
                            office.OfficeName = cells[i + 1].InnerText;
                            break;
                        case "Mailing Address:":
                            office.Address = cells[i + 1].InnerHtml.Replace("<font face=\"Verdana,Arial,Helvetica\" size=\"2\">", "").Replace("<br>", " ").Replace("</font>","");
                            break;
                        case "License ID:":
                            office.OfficeId = cells[i + 1].InnerText;
                            break;
                        case "Expiration Date:":
                            office.ExpirationDate = Convert.ToDateTime(cells[i + 1].InnerText);
                            break;
                        case "License Status:":
                            office.LicenseStatus = cells[i + 1].InnerText;
                            break;
                        case "Main Office:":
                            office.MainOffice = cells[i + 1].InnerHtml.Replace("<font face=\"Verdana,Arial,Helvetica\" size=\"2\">", "").Replace("<br>", " ").Replace("</font>", "");
                            break;
                        case "Licensed Officer(s):":
                            officerIds = new List<string>();
                            officerIds.Add(cells[i + 1].InnerText.Substring(19, 8));
                            break;
                        case "DBA:":
                            office.Dba = cells[i + 1].InnerText;
                            break;
                        case "Branches:":
                            office.Branches = cells[i + 1].InnerText;
                            break;
                        case "":
                            misc.Add(cells[i + 1].InnerText);
                            break;
                        case "Salespersons:":
                            agentIds = new List<string>();
                            if (cells[i + 1].InnerText.Contains("RETRIEVE SALESPERSON LIST"))
                            {
                                hasSeperateAgentsPage = true;
                                HtmlNode links = cells[i + 1].SelectSingleNode("//a[text()='RETRIEVE SALESPERSON LIST ']");
                                agentsPage = links.GetAttributeValue("href", null);
                            }
                            else
                            {
                                agentIds.Add(cells[i + 1].InnerText.Substring(0, 8));
                            }
                            break;
                    }
                }
            }
            if (hasSeperateAgentsPage)
            {
                agentIds = ExtractAgents(agentsPage);
                office.AgentIds = agentIds;
            }
            filterIds(office, officerIds, misc, agentIds);
        }

        private static List<string> ExtractAgents(string agentsPage)
        {
            string url = licenseUrl + agentsPage;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument html = web.Load(url);
            LicenseInfo license = new LicenseInfo();
            List<string> agentIds = new List<string>();
            string agentId = null;
            List<string> misc = new List<string>();
            bool hasMore = false;
            string agentPage = null;
            var agents = html.DocumentNode.SelectNodes("//a");
            foreach (var agent in agents)
            {
                string link = agent.GetAttributeValue("href", null);
                if (agent.InnerText.Contains("Next"))
                {
                        hasMore = true;
                        agentPage = link;
                }
                else if (link.Contains("License") && !link.Contains("NAV"))
                {
                    agentId = Regex.Match(agent.InnerText, @"\d+|").Value;
                    agentIds.Add(agentId);
                }
               
            }
            if (hasMore)
            {
                var moreAgents = ExtractAgents(agentPage);
                agentIds.AddRange(moreAgents);
            } 
            return agentIds;
        }

        private static void filterIds(LicenseInfo office, List<string> officerIds, List<string> misc, List<string> agentIds)
        {
            for (int j = 0; j < misc.Count; j++)
            {
                if (misc[j].Contains("License"))
                {
                    agentIds.Add(misc[j].Substring(0, 8));
                }
                if (misc[j].Contains("OFFICER") && !misc[j].Contains("CANCELED") && !misc[j].Contains("EXPIRED"))
                {
                    officerIds.Add(misc[j].Substring(19, 8));
                }
            }
            office.DesignatedOfficerIds = officerIds;
            office.AgentIds = agentIds;
        }
