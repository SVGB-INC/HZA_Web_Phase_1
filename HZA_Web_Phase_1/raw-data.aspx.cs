using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Configuration;
using System.Net;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace HZA_Web_Phase_1
{

    public partial class raw_data : System.Web.UI.Page
    {
        protected static DataTable dtView = new DataTable();
        protected static DataTable dtFilters = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");

            }
            else
            {
                if (IsPostBack)
                {
                    // It is a postback
                }
                else
                {

                    filtersNow.Visible = false;

                    //userName.Text = Session["username"].ToString();
                    lbUserName.Text = Session["username"].ToString();

                    string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = strConnString;

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    DataTable dtList = conn.GetSchema("Tables");

                    if (dtList.Rows.Count > 0)
                    {
                        dataDropDown.Items.Clear();

                        foreach (DataRow row in dtList.Rows)
                        {
                            string tablenameNew = (string)row[2];
                            dataDropDown.Items.Add(new ListItem(tablenameNew, tablenameNew));

                        }

                    }


                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }


                    ////update for first table
                    //conn.ConnectionString = strConnString;
                    //MySqlCommand cmd = new MySqlCommand();

                    //if (conn.State != ConnectionState.Open)
                    //{
                    //    conn.Open();
                    //}

                    //string tableName = dataDropDown.SelectedItem.Text;

                    //string query = "Select * from " + tableName + ";";
                    //cmd = new MySqlCommand(query, conn);
                    //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                    //cmd.ExecuteNonQuery();
                    //DataTable dtView = new DataTable();
                    //sda.Fill(dtView);

                    //viewtab.DataSource = dtView;
                    //viewtab.DataBind();

                    //viewtab.PageSize = 10;

                    //if (conn.State == ConnectionState.Open)
                    //{
                    //    conn.Close();
                    //}

                }


            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("index.aspx");

        }

        protected void dataChange(object sender, EventArgs e)
        {
            string tableName = dataDropDown.SelectedItem.Text;

            string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = strConnString;
            MySqlCommand cmd = new MySqlCommand();


            if (tableName != "raw_data")
            {

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = "Select * from " + tableName + ";";
                cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dtView = new DataTable();
                sda.Fill(dtView);

                viewtab.DataSource = dtView;
                viewtab.DataBind();

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }


            //filters for raw table
            if (tableName == "raw_data")
            {
                string query = "";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                

                filtersNow.Visible = true;

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }


                //filling company status
                query = "Select DISTINCT(CompanyStatus), COUNT(*) from " + tableName + " WHERE CompanyStatus != '' GROUP BY CompanyStatus;";
                cmd = new MySqlCommand(query, conn);
                sda = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dtFilters = new DataTable();
                sda.Fill(dtFilters);

                if (dtFilters.Rows.Count > 0)
                {
                    cstatus.Items.Clear();
                    cstatus.Items.Add(new ListItem("Please Choose a Company Status", ""));

                    foreach (DataRow row in dtFilters.Rows)
                    {
                        string company_status = (string)row[0];
                        string company_status_count = (string)row[1].ToString();
                        cstatus.Items.Add(new ListItem(company_status + "( " + company_status_count + " )", company_status));

                    }

                }

                //filling company category
                query = "Select DISTINCT(CompanyCategory),COUNT(*) from " + tableName + " WHERE CompanyCategory != '' GROUP BY CompanyCategory;";
                cmd = new MySqlCommand(query, conn);
                sda = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dtFilters = new DataTable();
                sda.Fill(dtFilters);

                if (dtFilters.Rows.Count > 0)
                {
                    ccategory.Items.Clear();
                    ccategory.Items.Add(new ListItem("Please Choose a Company Category", ""));

                    foreach (DataRow row in dtFilters.Rows)
                    {
                        string company_status = (string)row[0];
                        string company_status_count = (string)row[1].ToString();
                        ccategory.Items.Add(new ListItem(company_status + "( " + company_status_count + " )", company_status));

                    }

                }

                //filling SIC Code
                query = "Select DISTINCT(SICCode_SicText_1), COUNT(*) from " + tableName + " WHERE SICCode_SicText_1 != ''  GROUP BY SICCode_SicText_1;";
                cmd = new MySqlCommand(query, conn);
                sda = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dtFilters = new DataTable();
                sda.Fill(dtFilters);

                if (dtFilters.Rows.Count > 0)
                {
                    siccode.Items.Clear();
                    siccode.Items.Add(new ListItem("Please Choose a SIC Code", ""));

                    foreach (DataRow row in dtFilters.Rows)
                    {
                        string company_status = (string)row[0];
                        string company_status_count = (string)row[1].ToString();
                        siccode.Items.Add(new ListItem(company_status + "( " + company_status_count + " )", company_status));

                    }

                }

                //filling COMPANY CONUNTRY
                query = "Select DISTINCT(RegAddress_Country), COUNT(*) from " + tableName + " WHERE RegAddress_Country != ''   GROUP BY RegAddress_Country;";
                cmd = new MySqlCommand(query, conn);
                sda = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dtFilters = new DataTable();
                sda.Fill(dtFilters);

                if (dtFilters.Rows.Count > 0)
                {
                    cCountry.Items.Clear();
                    cCountry.Items.Add(new ListItem("Please Choose a Country", ""));

                    foreach (DataRow row in dtFilters.Rows)
                    {
                        string company_status = (string)row[0];
                        string company_status_count = (string)row[1].ToString();
                        cCountry.Items.Add(new ListItem(company_status + "( " + company_status_count + " )", company_status));

                    }

                }

                //filling NUMMORT CHARGES
                query = "Select DISTINCT(Mortgages_NumMortCharges), COUNT(*) from " + tableName + " WHERE Mortgages_NumMortCharges != ''   GROUP BY Mortgages_NumMortCharges;";
                cmd = new MySqlCommand(query, conn);
                sda = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dtFilters = new DataTable();
                sda.Fill(dtFilters);

                if (dtFilters.Rows.Count > 0)
                {
                    cNumMortCharges.Items.Clear();
                    cNumMortCharges.Items.Add(new ListItem("Please Choose NumMort Charges", ""));

                    foreach (DataRow row in dtFilters.Rows)
                    {
                        string company_status = (string)row[0];
                        string company_status_count = (string)row[1].ToString();
                        cNumMortCharges.Items.Add(new ListItem(company_status + "( " + company_status_count + " )", company_status));

                    }

                }

                //filling NUMMORT Outstanding
                query = "Select DISTINCT(Mortgages_NumMortOutstanding), COUNT(*) from " + tableName + " WHERE Mortgages_NumMortOutstanding != ''   GROUP BY Mortgages_NumMortOutstanding;";
                cmd = new MySqlCommand(query, conn);
                sda = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dtFilters = new DataTable();
                sda.Fill(dtFilters);

                if (dtFilters.Rows.Count > 0)
                {
                    cNumMortOutstanding.Items.Clear();
                    cNumMortOutstanding.Items.Add(new ListItem("Please Choose NumMort Outstanding", ""));

                    foreach (DataRow row in dtFilters.Rows)
                    {
                        string company_status = (string)row[0];
                        string company_status_count = (string)row[1].ToString();
                        cNumMortOutstanding.Items.Add(new ListItem(company_status + "( " + company_status_count + " )", company_status));

                    }

                }

                //filling NUMMORT Satisfied
                query = "Select DISTINCT(Mortgages_NumMortPartSatisfied), COUNT(*) from " + tableName + " WHERE Mortgages_NumMortPartSatisfied != ''   GROUP BY Mortgages_NumMortPartSatisfied;";
                cmd = new MySqlCommand(query, conn);
                sda = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                dtFilters = new DataTable();
                sda.Fill(dtFilters);

                if (dtFilters.Rows.Count > 0)
                {
                    cNumMortSatisfied.Items.Clear();
                    cNumMortSatisfied.Items.Add(new ListItem("Please Choose NumMort Satisfied", ""));

                    foreach (DataRow row in dtFilters.Rows)
                    {
                        string company_status = (string)row[0];
                        string company_status_count = (string)row[1].ToString();
                        cNumMortSatisfied.Items.Add(new ListItem(company_status + "( " + company_status_count + " )", company_status));

                    }

                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            else
            {
                filtersNow.Visible = false;
            }

        }

        protected void viewtab_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            viewtab.PageIndex = e.NewPageIndex;
            viewtab.DataSource = dtView;
            viewtab.DataBind();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {

            string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = strConnString;
            MySqlCommand cmd = new MySqlCommand();


            //disable the button
            btnDownload.Enabled = false;

            ////downloading data from CH website
            //WebClient webClient = new WebClient();
            //webClient.DownloadFile("http://download.companieshouse.gov.uk/BasicCompanyData-2022-12-01-part7_7.zip", @"d:\newFile.zip");

            ////extracting data into a new folder
            //string zipPath = @"d:\newFile.zip";
            //string extractPath = @"d:";
            //System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);

            string fileName = @"d:\BasicCompanyData-2022-12-01-part7_7.csv";



            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string query = "";

            ////truncate raw_data_landing
            //query = "TRUNCATE TABLE raw_data_landing";
            //cmd = new MySqlCommand(query, conn);
            //cmd.ExecuteNonQuery();

            ////insert from CSV to raw_data_landing
            //query = "LOAD DATA INFILE '" + fileName.ToString() + "' INTO TABLE raw_data_landing FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\"'; ";
            //cmd = new MySqlCommand(query, conn);
            //cmd.ExecuteNonQuery();

            ////delete first row from raw_data_landing
            //query = "DELETE FROM raw_data_landing WHERE CompanyName = 'CompanyName';";
            //cmd = new MySqlCommand(query, conn);
            //cmd.ExecuteNonQuery();

            ////insert into raw_Data from raw_data_landing
            //query = "INSERT INTO raw_data SELECT `CompanyName`, `CompanyNumber`, `RegAddress_AddressLine1`, `RegAddress_AddressLine2`, `RegAddress_PostTown`, `RegAddress_County`, `RegAddress_Country`, `RegAddress_PostCode`, `CompanyCategory`, `CompanyStatus`, `CountryOfOrigin`, `IncorporationDate`, `Mortgages_NumMortCharges`, `Mortgages_NumMortOutstanding`, `Mortgages_NumMortPartSatisfied`, `Mortgages_NumMortSatisfied`, `SICCode_SicText_1`, `SICCode_SicText_2`, `SICCode_SicText_3`, `SICCode_SicText_4`, `URI` from raw_data_landing";
            //cmd = new MySqlCommand(query, conn);
            //cmd.ExecuteNonQuery();


            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('File(s) Downloaded and Uploaded to DB Successfully');", true);

            //enable the button
            btnDownload.Enabled = true;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {

            string filterSICCode = siccode.SelectedValue.ToString().Trim();
            string filterStatus = cstatus.SelectedValue.ToString().Trim();
            string filterCategory = ccategory.SelectedValue.ToString().Trim();
            string filterCountry = cCountry.SelectedValue.ToString().Trim();
            string filterMortCharges = cNumMortCharges.SelectedValue.ToString().Trim();
            string filterMortOutstanding = cNumMortOutstanding.SelectedValue.ToString().Trim();
            string filterMortSatisfied = cNumMortSatisfied.SelectedValue.ToString().Trim();
            string filterCompName = cCompName.Value.ToString().Trim();
            string filterCompNum = cCompNum.Value.ToString().Trim();
            string filterPostCode = cPostCode.Value.ToString().Trim();
            string filterCompAddress = cAddress.Value.ToString().Trim();
            string filterPostTown = cPostTown.Value.ToString().Trim();
            string filterCounty = cCounty.Value.ToString().Trim();


            Boolean isCheck = false;

            if (filterSICCode != "" || filterStatus != "" || filterCategory != "" || filterCountry != "" || filterMortCharges != "" || filterMortOutstanding != "" || filterMortSatisfied != "" || filterCompName != "" || filterCompNum != "" || filterPostCode != "" || filterCompAddress != "" || filterPostTown!= "" || filterCounty != "")
            {
                isCheck = true;
            }



            string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = strConnString;
            MySqlCommand cmd = new MySqlCommand();


            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string tbNameNow = Session["username"] + "_filters";

            string query = "DROP TABLE IF EXISTS " + tbNameNow + ";";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "CREATE TABLE " + tbNameNow + " (CompanyNumber varchar(255));";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();


            query = "INSERT INTO " + tbNameNow +
               " SELECT CompanyNumber FROM raw_data WHERE SICCode_SicText_1 = '" + filterSICCode + "' OR CompanyCategory = '" + filterCategory + "' " + "OR CompanyStatus = '" + filterStatus + "';";

            string selectQuery = "";

            if (isCheck)
            {
                selectQuery = "SELECT CompanyNumber FROM raw_data WHERE ";

                if (filterSICCode != "")
                {
                    selectQuery += " SICCode_SicText_1 = '" + filterSICCode + "' AND ";
                }
                if (filterCategory != "")
                {
                    selectQuery += " CompanyCategory = '" + filterCategory + "' AND ";
                }
                if (filterStatus != "")
                {
                    selectQuery += " CompanyStatus = '" + filterStatus + "' AND ";
                }
                if (filterCountry != "")
                {
                    selectQuery += " RegAddress_County = '" + filterCountry + "' AND ";
                }
                if (filterMortCharges != "")
                {
                    selectQuery += " Mortgages_NumMortCharges = '" + filterMortCharges + "' AND ";
                }
                if (filterMortOutstanding != "")
                {
                    selectQuery += " Mortgages_NumMortOutstanding = '" + filterMortOutstanding + "' AND ";
                }
                if (filterMortSatisfied != "")
                {
                    selectQuery += " Mortgages_NumMortPartSatisfied = '" + filterMortSatisfied + "' AND";
                }
                if (filterCompName != "")
                {
                    string[] compNames = filterCompName.Split(',');
                    string newCompanies = "";
                    foreach (string compName in compNames)
                    {
                        newCompanies += "\'" + compName.Trim() + "\',";
                    }

                    if (newCompanies.EndsWith(","))
                    {
                        newCompanies = newCompanies.Substring(0, newCompanies.LastIndexOf(","));
                    }
                    //string filterCompaniesValues = filterCompName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    selectQuery += " CompanyName IN (" + newCompanies + ") AND ";
                }
                if (filterCompNum != "")
                {
                    string[] compNames = filterCompNum.Split(',');
                    string newCompanies = "";
                    foreach (string compName in compNames)
                    {
                        newCompanies += "\'" + compName.Trim() + "\',";
                    }

                    if (newCompanies.EndsWith(","))
                    {
                        newCompanies = newCompanies.Substring(0, newCompanies.LastIndexOf(","));
                    }
                    //string filterCompaniesValues = filterCompName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    selectQuery += " CompanyNumber IN (" + newCompanies + ") AND ";
                }
                if (filterCounty != "")
                {
                    string[] compNames = filterCounty.Split(',');
                    string newCompanies = "";
                    foreach (string compName in compNames)
                    {
                        newCompanies += "\'" + compName.Trim() + "\',";
                    }

                    if (newCompanies.EndsWith(","))
                    {
                        newCompanies = newCompanies.Substring(0, newCompanies.LastIndexOf(","));
                    }
                    //string filterCompaniesValues = filterCompName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    selectQuery += " RegAddress_County IN (" + newCompanies + ") AND ";
                }
                if (filterCompAddress != "")
                {
                    string[] compNames = filterCompAddress.Split(',');
                    string newCompanies = "";
                    foreach (string compName in compNames)
                    {
                        newCompanies += "\'" + compName.Trim() + "\',";
                    }

                    if (newCompanies.EndsWith(","))
                    {
                        newCompanies = newCompanies.Substring(0, newCompanies.LastIndexOf(","));
                    }
                    //string filterCompaniesValues = filterCompName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    selectQuery += " RegAddress_AddressLine1 IN (" + newCompanies + ") AND ";
                }
                if (filterPostTown != "")
                {
                    string[] compNames = filterPostTown.Split(',');
                    string newCompanies = "";
                    foreach (string compName in compNames)
                    {
                        newCompanies += "\'" + compName.Trim() + "\',";
                    }

                    if (newCompanies.EndsWith(","))
                    {
                        newCompanies = newCompanies.Substring(0, newCompanies.LastIndexOf(","));
                    }
                    //string filterCompaniesValues = filterCompName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    selectQuery += " RegAddress_PostTown IN (" + newCompanies + ") AND ";
                }
                if (filterPostCode != "")
                {
                    string[] compNames = filterPostCode.Split(',');
                    string newCompanies = "";
                    foreach (string compName in compNames)
                    {
                        newCompanies += "\'" + compName.Trim() + "\',";
                    }

                    if (newCompanies.EndsWith(","))
                    {
                        newCompanies = newCompanies.Substring(0, newCompanies.LastIndexOf(","));
                    }
                    //string filterCompaniesValues = filterCompName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    selectQuery += " RegAddress_PostCode IN (" + newCompanies + ")";
                }
                
            }
            else
            {
                selectQuery = "SELECT CompanyNumber FROM raw_data;";
            }

            if (selectQuery.EndsWith(" AND "))
            {
                selectQuery = selectQuery.Substring(0, selectQuery.LastIndexOf(" AND "));
            }

            query = "INSERT INTO " + tbNameNow + " " + selectQuery;

            cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Filter Applied');", true);

            Response.Redirect("searchFilter.aspx");

        }

    }
}