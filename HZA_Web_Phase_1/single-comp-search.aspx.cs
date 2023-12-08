using CompaniesHouse;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Charges;
using CompaniesHouse.Response.Search.CompanySearch;
using HtmlAgilityPack;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Configuration;


namespace HZA_Web_Phase_1
{
    public partial class single_comp_search : System.Web.UI.Page
    {
        int id = 0;

        protected static int retryCount = 0;

        protected static string parentDirectory = System.IO.Directory.GetParent(Environment.CurrentDirectory.ToString()).FullName;

        public static DataTable dtSenderMails = new DataTable();

        public static BackgroundWorker bw = new BackgroundWorker();

        public static string[] companyInfo;

        //protected static string api_key = "c248f45a-10b4-4d60-a8b6-f2ad496eb560";

        protected static string api_key = "NA";

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

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");

            }
            else
            {
                //userName.Text = Session["username"].ToString();
                lbUserName.Text = Session["username"].ToString();
            }

        }



        protected void ProcessRecords()
        {
            inProcess = true;
            int x = 30; // Loop start value.
            for (int i = x; i > 0; i--)
            {
                Thread.Sleep(1000); // Thread sleep time.
                content = (i * 75).ToString(); // Multiplication of 75.
            }
            processComplete = true;
            content = processCompleteMsg;
        }

        protected async void Timer1_Tick(object sender, EventArgs e)
        {

            string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = strConnString;

            MySqlCommand cmd = new MySqlCommand();

            //string tbName = Session["username"] + "_sic_" + sicList.SelectedValue.ToString().Trim();

            string tbName = "sic_" + sicList.SelectedValue.ToString().Trim();

            //string query = "Select sr_no as srNo, SIC_CODE as sicCodee, Company_Name as compName , " +
            //    " Company_Number as compNumberMain, Registered_Address as regAddress, " +
            //    " Charges as charges_Main, Date_Creation as dtCreate, Status as status_Main," +
            //    " Persons_Entitled as pEntitle, Brief_Description as `desc`, Charge_Code as cCode," +
            //    " Company_Link as companyLink from " + tbName + " where charges <= 0;";
            //cmd = new MySqlCommand(query, conn);
            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            //conn.Open();
            //cmd.ExecuteNonQuery();
            //DataTable dtZeroTemp = new DataTable();
            //sda.Fill(dtZeroTemp);

            //query = "Select sr_no as srNo, SIC_CODE as sicCodee, Company_Name as compName , " +
            //    " Company_Number as compNumberMain, Registered_Address as regAddress, " +
            //    " Charges as charges_Main, Date_Creation as dtCreate, Status as status_Main," +
            //    " Persons_Entitled as pEntitle, Brief_Description as `desc`, Charge_Code as cCode," +
            //    " Company_Link as companyLink from " + tbName + " where charges > 0;";
            //cmd = new MySqlCommand(query, conn);
            //sda = new MySqlDataAdapter(cmd);
            //cmd.ExecuteNonQuery();
            //DataTable dtChargesTemp = new DataTable();
            //sda.Fill(dtChargesTemp);
            //conn.Close();

            //dtSingleCharges
            //dtSingleZero

            messageInt++;
            lbMessage.Text = messageInt + " | " + messageNow;

            singleZeroTab.DataSource = dtSingleZero;
            singleZeroTab.DataBind();

            singleChargesTab.DataSource = dtSingleCharges;
            singleChargesTab.DataBind();


            int totCount = dtSingleCharges.AsEnumerable().Select(r => r.Field<string>("compNumberMain")).Distinct().Count() + dtSingleZero.Rows.Count;

            lbSingleTot.Text = totCount.ToString();

            //lbSingleZero.Text = dtZeroTemp.Rows.Count.ToString();
            lbSingleZero.Text = dtSingleZero.Rows.Count.ToString();

            lbSingleCharges.Text = dtSingleCharges.AsEnumerable().Select(r => r.Field<string>("compNumberMain")).Distinct().Count().ToString();


            for (int i = 0; i < singleZeroTab.Rows.Count; i++)
            {
                //((HyperLink)singleZeroTab.Rows[i].Cells[2].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + dtSingleZero.Rows[i].Field<string>("compName").ToString() + "&page=1");

                //((HyperLink)singleZeroTab.Rows[i].Cells[3].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + dtSingleZero.Rows[i].Field<string>("compNumberMain").ToString() + "&page=1");

                //((HyperLink)singleZeroTab.Rows[i].Cells[11].Controls[0]).NavigateUrl = (dtSingleZero.Rows[i].Field<string>("companyLink").ToString());

                ((HyperLink)singleZeroTab.Rows[i].Cells[0].Controls[0]).NavigateUrl = ("addInfo.aspx?Parameter=" +
                    (singleZeroTab.Rows[i].Cells[1]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                    ((HyperLink)singleZeroTab.Rows[i].Cells[2].Controls[0]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                    ((HyperLink)singleZeroTab.Rows[i].Cells[3].Controls[0]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                    (singleZeroTab.Rows[i].Cells[4]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                    sicList.SelectedItem.ToString().Trim().ToString().Replace(' ', '_').Replace('&', '_') + "|");

                ((HyperLink)singleZeroTab.Rows[i].Cells[2].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + ((HyperLink)singleZeroTab.Rows[i].Cells[2].Controls[0]).Text.ToString() + "&page=1");

                ((HyperLink)singleZeroTab.Rows[i].Cells[3].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + ((HyperLink)singleZeroTab.Rows[i].Cells[3].Controls[0]).Text.ToString() + "&page=1");

                ((HyperLink)singleZeroTab.Rows[i].Cells[11].Controls[0]).NavigateUrl = ((HyperLink)singleZeroTab.Rows[i].Cells[11].Controls[0]).Text.ToString();

            }

            for (int i = 0; i < singleChargesTab.Rows.Count; i++)
            {
                //((HyperLink)singleChargesTab.Rows[i].Cells[2].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + dtSingleCharges.Rows[i].Field<string>("compName").ToString() + "&page=1");

                //((HyperLink)singleChargesTab.Rows[i].Cells[3].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + dtSingleCharges.Rows[i].Field<string>("compNumberMain").ToString() + "&page=1");

                //((HyperLink)singleChargesTab.Rows[i].Cells[11].Controls[0]).NavigateUrl = (dtSingleCharges.Rows[i].Field<string>("companyLink").ToString());

                ((HyperLink)singleChargesTab.Rows[i].Cells[0].Controls[0]).NavigateUrl = ("addInfo.aspx?Parameter=" +
                   (singleChargesTab.Rows[i].Cells[1]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                   ((HyperLink)singleChargesTab.Rows[i].Cells[2].Controls[0]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                   ((HyperLink)singleChargesTab.Rows[i].Cells[3].Controls[0]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                   (singleChargesTab.Rows[i].Cells[4]).Text.ToString().Replace(' ', '_').Replace('&', '_') + "|" +
                   sicList.SelectedItem.ToString().Trim().ToString().Replace(' ', '_').Replace('&', '_') + "|");


                ((HyperLink)singleChargesTab.Rows[i].Cells[2].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + ((HyperLink)singleChargesTab.Rows[i].Cells[2].Controls[0]).Text.ToString() + "&page=1");

                ((HyperLink)singleChargesTab.Rows[i].Cells[3].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + ((HyperLink)singleChargesTab.Rows[i].Cells[3].Controls[0]).Text.ToString() + "&page=1");

                ((HyperLink)singleChargesTab.Rows[i].Cells[11].Controls[0]).NavigateUrl = ((HyperLink)singleChargesTab.Rows[i].Cells[11].Controls[0]).Text.ToString();

            }

            ////database connections

            //messageInt++;
            //lbMessage.Text = messageInt + " | " + messageNow;

            //singleZeroTab.DataSource = dtZeroTemp;
            //singleZeroTab.DataBind();

            //singleChargesTab.DataSource = dtChargesTemp;
            //singleChargesTab.DataBind();


            //int totCount = dtChargesTemp.AsEnumerable().Select(r => r.Field<string>("compNumberMain")).Distinct().Count() + dtZeroTemp.Rows.Count;

            //lbSingleTot.Text = totCount.ToString();

            ////lbSingleZero.Text = dtZeroTemp.Rows.Count.ToString();
            //lbSingleZero.Text = dtSingleZero.Rows.Count.ToString();

            //lbSingleCharges.Text = dtChargesTemp.AsEnumerable().Select(r => r.Field<string>("compNumberMain")).Distinct().Count().ToString();


            //for (int i = 0; i < singleZeroTab.Rows.Count; i++)
            //{
            //    ((HyperLink)singleZeroTab.Rows[i].Cells[2].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + dtZeroTemp.Rows[i].Field<string>("compName").ToString() + "&page=1");

            //    ((HyperLink)singleZeroTab.Rows[i].Cells[3].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + dtZeroTemp.Rows[i].Field<string>("compNumberMain").ToString() + "&page=1");

            //    ((HyperLink)singleZeroTab.Rows[i].Cells[11].Controls[0]).NavigateUrl = (dtZeroTemp.Rows[i].Field<string>("companyLink").ToString());

            //}

            //for (int i = 0; i < singleChargesTab.Rows.Count; i++)
            //{
            //    ((HyperLink)singleChargesTab.Rows[i].Cells[2].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + dtChargesTemp.Rows[i].Field<string>("compName").ToString() + "&page=1");

            //    ((HyperLink)singleChargesTab.Rows[i].Cells[3].Controls[0]).NavigateUrl = ("https://app.creditsafe.com/search?countries=GB&limit=15&name=" + dtChargesTemp.Rows[i].Field<string>("compNumberMain").ToString() + "&page=1");

            //    ((HyperLink)singleChargesTab.Rows[i].Cells[11].Controls[0]).NavigateUrl = (dtChargesTemp.Rows[i].Field<string>("companyLink").ToString());

            //}




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

            //string tbName = Session["username"] + "_sic_" + sicList.SelectedValue.ToString().Trim();
            string tbName = "sic_" + sicList.SelectedValue.ToString().Trim();
            string query = "";

            query = "SELECT user_key FROM user_data where user_name = '" + Session["username"] + "'; ";
            cmd = new MySqlCommand(query, conn);

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            api_key = (cmd.ExecuteScalar().ToString());

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            int sicCount = 0;

            //creating tables for user specific SIC code
            try
            {

                query = "SELECT COUNT(*) FROM information_schema.tables " +
                    "WHERE table_schema = 'hza' AND table_name = '" + tbName + "'; ";

                cmd = new MySqlCommand(query, conn);

                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                int countTable = int.Parse(cmd.ExecuteScalar().ToString());

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }


                if (countTable <= 0)
                {
                    query = "CREATE TABLE " + tbName.Trim() + "(Sr_No varchar(255) NULL," +
                  "SIC_Code varchar(255) NULL," +
                  "Company_Name varchar(255) NULL, " +
                  "Company_Name_Link varchar(255) NULL, " +
                  "Company_Number varchar(255) NULL, " +
                  "Company_Number_Link varchar(255) NULL, " +
                  "Registered_Address varchar(255) NULL, " +
                  "Charges varchar(255) NULL, " +
                  "Date_Creation varchar(255) NULL, " +
                  "Status varchar(255) NULL, " +
                  "Persons_Entitled varchar(255) NULL, " +
                  "Brief_Description varchar(1000) NULL, " +
                  "Charge_Code varchar(255) NULL, " +
                  "Company_Link varchar(255) NULL) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4;";

                    cmd = new MySqlCommand(query, conn);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    cmd.ExecuteNonQuery();

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                }
                else if (countTable > 0)
                {
                    query = "SELECT COUNT(DISTINCT(Company_Number)) from " + tbName + "; ";

                    cmd = new MySqlCommand(query, conn);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    sicCount = int.Parse(cmd.ExecuteScalar().ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }


                }


            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }

            //try
            //{

            //    query = "DROP TABLE IF EXISTS " + tbName + ";";

            //    cmd = new MySqlCommand(query, conn);
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //    query = "CREATE TABLE " + tbName.Trim() + "(Sr_No varchar(255) NULL," +
            //      "SIC_Code varchar(255) NULL," +
            //      "Company_Name varchar(255) NULL, " +
            //      "Company_Name_Link varchar(255) NULL, " +
            //      "Company_Number varchar(255) NULL, " +
            //      "Company_Number_Link varchar(255) NULL, " +
            //      "Registered_Address varchar(255) NULL, " +
            //      "Charges varchar(255) NULL, " +
            //      "Date_Creation varchar(255) NULL, " +
            //      "Status varchar(255) NULL, " +
            //      "Persons_Entitled varchar(255) NULL, " +
            //      "Brief_Description varchar(1000) NULL, " +
            //      "Charge_Code varchar(255) NULL, " +
            //      "Company_Link varchar(255) NULL) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4;";

            //    cmd = new MySqlCommand(query, conn);
            //    conn.Open();
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    string error = ex.ToString();
            //}

            //rest of calculations
            try
            {
                await Task.Delay(2500).ConfigureAwait(false);


                sicCode = sicList.SelectedValue.ToString().Trim();

                int pgNum = 1;

                if (sicCount > 0)
                {
                    pgNum = (Convert.ToInt32(Math.Floor((double)(sicCount / 20))) + 2);

                }
                else
                {
                    pgNum = 1;
                }

                if (pgNum >= 501)
                {
                    pgNum = 501;
                }

                if (pgNum <= 500)
                {
                    int companiesFound = 0;

                    int srNO = 0;
                    int srNOChargesnEW = 0;

                    bool tryAgain = true;

                    bool tryAgainWhile = true;

                    bool breakNow = false;

                    int companiesTot = 10000;
                    int companiesNow = 1;

                    zeroCom = 0;
                    totalCompanies = 0;
                    chargeCom = 0;

                    int zeroComNow = 0;
                    int totalCompaniesNow = 0;
                    int chargeComNow = 0;

                    messageInt = 0;

                    dtSingleCharges = new DataTable();
                    dtSingleZero = new DataTable();

                    //zero charges table
                    dtSingleZero.Columns.Add(new DataColumn("srNO", typeof(string)));
                    dtSingleZero.Columns.Add(new DataColumn("sicCodee", typeof(string)));
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
                    dtSingleCharges.Columns.Add(new DataColumn("sicCodee", typeof(string)));
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


                    //filling tables with previous data
                    query = "Select sr_no as srNo, SIC_CODE as sicCodee, Company_Name as compName , " +
                        " Company_Number as compNumberMain, Registered_Address as regAddress, " +
                        " Charges as charges_Main, Date_Creation as dtCreate, Status as status_Main," +
                        " Persons_Entitled as pEntitle, Brief_Description as `desc`, Charge_Code as cCode," +
                        " Company_Link as companyLink from " + tbName + " where charges <= 0;";
                    cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    cmd.ExecuteNonQuery();

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    sda.Fill(dtSingleZero);

                    query = "Select sr_no as srNo, SIC_CODE as sicCodee, Company_Name as compName , " +
                         " Company_Number as compNumberMain, Registered_Address as regAddress, " +
                         " Charges as charges_Main, Date_Creation as dtCreate, Status as status_Main," +
                         " Persons_Entitled as pEntitle, Brief_Description as `desc`, Charge_Code as cCode," +
                         " Company_Link as companyLink from " + tbName + " where charges > 0;";
                    cmd = new MySqlCommand(query, conn);
                    sda = new MySqlDataAdapter(cmd);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    cmd.ExecuteNonQuery();

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    sda.Fill(dtSingleCharges);
                    //done filling tables


                    do
                    {
                        while (tryAgainWhile)
                        {

                            try
                            {


                                List<string> companyCodes = new List<string>();

                                string pageNumber = "&page=" + pgNum;

                                messageNow = "Downloading Page Number: " + pgNum + " for SIC Code: " + sicCode;

                                HtmlWeb client = new HtmlWeb();

                                //string linkNow = "https://find-and-update.company-information.service.gov.uk/advanced-search/get-results?sicCodes=" + sicCode + pageNumber;

                                string linkNew = "https://find-and-update.company-information.service.gov.uk/advanced-search/get-results?incorporationFromDay=&incorporationFromMonth=&incorporationFromYear=&incorporationToDay=&incorporationToMonth=&incorporationToYear=&sicCodes=" + sicCode + "&dissolvedFromDay=&dissolvedFromMonth=&dissolvedFromYear=&dissolvedToDay=&dissolvedToMonth=&dissolvedToYear=" + pageNumber;

                                HtmlDocument doc = await client.LoadFromWebAsync(linkNew);
                                HtmlNodeCollection Nodes = doc.DocumentNode.SelectNodes("//a[@href]");


                                if (doc.ToString().Contains("Gateway") || doc.ToString().Contains("criteria"))
                                {
                                    messageNow = "Page Number: " + pgNum + " Not Available. Retrying Now.";
                                    await Task.Delay(18000);
                                    bool linkNow = true;

                                    while (linkNow)
                                    {
                                        doc = await client.LoadFromWebAsync(linkNew);
                                        Nodes = doc.DocumentNode.SelectNodes("//a[@href]");
                                        if (doc.ToString().Contains("Gateway") || doc.ToString().Contains("criteria"))
                                        {

                                            await Task.Delay(9000);

                                        }
                                        else if (Nodes.Count >= 47)
                                        {
                                            linkNow = false;
                                        }

                                    }

                                }


                                if (Nodes.Count <= 46)
                                {
                                    if (retryCount <= 2)
                                    {
                                        retryCount = retryCount + 1;
                                        messageNow = "Retrying Download for Page Number: " + pgNum + " | Attempt: " + retryCount.ToString();
                                        await Task.Delay(8700);
                                        continue;
                                    }
                                    else
                                    {
                                        retryCount = 0;
                                        pgNum = pgNum + 1;
                                        await Task.Delay(8700);
                                        continue;
                                    }

                                }
                                else
                                {
                                    //if (Nodes.Count < 47)
                                    //{
                                    //    //breakNow = true;
                                    //    //break;
                                    //    messageNow = "Retrying Download for Page Number: " + pgNum;
                                    //    await Task.Delay(8700).ConfigureAwait(false);
                                    //    continue;
                                    //}
                                    //else
                                    //{

                                    //}


                                    foreach (var link in Nodes)
                                    {
                                        //mainProgress.Update();
                                        if (link.OuterHtml.ToString().Contains("/company/") == true)
                                        {
                                            companyCodes.Add(link.Attributes["href"].Value);
                                            companiesFound++;
                                        }

                                    }

                                    messageNow = "Downloaded Page Number: " + pgNum;

                                    pgNum = pgNum + 1;
                                    tryAgainWhile = false;

                                    //downloading companies
                                    string[] companies = companyCodes.ToArray();

                                    tryAgain = true;

                                    for (int i = 0; i < companies.Length; i++)
                                    {

                                        companiesNow++;

                                        CompaniesHouseClientResponse<CompaniesHouse.Response.Search.AllSearch.AllSearch> result = null;
                                        CompaniesHouseClientResponse<CompaniesHouse.Response.Charges.Charges> charges_company_new = null;

                                        while (tryAgain)
                                        {

                                            try
                                            {

                                                if (i % 4 == 0)
                                                {
                                                    await Task.Delay(8100);
                                                }

                                                //await Task.Delay(3000).ConfigureAwait(false);

                                                string nameToSearchFor = companies[i].Substring(companies[i].LastIndexOf('y') + 2);

                                                messageNow = "Downloading for Company from API: " + nameToSearchFor + " | Page Number: " + pgNum;

                                                var settings = new CompaniesHouseSettings(api_key);

                                                using (var clientNew = new CompaniesHouseClient(settings))
                                                {
                                                    var request = new SearchRequest()
                                                    {
                                                        Query = nameToSearchFor,
                                                        StartIndex = 0,
                                                        ItemsPerPage = 10
                                                    };

                                                    result = await clientNew.SearchAllAsync(request);
                                                    charges_company_new = await clientNew.GetChargesListAsync(nameToSearchFor);

                                                }

                                                if (result is null)
                                                {
                                                    messageNow = "API sent no data. Retrying for company: " + nameToSearchFor + " |  Page Number: " + pgNum;
                                                    await Task.Delay(8970);
                                                }
                                                else
                                                {
                                                    tryAgain = false;
                                                }

                                            }
                                            catch (Exception e)
                                            {
                                                if (e.ToString().Contains("429"))
                                                {
                                                    messageNow = "Too Many Requests. Will Wait." + " | Page Number: " + pgNum;
                                                    await Task.Delay(146789);

                                                }
                                                else
                                                {
                                                    if (retryCount <= 2)
                                                    {
                                                        retryCount = retryCount + 1;
                                                        messageNow = "Retrying Download for Company from API: " + companies[i].Substring(companies[i].LastIndexOf('y') + 2) + " | Page Number: " + pgNum;
                                                        await Task.Delay(6700);
                                                        //tryAgain = false;
                                                        //continue;
                                                    }
                                                    else
                                                    {
                                                        retryCount = 0;
                                                        //pgNum = pgNum + 1;
                                                        messageNow = "Retrying Download for Company from API: " + companies[i].Substring(companies[i].LastIndexOf('y') + 2) + " | Page Number: " + pgNum;
                                                        await Task.Delay(6700);
                                                        tryAgain = false;
                                                        //continue;
                                                    }

                                                    ////old working code
                                                    ///
                                                    //messageNow = "Retrying Download for Company from API: " + companies[i].Substring(companies[i].LastIndexOf('y') + 2) + " | Page Number: " + pgNum; 
                                                    //await Task.Delay(6700);
                                                    ////tryAgain = false;
                                                    ////continue;
                                                }
                                                continue;


                                            }
                                        }

                                        tryAgain = true;


                                        if (result is null || result.ToString().Contains("429"))
                                        {
                                            messageNow = "Null Data for Company: " + companies[i].Substring(companies[i].LastIndexOf('y') + 2);
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
                                                        zeroComNow++;
                                                        zeroCom = zeroComNow;

                                                        int serNo = 0;
                                                        if (dtSingleZero.Rows.Count <= 0)
                                                        {
                                                            serNo = 0;
                                                        }
                                                        else
                                                        {
                                                            serNo = dtSingleZero.Rows.Count;
                                                        }


                                                        dr = dtSingleZero.NewRow();

                                                        dr["srNO"] = serNo.ToString();
                                                        dr["sicCodee"] = sicCode is null ? "NA" : sicCode.ToString();
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

                                                        try
                                                        {
                                                            //DB Connections
                                                            query = "INSERT INTO " + tbName + " (`Sr_No`, `SIC_Code`, `Company_Name`, `Company_Name_Link`, `Company_Number`,`Company_Number_Link`, `Registered_Address`, `Charges`, `Date_Creation`, `Status`, `Persons_Entitled`, `Brief_Description`, `Charge_Code`, `Company_Link`) " +
                                                     " VALUES (@srno, @scode, @cname, @cnamelink, @cnumb, @cnumblink, @radd, @charges, @dtCreate, @status, @pent, @bdesc, @ccode, @clink)";

                                                            cmd = new MySqlCommand(query, conn);

                                                            cmd.Parameters.AddWithValue("@srno", serNo.ToString());
                                                            cmd.Parameters.AddWithValue("@scode", sicCode is null ? "NA" : sicCode.ToString());
                                                            cmd.Parameters.AddWithValue("@cname", item.Title is null ? "NA" : item.Title.ToString());
                                                            cmd.Parameters.AddWithValue("@cnamelink", "https://app.creditsafe.com/search?countries=GB&limit=15&name=" + (item.Title is null ? "NA" : item.Title.Trim().ToString()) + "&page=1".ToString());
                                                            cmd.Parameters.AddWithValue("@cnumb", item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString());
                                                            cmd.Parameters.AddWithValue("@cnumblink", "https://app.creditsafe.com/search?countries=GB&limit=15&name=" + (item.CompanyNumber is null ? "NA" : item.CompanyNumber.Trim().ToString()) + "&page=1".ToString());
                                                            cmd.Parameters.AddWithValue("@radd", addressNow is null ? "NA" : addressNow.ToString());
                                                            cmd.Parameters.AddWithValue("@charges", "0".ToString());
                                                            cmd.Parameters.AddWithValue("@dtCreate", "NA".ToString());
                                                            cmd.Parameters.AddWithValue("@status", item.CompanyStatus.ToString());
                                                            cmd.Parameters.AddWithValue("@pent", "NA".ToString());
                                                            cmd.Parameters.AddWithValue("@bdesc", "NA".ToString());
                                                            cmd.Parameters.AddWithValue("@ccode", "NA".ToString());
                                                            cmd.Parameters.AddWithValue("@clink", "https://find-and-update.company-information.service.gov.uk/company/" + (item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString()));

                                                            if (conn.State != ConnectionState.Open)
                                                            {
                                                                conn.Open();
                                                            }

                                                            cmd.ExecuteNonQuery();

                                                            if (conn.State == ConnectionState.Open)
                                                            {
                                                                conn.Close();
                                                            }
                                                            //DB Connections
                                                        }
                                                        catch (Exception exNow)
                                                        {
                                                            messageNow = exNow.Message;
                                                            if (conn.State == ConnectionState.Open)
                                                            {
                                                                conn.Close();
                                                            }
                                                            continue;

                                                        }

                                                    }
                                                    catch
                                                    {
                                                        break;
                                                    }


                                                }
                                                //dgMainCharges.Columns["dataGridViewTextBoxColumn11"].DefaultCellStyle.Format = "dd/MM/yyyy";


                                            }
                                            else
                                            {
                                                try
                                                {
                                                    string count_Charges = charges_company_new.Data.TotalCount.ToString();
                                                    chargeComNow++;
                                                    chargeCom = chargeComNow;

                                                    foreach (Charge charge_Company in charges_company_new.Data.Items.Where(t => t as Charge != null))
                                                    {

                                                        foreach (Company item in result.Data.Items.Where(t => t as Company != null))
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

                                                            srNOChargesnEW++;

                                                            int serNoCharge = 0;
                                                            if (dtSingleCharges.Rows.Count <= 0)
                                                            {
                                                                serNoCharge = 0;
                                                            }
                                                            else
                                                            {
                                                                serNoCharge = dtSingleCharges.Rows.Count;
                                                            }

                                                            dr = dtSingleCharges.NewRow();

                                                            dr["srNO"] = serNoCharge.ToString();
                                                            dr["sicCodee"] = sicCode is null ? "NA" : sicCode.ToString();
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


                                                            try
                                                            {
                                                                //DB Connection
                                                                query = "INSERT INTO " + tbName + " (`Sr_No`, `SIC_Code`, `Company_Name`, `Company_Name_Link`, `Company_Number`,`Company_Number_Link`, `Registered_Address`, `Charges`, `Date_Creation`, `Status`, `Persons_Entitled`, `Brief_Description`, `Charge_Code`, `Company_Link`) " +
                                                         " VALUES (@srno, @scode, @cname, @cnamelink, @cnumb, @cnumblink, @radd, @charges, @dtCreate, @status, @pent, @bdesc, @ccode, @clink)";

                                                                cmd = new MySqlCommand(query, conn);

                                                                cmd.Parameters.AddWithValue("@srno", serNoCharge.ToString());
                                                                cmd.Parameters.AddWithValue("@scode", sicCode is null ? "NA" : sicCode.ToString());
                                                                cmd.Parameters.AddWithValue("@cname", item.Title is null ? "NA" : item.Title.ToString());
                                                                cmd.Parameters.AddWithValue("@cnamelink", "https://app.creditsafe.com/search?countries=GB&limit=15&name=" + (item.Title is null ? "NA" : item.Title.ToString() + "&page=1".ToString()));
                                                                cmd.Parameters.AddWithValue("@cnumb", item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString());
                                                                cmd.Parameters.AddWithValue("@cnumblink", "https://app.creditsafe.com/search?countries=GB&limit=15&name=" + (item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString() + "&page=1".ToString()));
                                                                cmd.Parameters.AddWithValue("@radd", addressNow is null ? "NA" : addressNow.ToString());
                                                                cmd.Parameters.AddWithValue("@charges", count_Charges is null ? "NA" : count_Charges.ToString());
                                                                cmd.Parameters.AddWithValue("@dtCreate", charge_Company.CreatedOn is null ? "NA" : DateTime.Parse(charge_Company.CreatedOn.Value.ToShortDateString()).ToString("yyyy -MM-dd").ToString());
                                                                cmd.Parameters.AddWithValue("@status", charge_Company.Status.ToString());
                                                                cmd.Parameters.AddWithValue("@pent", charge_Company.PersonsEntitled is null ? "NA" : charge_Company.PersonsEntitled[0] is null ? "NA" : charge_Company.PersonsEntitled[0].Name is null ? "NA" : charge_Company.PersonsEntitled[0].Name.ToString());
                                                                cmd.Parameters.AddWithValue("@bdesc", charge_Company.Particular is null ? "NA" : charge_Company.Particular.Description is null ? "NA" : charge_Company.Particular.Description.ToString());
                                                                cmd.Parameters.AddWithValue("@ccode", charge_Company.ChargeCode is null ? "NA" : charge_Company.ChargeCode.ToString());
                                                                cmd.Parameters.AddWithValue("@clink", "https://find-and-update.company-information.service.gov.uk/company/" + (item.CompanyNumber is null ? "NA" : item.CompanyNumber.ToString()));

                                                                if (conn.State != ConnectionState.Open)
                                                                {
                                                                    conn.Open();
                                                                }

                                                                cmd.ExecuteNonQuery();

                                                                if (conn.State == ConnectionState.Open)
                                                                {
                                                                    conn.Close();
                                                                }


                                                                //DB Connections
                                                            }
                                                            catch (Exception exNow)
                                                            {
                                                                messageNow = exNow.Message;
                                                                if (conn.State == ConnectionState.Open)
                                                                {
                                                                    conn.Close();
                                                                }
                                                                continue;

                                                            }

                                                        }

                                                    }

                                                }
                                                catch
                                                {
                                                    break;
                                                }


                                                //dgMainCharges.Columns["dataGridViewTextBoxColumn11"].DefaultCellStyle.Format = "dd/MM/yyyy";
                                            }
                                        }



                                        totalCompaniesNow++;
                                        totalCompanies = totalCompaniesNow;

                                        await pause.WaitWhilePausedWithResponseAsyc();
                                        cancellationToken.ThrowIfCancellationRequested();

                                    }
                                }



                                //button2.Enabled = true;
                                //button5.Enabled = true;
                                //btnSearch.Enabled = true;


                            }
                            catch
                            {
                                //Console.WriteLine(ex.Message);
                                //continue;
                                messageNow = "Main Download Failure. Retrying Again" + " | Page Number: " + pgNum;
                                await Task.Delay(9000);
                                tryAgainWhile = true;
                                continue;

                            }
                        }

                        tryAgainWhile = true;
                        cancellationToken.ThrowIfCancellationRequested();

                    }
                    while (pgNum <= 501);
                    //while (pgNum <= 600 && breakNow == false) ;
                }
                else if (pgNum > 500)
                {
                    messageNow = "All Data Downloaded";

                    dtSingleCharges = new DataTable();
                    dtSingleZero = new DataTable();

                    //zero charges table
                    dtSingleZero.Columns.Add(new DataColumn("srNO", typeof(string)));
                    dtSingleZero.Columns.Add(new DataColumn("sicCodee", typeof(string)));
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
                    dtSingleCharges.Columns.Add(new DataColumn("sicCodee", typeof(string)));
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


                    //filling tables with previous data
                    query = "Select sr_no as srNo, SIC_CODE as sicCodee, Company_Name as compName , " +
                        " Company_Number as compNumberMain, Registered_Address as regAddress, " +
                        " Charges as charges_Main, Date_Creation as dtCreate, Status as status_Main," +
                        " Persons_Entitled as pEntitle, Brief_Description as `desc`, Charge_Code as cCode," +
                        " Company_Link as companyLink from " + tbName + " where charges <= 0;";
                    cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    cmd.ExecuteNonQuery();

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    sda.Fill(dtSingleZero);

                    query = "Select sr_no as srNo, SIC_CODE as sicCodee, Company_Name as compName , " +
                         " Company_Number as compNumberMain, Registered_Address as regAddress, " +
                         " Charges as charges_Main, Date_Creation as dtCreate, Status as status_Main," +
                         " Persons_Entitled as pEntitle, Brief_Description as `desc`, Charge_Code as cCode," +
                         " Company_Link as companyLink from " + tbName + " where charges > 0;";
                    cmd = new MySqlCommand(query, conn);
                    sda = new MySqlDataAdapter(cmd);

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    cmd.ExecuteNonQuery();

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    sda.Fill(dtSingleCharges);
                    //done filling tables
                }

            }
            catch (Exception e)
            {
                messageNow = "Main Download Failure Before Loop. Retrying Again";
                //throw;
                //continue;
            }

            messageNow = "All Data Downloaded.";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            processComplete = false;
            Timer1.Enabled = true;
            Thread workerThread = new Thread(new ThreadStart(ProcessRecords));
            workerThread.Start();
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
            //string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
            //MySqlConnection conn = new MySqlConnection();
            //conn.ConnectionString = strConnString;

            ////string ConStr = System.Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb").ToString();
            ////ConStr = ConStr.Replace("Database", "database");
            ////ConStr = ConStr.Replace("Data Source", "server");
            ////ConStr = ConStr.Replace("User Id", "uid");
            ////ConStr = ConStr.Replace("Password", "pwd");
            ////ConStr = ConStr.Replace("127.0.0.1", "localhost");
            ////ConStr = ConStr.Replace(":", ";port=");
            ////ConStr = ConStr.Replace("localdb", "hza");
            ////conn.ConnectionString = ConStr;

            //MySqlCommand cmd = new MySqlCommand();


            //string tbName = Session["username"] + "_sic_" + sicList.SelectedValue.ToString().Trim();
            //string query = "Select * from " + tbName + " where charges > 0;";

            //cmd = new MySqlCommand(query, conn);

            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

            //conn.Open();

            //cmd.ExecuteNonQuery();

            //DataTable dt = new DataTable();

            //sda.Fill(dt);

            //conn.Close();

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
            //string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
            //MySqlConnection conn = new MySqlConnection();
            //conn.ConnectionString = strConnString;


            ////string ConStr = System.Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb").ToString();
            ////ConStr = ConStr.Replace("Database", "database");
            ////ConStr = ConStr.Replace("Data Source", "server");
            ////ConStr = ConStr.Replace("User Id", "uid");
            ////ConStr = ConStr.Replace("Password", "pwd");
            ////ConStr = ConStr.Replace("127.0.0.1", "localhost");
            ////ConStr = ConStr.Replace(":", ";port=");
            ////ConStr = ConStr.Replace("localdb", "hza");
            ////conn.ConnectionString = ConStr;


            //MySqlCommand cmd = new MySqlCommand();

            //string tbName = Session["username"] + "_sic_" + sicList.SelectedValue.ToString().Trim();
            //string query = "Select * from " + tbName + " where charges > 0;";

            //cmd = new MySqlCommand(query, conn);

            //MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

            //conn.Open();

            //cmd.ExecuteNonQuery();

            //DataTable dtNow = new DataTable();

            //sda.Fill(dtNow);

            //conn.Close();

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
            if(stopFlag == "false")
            {
                cancelSource.Cancel();
                cancelSource.Dispose();
            }
            Response.Redirect("index.aspx");

        }
    }
}