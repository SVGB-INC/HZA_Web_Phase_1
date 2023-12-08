using ClosedXML.Excel;
using CompaniesHouse;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Charges;
using CompaniesHouse.Response.Search.CompanySearch;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HZA_Web_Phase_1
{
    public partial class searchFilter : System.Web.UI.Page
    {
        int id = 0;

        protected static int retryCount = 0;

        protected static string parentDirectory = System.IO.Directory.GetParent(Environment.CurrentDirectory.ToString()).FullName;

        public static DataTable dtSenderMails = new DataTable();

        public static BackgroundWorker bw = new BackgroundWorker();

        public static string[] companyInfo;

        protected static string api_key = "c248f45a-10b4-4d60-a8b6-f2ad496eb560";

        //protected static string api_key = "NA";

        protected static string sicCode = null;

        protected static string stopFlag = "false";

        public static ManualResetEvent mre = new ManualResetEvent(false);

        protected static PauseTokenSource pts = new PauseTokenSource();

        protected static CancellationTokenSource cancelSource = new CancellationTokenSource();

        public DataTable dtTempDate = new DataTable();

        public DataSet dsTempSet = new DataSet();

        public DateTime randomDefaultDate = DateTime.Parse("1/1/1800");

        protected static bool isFilter = false;

        protected static DataTable dtSingleZero = new DataTable();
        protected static DataTable dtSingleCharges = new DataTable();
        DataRow dr = null;

        protected static string messageNow = "";
        protected static int messageInt = 0;

        protected static string content;
        protected static bool inProcess = false;
        protected static bool processComplete = false;
        protected static string processCompleteMsg = "Finished Processing.";

        protected static int totalCompanies = 0000;
        protected static int zeroCom = 0000;
        protected static int chargeCom = 0000;

        protected static string tbNameNow;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");

            }
            else
            {
                string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = strConnString;
                MySqlCommand cmd = new MySqlCommand();

                string query = "SELECT COUNT(*) FROM " + Session["username"] + "_filters";
                                cmd = new MySqlCommand(query, conn);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                int countTotData = int.Parse(cmd.ExecuteScalar().ToString());

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                dataCompanies.Text = countTotData.ToString();

                //if (string.IsNullOrWhiteSpace(Request.QueryString["Parameter"].ToString()))
                //{
                //    Response.Redirect("raw-data.aspx");
                //}

                //tbNameNow = Request.QueryString["Parameter"].ToString();
            }
        }


        protected async void Timer1_Tick(object sender, EventArgs e)
        {

            singleZeroTab.DataSource = dtSingleZero;
            singleZeroTab.DataBind();

            singleChargesTab.DataSource = dtSingleCharges;
            singleChargesTab.DataBind();

            int totCount = dtSingleCharges.AsEnumerable().Select(r => r.Field<string>("compNumberMain")).Distinct().Count() + dtSingleZero.Rows.Count;

            lbSingleTot.Text = totCount.ToString();
            lbSingleZero.Text = dtSingleZero.Rows.Count.ToString();
            lbSingleCharges.Text = dtSingleCharges.AsEnumerable().Select(r => r.Field<string>("compNumberMain")).Distinct().Count().ToString();

            messageInt++;
            lbMessage.Text = messageInt + " | " + messageNow;

            for (int i = 0; i < singleZeroTab.Rows.Count; i++)
            {

                ((HyperLink)singleZeroTab.Rows[i].Cells[0].Controls[0]).NavigateUrl = ("addInfo.aspx?Parameter=" +
                    ("000000") + "|" +
                    ((HyperLink)singleZeroTab.Rows[i].Cells[1].Controls[0]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                    ((HyperLink)singleZeroTab.Rows[i].Cells[2].Controls[0]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                    (singleZeroTab.Rows[i].Cells[3]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                    "000000");

                ((HyperLink)singleZeroTab.Rows[i].Cells[1].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + ((HyperLink)singleZeroTab.Rows[i].Cells[1].Controls[0]).Text.ToString() + "&page=1");

                ((HyperLink)singleZeroTab.Rows[i].Cells[2].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + ((HyperLink)singleZeroTab.Rows[i].Cells[2].Controls[0]).Text.ToString() + "&page=1");

                ((HyperLink)singleZeroTab.Rows[i].Cells[10].Controls[0]).NavigateUrl = ((HyperLink)singleZeroTab.Rows[i].Cells[10].Controls[0]).Text.ToString();

            }

            for (int i = 0; i < singleChargesTab.Rows.Count; i++)
            {

                //((HyperLink)singleChargesTab.Rows[i].Cells[0].Controls[0]).NavigateUrl = ("addInfo.aspx?Parameter=" +
                //   ("000000") + "|" +
                //   ((HyperLink)singleChargesTab.Rows[i].Cells[1].Controls[0]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                //   ((HyperLink)singleChargesTab.Rows[i].Cells[2].Controls[0]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                //   (singleChargesTab.Rows[i].Cells[3]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" + "000000");


                ((HyperLink)singleChargesTab.Rows[i].Cells[1].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + ((HyperLink)singleChargesTab.Rows[i].Cells[1].Controls[0]).Text.ToString() + "&page=1");

                ((HyperLink)singleChargesTab.Rows[i].Cells[2].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + ((HyperLink)singleChargesTab.Rows[i].Cells[2].Controls[0]).Text.ToString() + "&page=1");

                ((HyperLink)singleChargesTab.Rows[i].Cells[10].Controls[0]).NavigateUrl = ((HyperLink)singleChargesTab.Rows[i].Cells[10].Controls[0]).Text.ToString();

            }



        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        public class PauseTokenSource
        {
            private readonly object m_lockObject = new Object();
            bool m_paused = false; // could use m_resumeRequest as flag too

            internal static readonly Task s_completedTask = Task.FromResult(true);
            private TaskCompletionSource<bool> m_pauseResponse;
            private TaskCompletionSource<bool> m_resumeRequest;

            public void Pause()
            {
                lock (m_lockObject)
                {
                    if (m_paused)
                        return;
                    m_paused = true;
                    m_pauseResponse = null;
                    m_resumeRequest = new TaskCompletionSource<bool>();
                }
            }

            public void Resume()
            {
                TaskCompletionSource<bool> resumeRequest = null;

                lock (m_lockObject)
                {
                    if (!m_paused)
                        return;
                    m_paused = false;
                    resumeRequest = m_resumeRequest;
                    m_resumeRequest = null;
                }

                resumeRequest.TrySetResult(true);
            }

            public Task WaitWhilePausedAsync()
            {
                lock (m_lockObject)
                {
                    if (!m_paused)
                        return s_completedTask;
                    return m_resumeRequest.Task;
                }
            }

            // pause with feedback
            // that the producer task has reached the paused state

            public Task PauseWithResponseAsync()
            {
                Task responseTask = null;

                lock (m_lockObject)
                {
                    if (m_paused)
                        return m_pauseResponse.Task;
                    m_paused = true;
                    m_pauseResponse = new TaskCompletionSource<bool>();
                    m_resumeRequest = new TaskCompletionSource<bool>();
                    responseTask = m_pauseResponse.Task;
                }

                return responseTask;
            }

            public Task WaitWhilePausedWithResponseAsyc()
            {
                Task resumeTask = null;
                TaskCompletionSource<bool> response = null;

                lock (m_lockObject)
                {
                    if (!m_paused)
                        return s_completedTask;
                    response = m_pauseResponse;
                    resumeTask = m_resumeRequest.Task;
                }

                response.TrySetResult(true);
                return resumeTask;
            }

            public bool IsPaused
            {
                get
                {
                    lock (m_lockObject)
                        return m_paused;
                }
            }

            public PauseToken Token { get { return new PauseToken(this); } }
        }

        public struct PauseToken
        {
            private readonly PauseTokenSource m_source;
            public PauseToken(PauseTokenSource source) { m_source = source; }

            public bool IsPaused { get { return m_source != null && m_source.IsPaused; } }

            public Task WaitWhilePausedAsync()
            {
                return IsPaused ?
                        m_source.WaitWhilePausedAsync() :
                        PauseTokenSource.s_completedTask;
            }

            public Task WaitWhilePausedWithResponseAsyc()
            {
                return IsPaused ?
                        m_source.WaitWhilePausedWithResponseAsyc() :
                        PauseTokenSource.s_completedTask;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {


            processComplete = false;
            Timer1.Enabled = true;

            cancelSource = new CancellationTokenSource();

            var task = singleSearch(pts.Token, cancelSource.Token).ConfigureAwait(false);



        }

        private async Task singleSearch(PauseToken pause, CancellationToken cancellationToken)
        {

            string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = strConnString;

            
            MySqlCommand cmd = new MySqlCommand();

            string tbName = Session["username"] + "_final";
            string query = "";

            //creating tables for user specific user
            try
            {

                query = "DROP TABLE IF EXISTS " + tbName + ";";

                cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                query = "CREATE TABLE " + tbName.Trim() + "(Sr_No varchar(255) NOT NULL," +
                  "Company_Name varchar(255) NOT NULL, " +
                  "Company_Name_Link varchar(255) NOT NULL, " +
                  "Company_Number varchar(255) NOT NULL, " +
                  "Company_Number_Link varchar(255) NOT NULL, " +
                  "Registered_Address varchar(255) NOT NULL, " +
                  "Charges varchar(255) NOT NULL, " +
                  "Date_Creation varchar(255) NOT NULL, " +
                  "Status varchar(255) NOT NULL, " +
                  "Persons_Entitled varchar(255) NOT NULL, " +
                  "Brief_Description varchar(1000) NOT NULL, " +
                  "Charge_Code varchar(255) NOT NULL, " +
                  "Company_Link varchar(255) NOT NULL) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4;";

                cmd = new MySqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }



            try
            {


                // string[] companyList = editList.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                query = "SELECT CompanyNumber FROM " + Session["username"] + "_filters"; 
                cmd = new MySqlCommand(query, conn);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                MySqlDataReader mdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                List<string> list = new List<string>();
                while (mdr.Read())
                {
                    list.Add(mdr.GetString(0));
                }

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                
                

                string[] companyList = list.ToArray<string>();

                
                int companiesTot = companyList.Length;
                int companiesNow = 1;

                int srNO = 0;
                int srNOChargesNew = 0;

                bool tryAgain = true;

                dtSingleCharges = new DataTable();
                dtSingleZero = new DataTable();

                //zero charges table
                dtSingleZero.Columns.Add(new DataColumn("srNO", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("compName", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("compNumberMain", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("regAddress", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("charges_Main", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("dtCreate", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("status_Main", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("pEntitle", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("desc", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("cCode", typeof(string)));
                dtSingleZero.Columns.Add(new DataColumn("companyLink", typeof(string)));


                //charges table
                dtSingleCharges.Columns.Add(new DataColumn("srNO", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("compName", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("compNumberMain", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("regAddress", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("charges_Main", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("dtCreate", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("status_Main", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("pEntitle", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("desc", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("cCode", typeof(string)));
                dtSingleCharges.Columns.Add(new DataColumn("companyLink", typeof(string)));


                for (int i = 0; i < companyList.Length; i++)
                {

                    companiesNow++;

                    CompaniesHouseClientResponse<CompaniesHouse.Response.Search.AllSearch.AllSearch> result = null;
                    CompaniesHouseClientResponse<CompaniesHouse.Response.Charges.Charges> charges_company_new = null;

                    while (tryAgain)
                    {

                        try
                        {

                            if (i % 6 == 0)
                            {
                                await Task.Delay(7431).ConfigureAwait(false);
                            }
                            string nameToSearchFor = companyList[i].ToString().Trim().TrimEnd().TrimStart();

                            messageNow = "Downloading for Company from API: " + nameToSearchFor;

                            var settings = new CompaniesHouseSettings(api_key);

                            using (var clientNew = new CompaniesHouseClient(settings))
                            {
                                var request = new SearchRequest()
                                {
                                    Query = nameToSearchFor,
                                    StartIndex = 0,
                                    ItemsPerPage = 20
                                };

                                result = await clientNew.SearchAllAsync(request);

                                string codeName = nameToSearchFor;

                                foreach (Company item in result.Data.Items.Where(t => t as Company != null))
                                {
                                    codeName = item.CompanyNumber.ToString();

                                }

                                charges_company_new = await clientNew.GetChargesListAsync(codeName);

                                //charges_company_new = clientNew.GetChargesListAsync(nameToSearchFor).Result;
                                //Thread.Sleep(3000);

                            }
                            if (result is null)
                            {
                                messageNow = "API sent no data. Retrying for company: " + nameToSearchFor;
                                await Task.Delay(8970);
                            }
                            else
                            {
                                tryAgain = false;
                                messageNow = "Successfully Downloaded for Company from API: " + nameToSearchFor;
                            }
                            //tryAgain = false;
                        }
                        catch (Exception e)
                        {

                            if (e.ToString().Contains("429"))
                            {
                                messageNow = "Too Many Requests. Will Wait." + " | Company: " + companyList[i].ToString().Trim().TrimEnd().TrimStart();
                                await Task.Delay(146789);

                            }
                            else
                            {
                                if (retryCount <= 2)
                                {
                                    retryCount = retryCount + 1;
                                    messageNow = "Retrying Download for Company from API: " + companyList[i].ToString().Trim().TrimEnd().TrimStart();
                                    await Task.Delay(5700);
                                    //tryAgain = false;
                                    //continue;
                                }
                                else
                                {
                                    retryCount = 0;
                                    messageNow = "Retrying Download for Company from API: " + companyList[i].ToString().Trim().TrimEnd().TrimStart();
                                    await Task.Delay(5700);
                                    tryAgain = false;
                                    //continue;
                                }

                                //Console.WriteLine(e.ToString());
                                //tryAgain = true;
                            }
                            continue;
                        }

                    }
                    tryAgain = true;


                  
                    if (result is null || result.ToString().Contains("429"))
                    {
                        messageNow = "Null Data for Company: " + companyList[i].ToString().Trim().TrimEnd().TrimStart();
                        await Task.Delay(4700);
                    }
                    else
                    {
                        if (charges_company_new.Data is null)
                        {
                            foreach (Company item in result.Data.Items.Where(t => t as Company != null))
                            {
                                try
                                {
                                    string addressNow = "";

                                    if (item.Address is null)
                                    {
                                        addressNow = "NA";
                                    }
                                    else
                                    {

                                        addressNow += item.Address.Premises is null ? "" : item.Address.Premises.ToString();
                                        addressNow += item.Address.AddressLine1 is null ? "" : ", ";
                                        addressNow += item.Address.AddressLine1 is null ? "" : item.Address.AddressLine1.ToString();
                                        addressNow += item.Address.Locality is null ? "" : ", ";
                                        addressNow += item.Address.Locality is null ? "" : item.Address.Locality.ToString();
                                        addressNow += item.Address.AddressLine2 is null ? "" : ", ";
                                        addressNow += item.Address.AddressLine2 is null ? "" : item.Address.AddressLine2.ToString();
                                        addressNow += item.Address.Country is null ? "" : ", ";
                                        addressNow += item.Address.Country is null ? "" : item.Address.Country.ToString();
                                        addressNow += item.Address.Region is null ? "" : ", ";
                                        addressNow += item.Address.Region is null ? "" : item.Address.Region.ToString();
                                        addressNow += item.Address.PostalCode is null ? "" : ", ";
                                        addressNow += item.Address.PostalCode is null ? "" : item.Address.PostalCode.ToString();
                                    }

                                    srNO++;

                                    dr = dtSingleZero.NewRow();

                                    dr["srNO"] = srNO.ToString();
                                    dr["compName"] = item.Title is null ? "NA" : item.Title.ToString();
                                    dr["compNumberMain"] = item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString();
                                    dr["regAddress"] = addressNow is null ? "NA" : addressNow.ToString();
                                    dr["charges_Main"] = "0".ToString();
                                    dr["dtCreate"] = "NA".ToString();
                                    dr["status_Main"] = item.CompanyStatus.ToString();
                                    dr["pEntitle"] = "NA".ToString();
                                    dr["desc"] = "NA".ToString();
                                    dr["cCode"] = "NA".ToString();
                                    dr["companyLink"] = "https://find-and-update.company-information.service.gov.uk/company/" + (item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString());

                                    dtSingleZero.Rows.Add(dr);

                                    
                                }
                                catch
                                {
                                    break;
                                }

                            }
                            //dgList.Rows.Add(" ", " ", " ", " ", " ", " ", " ");
                        }
                        else
                        {
                            string count_Charges = charges_company_new.Data.TotalCount.ToString();

                            foreach (Charge charge_Company in charges_company_new.Data.Items.Where(t => t as Charge != null))
                            {

                                foreach (Company item in result.Data.Items.Where(t => t as Company != null))
                                {
                                    try
                                    {


                                        string addressNow = "";

                                        if (item.Address is null)
                                        {
                                            addressNow = "NA";
                                        }
                                        else
                                        {

                                            addressNow += item.Address.Premises is null ? "" : item.Address.Premises.ToString();
                                            addressNow += item.Address.AddressLine1 is null ? "" : ", ";
                                            addressNow += item.Address.AddressLine1 is null ? "" : item.Address.AddressLine1.ToString();
                                            addressNow += item.Address.Locality is null ? "" : ", ";
                                            addressNow += item.Address.Locality is null ? "" : item.Address.Locality.ToString();
                                            addressNow += item.Address.AddressLine2 is null ? "" : ", ";
                                            addressNow += item.Address.AddressLine2 is null ? "" : item.Address.AddressLine2.ToString();
                                            addressNow += item.Address.Country is null ? "" : ", ";
                                            addressNow += item.Address.Country is null ? "" : item.Address.Country.ToString();
                                            addressNow += item.Address.Region is null ? "" : ", ";
                                            addressNow += item.Address.Region is null ? "" : item.Address.Region.ToString();
                                            addressNow += item.Address.PostalCode is null ? "" : ", ";
                                            addressNow += item.Address.PostalCode is null ? "" : item.Address.PostalCode.ToString();
                                        }

                                        srNOChargesNew++;

                                        dr = dtSingleCharges.NewRow();

                                        dr["srNO"] = srNOChargesNew.ToString();
                                        dr["compName"] = item.Title is null ? "NA" : item.Title.ToString();
                                        dr["compNumberMain"] = item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString();
                                        dr["regAddress"] = addressNow is null ? "NA" : addressNow.ToString();
                                        dr["charges_Main"] = count_Charges is null ? "NA" : count_Charges.ToString();
                                        dr["dtCreate"] = charge_Company.CreatedOn is null ? "NA" : DateTime.Parse(charge_Company.CreatedOn.Value.ToShortDateString()).ToString("yyyy -MM-dd").ToString();
                                        dr["status_Main"] = charge_Company.Status.ToString();
                                        dr["pEntitle"] = charge_Company.PersonsEntitled is null ? "NA" : charge_Company.PersonsEntitled[0] is null ? "NA" : charge_Company.PersonsEntitled[0].Name is null ? "NA" : charge_Company.PersonsEntitled[0].Name.ToString();
                                        dr["desc"] = charge_Company.Particular is null ? "NA" : charge_Company.Particular.Description is null ? "NA" : charge_Company.Particular.Description.ToString();
                                        dr["cCode"] = charge_Company.ChargeCode is null ? "NA" : charge_Company.ChargeCode.ToString();
                                        dr["companyLink"] = "https://find-and-update.company-information.service.gov.uk/company/" + (item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString());

                                        dtSingleCharges.Rows.Add(dr);

                                        
                                    }
                                    catch
                                    {
                                        break;
                                    }


                                }

                            }
                            //dgListCharges.Rows.Add(" ", " ", " ", " ", " ", " ", " ");
                        }
                    }

                    await pause.WaitWhilePausedWithResponseAsyc();
                    cancellationToken.ThrowIfCancellationRequested();

                }

               

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
                throw;
            }

            messageNow = "All Data Downloaded.";

        }



        protected void GridView_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            singleZeroTab.PageIndex = e.NewPageIndex;
            singleZeroTab.DataSource = dtSingleZero;
            singleZeroTab.DataBind();
        }

        protected void GridViewCharges_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            singleChargesTab.PageIndex = e.NewPageIndex;
            singleChargesTab.DataSource = dtSingleCharges;
            singleChargesTab.DataBind();
        }

        int size = 0;
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListNew.SelectedItem.Text != "0")
            {
                size = int.Parse(DropDownListNew.SelectedItem.Value.ToString());
                singleChargesTab.PageSize = size;
                singleZeroTab.PageSize = size;

                singleZeroTab.DataSource = dtSingleZero;
                singleZeroTab.DataBind();

                singleChargesTab.DataSource = dtSingleCharges;
                singleChargesTab.DataBind();

            }
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {


            DataTable dt = new DataTable();
            dt = dtSingleCharges;

            DataColumn Col = dt.Columns.Add("Credit_Safe_Link", System.Type.GetType("System.String"));
            Col.SetOrdinal(4);

            foreach (DataRow dr in dt.Rows)
            {
                dr["Credit_Safe_Link"] = "https://app.creditsafe.com/search?countries=GB&limit=15&name=" + (dr["compNumberMain"] is null ? "NA" : dr["compNumberMain"].ToString().Trim().ToString()) + "&page=1".ToString();

            }

            dt.AcceptChanges();



            Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
            Font font13 = FontFactory.GetFont("Candara", 13);
            Font font18 = FontFactory.GetFont("Candara", 18);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, System.Web.HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();

                if (dt.Rows.Count > 0)
                {
                    PdfPTable PdfTable = new PdfPTable(1);
                    PdfTable.TotalWidth = 200f;
                    PdfTable.LockedWidth = true;

                    PdfPCell PdfPCell = new PdfPCell(new Phrase(new Chunk("Company Details", font18)));
                    PdfPCell.Border = Rectangle.NO_BORDER;
                    PdfTable.AddCell(PdfPCell);
                    DrawLine(writer, 25f, pdfDoc.Top - 30f, pdfDoc.PageSize.Width - 25f, pdfDoc.Top - 30f, new BaseColor(System.Drawing.Color.Red));
                    pdfDoc.Add(PdfTable);

                    PdfTable = new PdfPTable(dt.Columns.Count);
                    PdfTable.SpacingBefore = 20f;
                    for (int columns = 0; columns <= dt.Columns.Count - 1; columns++)
                    {
                        PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Columns[columns].ColumnName, font18)));
                        PdfTable.AddCell(PdfPCell);
                    }

                    for (int rows = 0; rows <= dt.Rows.Count - 1; rows++)
                    {
                        for (int column = 0; column <= dt.Columns.Count - 1; column++)
                        {
                            PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString(), font13)));
                            PdfTable.AddCell(PdfPCell);
                        }
                    }
                    pdfDoc.Add(PdfTable);
                }
                pdfDoc.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=Companies_" + DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Date.Hour.ToString() + DateTime.Now.Date.Minute.ToString() + DateTime.Now.Date.Second.ToString() + DateTime.Now.Date.Millisecond.ToString() + ".pdf");
                System.Web.HttpContext.Current.Response.Write(pdfDoc);
                Response.Flush();
                Response.End();
            }
            catch (DocumentException de)
            {
            }
            // System.Web.HttpContext.Current.Response.Write(de.Message)
            catch (IOException ioEx)
            {
            }
            // System.Web.HttpContext.Current.Response.Write(ioEx.Message)
            catch (Exception ex)
            {
            }
        }



        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }

        protected void btnXLS_Click(object sender, EventArgs e)
        {


            DataTable dtNow = new DataTable();

            dtNow = dtSingleCharges;

            DataColumn Col = dtNow.Columns.Add("Credit_Safe_Link", System.Type.GetType("System.String"));
            Col.SetOrdinal(4);

            foreach (DataRow dr in dtNow.Rows)
            {
                dr["Credit_Safe_Link"] = "https://app.creditsafe.com/search?countries=GB&limit=15&name=" + (dr["compNumberMain"] is null ? "NA" : dr["compNumberMain"].ToString().Trim().ToString()) + "&page=1".ToString();

            }

            dtNow.AcceptChanges();


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dtNow, "Companies");

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=companies.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }



        }

        protected async void btnPause_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            await pts.PauseWithResponseAsync();
        }

        protected void btnResume_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            pts.Resume();

        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            if (stopFlag == "false")
            {
                cancelSource.Cancel();
                cancelSource.Dispose();
                stopFlag = "true";
            }


        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            if (stopFlag == "false")
            {
                cancelSource.Cancel();
                cancelSource.Dispose();
            }
            Response.Redirect("index.aspx");

        }

    }
}