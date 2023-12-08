using CompaniesHouse;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Charges;
using CompaniesHouse.Response.Search.CompanySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace HZA_Web_Phase_1
{
    public partial class addInfo : System.Web.UI.Page
    {

        protected static string compNumber = null;
        protected static string compName = null;
        protected static string sicCode = null;
        protected static string sicDesc = null;
        protected static string compAddress = null;
        protected static string postalCode = null;
        protected static string api_key = "c248f45a-10b4-4d60-a8b6-f2ad496eb560";
        protected static string propData_Key = "CVBISWBHBD";
        protected static string rocketReach_Key = "b5e87ak35e1976d6985f50aa32b4c51340cdadb";
        CompaniesHouseClientResponse<CompaniesHouse.Response.Charges.Charges> charges_company_new = null;
        CompaniesHouseClientResponse<CompaniesHouse.Response.Officers.Officers> officerListFinal = null;
        List<string> postalCodeList = new List<string>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("index.aspx");

            }

            if(string.IsNullOrWhiteSpace(Request.QueryString["Parameter"].ToString()))
            {
                Response.Redirect("single-comp-search.aspx");
            }

            //fetching data for company
            string something = Request.QueryString["Parameter"].ToString();
            sicCode = something.Split('|')[0].Replace("__", " &").Replace('_', ' ').ToString().Trim().TrimStart().TrimEnd();
            compName = something.Split('|')[1].Replace("__", " &").Replace('_', ' ').ToString().Trim().TrimStart().TrimEnd();
            compNumber = something.Split('|')[2].Replace("__", " &").Replace('_', ' ').ToString().Trim().TrimStart().TrimEnd();
            compAddress = something.Split('|')[3].Replace("__", " &").Replace('_', ' ').ToString().Trim().TrimStart().TrimEnd();
            sicDesc = something.Split('|')[4].Replace("__", " &").Replace('_', ' ').ToString().Split(':')[1].ToString().Trim().TrimStart().TrimEnd();

            string pattern = @".*\s(\w{2,4} \w{3})";
            Regex rg = new Regex(pattern);
            Match postData = rg.Match(compAddress);
            postalCode = postData.Groups[1].Value.ToString();


            //summary
            lb_summary_CompNumb.Text = compNumber;
            lb_summary_CompName.Text = compName;
            lb_summary_sicCode.Text = sicCode;
            lb_summary_sicDesc.Text = sicDesc;
            lb_summary_compAddress.Text = compAddress;


            /// API Calls
            var settings = new CompaniesHouseSettings(api_key);

            ///
            /// Officers from RR API
            using (var clientNew = new CompaniesHouseClient(settings))
            {
                officerListFinal = clientNew.GetOfficersAsync(compNumber).Result;
            }

            addmainDiv(officerListFinal);


            ///Charges from Companies House API
            using (var clientNew = new CompaniesHouseClient(settings))
            {
                charges_company_new = clientNew.GetChargesListAsync(compNumber).Result;

            }

            chargesDIV(charges_company_new);

            ///Land Registry Calls
            landRegistry(charges_company_new);

            ///Research from Property Data API
            propertyDataCallFinal(postalCodeList);

            //contact
            //_ = officerSearch(compNumber);
            //_ = propertyDataCall("something");
            //_ = rocketReachCall("soemthing");


        }

        protected void addmainDiv(CompaniesHouseClientResponse<CompaniesHouse.Response.Officers.Officers> officerList)
        {
            for (int i = 0; i < officerList.Data.Items.Count(); i++)
            {
                string directNumb = (i + 1).ToString();
                //Rocket Reach Data
                Task<string> RRdata = null;
                string apiCall_RR = "https://api.rocketreach.co/v2/api/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiCall_RR);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // HTTP GET
                    string directorName = officerList.Data.Items[i].Name.ToString();
                    directorName = directorName.Split(',')[1].TrimStart().TrimEnd().Trim().ToString() + " " + directorName.Split(',')[0].TrimStart().TrimEnd().Trim().ToString();

                    string lookupCall = "lookupProfile?api_key=" + rocketReach_Key + "&name=" + directorName + "&current_employer=" + compName;

                    //lookupCall = "lookupProfile?api_key=" + rocketReach_Key + "&name=Marc Benioff&current_employer=Salesforce";

                    HttpResponseMessage response = client.GetAsync(lookupCall).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        RRdata = response.Content.ReadAsStringAsync();

                        string[] apiData = RRdata.Result.Split(',');

                        string appointments = "NA";
                        string pEmail = "NA";
                        string mobile = "NA";
                        string dd = "NA";
                        string linkedin = "NA";
                        string facebook = "NA";
                        string twitter = "NA";
                        string youtube = "NA";
                        string tiktok = "NA";

                        for (int k = 0; k < apiData.Length; k++)
                        {
                            apiData[k] = apiData[k].Replace("\\", "").Replace("\"", "").Replace("{", "").Replace("}", "");


                            //getting the details
                            if (apiData[k].Contains("email"))
                            {
                                if (pEmail == "NA")
                                {
                                    pEmail = apiData[k].Substring(apiData[k].IndexOf("email:") + 6,
                                    apiData[k].Length - (apiData[k].IndexOf("email:") + 6));
                                }

                            }

                            if (apiData[k].Contains("facebook"))
                            {
                                if (facebook == "NA")
                                {
                                    facebook = apiData[k].Substring(apiData[k].IndexOf("facebook:") + 9,
                                    apiData[k].Length - (apiData[k].IndexOf("facebook:") + 9));
                                }

                            }

                            if (apiData[k].Contains("twitter"))
                            {
                                if (twitter == "NA")
                                {
                                    twitter = apiData[k].Substring(apiData[k].IndexOf("twitter:") + 8,
                                    apiData[k].Length - (apiData[k].IndexOf("twitter:") + 8));
                                }

                            }

                            if (apiData[k].Contains("linkedin_url"))
                            {
                                if (linkedin == "NA")
                                {
                                    linkedin = apiData[k].Substring(apiData[k].IndexOf("linkedin_url:") + 13,
                                    apiData[k].Length - (apiData[k].IndexOf("linkedin_url:") + 13));
                                }

                            }

                            if (apiData[k].Contains("youtube"))
                            {
                                if (youtube == "NA")
                                {
                                    youtube = apiData[k].Substring(apiData[k].IndexOf("youtube:") + 8,
                                    apiData[k].Length - (apiData[k].IndexOf("youtube:") + 8));
                                }

                            }

                            if (apiData[k].Contains("tiktok"))
                            {
                                if (tiktok == "NA")
                                {
                                    tiktok = apiData[k].Substring(apiData[k].IndexOf("tiktok:") + 7,
                                    apiData[k].Length - (apiData[k].IndexOf("tiktok:") + 7));
                                }

                            }


                        }

                        System.Web.UI.HtmlControls.HtmlGenericControl newdivs = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newdivs.Attributes.Add("class", "newPeople");
                        newdivs.ID = "createDiv";
                        newdivs.InnerHtml = "<div class='main'>" +
                            "<div class='sides'>" +
                            "<div class='tables'>" +
                            "<h2>Title</h2>" +
                            "<div class='group'>" +
                            "<div class='el headings'>Director</div>" +
                            "<div id = 'lb_people_director1' class='el'>" + "Director#" + directNumb + "</div>" +
                            "</div>" +
                            "<div class='group'>" +
                            "<div class='el headings'>Name</div>" +
                            "<div id = 'lb_people_name1' class='el'>" + directorName + "</div>" +
                            "</div></div></div>" +
                            "<div class='sides'>" +
                            "<div class='tables'>" +
                            "<h2>Title</h2>" +
                            "<div class='group'><div class='el headings'>No of Appointments</div>" +
                            "<div id = 'lb_people_appoint1' class='el'>" + appointments.ToString() + "</div>" +
                            "</div>" +
                            "<div class='group'>" +
                            "<div class='el headings'>personal email</div>" +
                            "<div id = 'lb_people_email1' class='el'>" + pEmail.ToString() + "</div>" +
                            "</div>" +
                            "<div class='group'>" +
                            "<div class='el headings'>Mobile</div>" +
                            "<div id= 'lb_people_mobile1' class='el'>" + mobile.ToString() + "</div>" +
                            "</div>" +
                            "<div class='group'>" +
                            "<div class='el headings'>DD</div>" +
                            "<div id= 'lb_people_DD1' class='el'>" + dd.ToString() + "</div></div>" +
                            "" +
                            "<div class='group'><div class='el headings'>Linkden</div>" +
                            "<div id= 'lb_people_linkedin1' class='el'><a style='color:blue;' href=" + linkedin.ToString() + ">" + linkedin.ToString() + "</a></div></div>" +
                            "" +
                            "<div class='group'><div class='el headings'>Facebook</div>" +
                            "<div id = 'lb_peopl_fb1' class='el'>" + facebook.ToString() + "</div></div>" +
                            "<div class='group'>" +
                            "" +
                            "<div class='el headings'>Twitter</div>" +
                            "<div id= 'lb_people_twitter1' class='el'>" + twitter.ToString() + "</div></div>" +
                            "" +
                            "<div class='group'><div class='el headings'>Youtube</div>" +
                            "<div id= 'lb_people_youtube1' class='el'>" + youtube.ToString() + "</div></div><div class='group'>" +
                            "" +
                            "<div class='el headings'>TickTok</div>" +
                            "<div id= 'lb_people_tiktok1' class='el'>" + tiktok.ToString() + "</div></div></div></div></div>";

                        newPeople.Controls.Add(newdivs);
                    }
                    else
                    {
                        string appointments = "NA";
                        string pEmail = "NA";
                        string mobile = "NA";
                        string dd = "NA";
                        string linkedin = "NA";
                        string facebook = "NA";
                        string twitter = "NA";
                        string youtube = "NA";
                        string tiktok = "NA";

                        System.Web.UI.HtmlControls.HtmlGenericControl newdivs = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        newdivs.Attributes.Add("class", "newPeople");
                        newdivs.ID = "createDiv";
                        newdivs.InnerHtml = "<div class='main'>" +
                            "<div class='sides'>" +
                            "<div class='tables'>" +
                            "<h2>Title</h2>" +
                            "<div class='group'>" +
                            "<div class='el headings'>Director</div>" +
                            "<div id = 'lb_people_director1' class='el'>" + "Director#" + directNumb + "</div>" +
                            "</div>" +
                            "<div class='group'>" +
                            "<div class='el headings'>Name</div>" +
                            "<div id = 'lb_people_name1' class='el'>" + directorName + "</div>" +
                            "</div></div></div>" +
                            "<div class='sides'>" +
                            "<div class='tables'>" +
                            "<h2>Title</h2>" +
                            "<div class='group'><div class='el headings'>No of Appointments</div>" +
                            "<div id = 'lb_people_appoint1' class='el'>" + appointments.ToString() + "</div>" +
                            "</div>" +
                            "<div class='group'>" +
                            "<div class='el headings'>personal email</div>" +
                            "<div id = 'lb_people_email1' class='el'>" + pEmail.ToString() + "</div>" +
                            "</div>" +
                            "<div class='group'>" +
                            "<div class='el headings'>Mobile</div>" +
                            "<div id= 'lb_people_mobile1' class='el'>" + mobile.ToString() + "</div>" +
                            "</div>" +
                            "<div class='group'>" +
                            "<div class='el headings'>DD</div>" +
                            "<div id= 'lb_people_DD1' class='el'>" + dd.ToString() + "</div></div>" +
                            "" +
                            "<div class='group'><div class='el headings'>Linkden</div>" +
                            "<div id= 'lb_people_linkedin1' class='el'>" + linkedin.ToString() + "</div></div>" +
                            "" +
                            "<div class='group'><div class='el headings'>Facebook</div>" +
                            "<div id = 'lb_peopl_fb1' class='el'>" + facebook.ToString() + "</div></div>" +
                            "<div class='group'>" +
                            "" +
                            "<div class='el headings'>Twitter</div>" +
                            "<div id= 'lb_people_twitter1' class='el'>" + twitter.ToString() + "</div></div>" +
                            "" +
                            "<div class='group'><div class='el headings'>Youtube</div>" +
                            "<div id= 'lb_people_youtube1' class='el'>" + youtube.ToString() + "</div></div><div class='group'>" +
                            "" +
                            "<div class='el headings'>TickTok</div>" +
                            "<div id= 'lb_people_tiktok1' class='el'>" + tiktok.ToString() + "</div></div></div></div></div>";

                        newPeople.Controls.Add(newdivs);
                    }

                }

            }

        }

        protected void chargesDIV(CompaniesHouseClientResponse<CompaniesHouse.Response.Charges.Charges> charges_company_new)
        {


            for (int i = 0; i < charges_company_new.Data.Items.Count(); i++)
            {

                string dateRegistered = charges_company_new.Data.Items[i].AcquiredOn is null ? "NA" : DateTime.Parse(charges_company_new.Data.Items[i].AcquiredOn.Value.ToShortDateString()).ToString("yyyy -MM-dd").ToString();
                string dateCreated = charges_company_new.Data.Items[i].CreatedOn is null ? "NA" : DateTime.Parse(charges_company_new.Data.Items[i].CreatedOn.Value.ToShortDateString()).ToString("yyyy -MM-dd").ToString();
                string dateSatisfied = charges_company_new.Data.Items[i].SatisfiedOn is null ? "NA" : DateTime.Parse(charges_company_new.Data.Items[i].SatisfiedOn.Value.ToShortDateString()).ToString("yyyy -MM-dd").ToString();
                string pEntitled = charges_company_new.Data.Items[i].PersonsEntitled is null ? "NA" : charges_company_new.Data.Items[i].PersonsEntitled[0] is null ? "NA" : charges_company_new.Data.Items[i].PersonsEntitled[0].Name is null ? "NA" : charges_company_new.Data.Items[i].PersonsEntitled[0].Name.ToString();
                string description = charges_company_new.Data.Items[i].Particular is null ? "NA" : charges_company_new.Data.Items[i].Particular.Description is null ? "NA" : charges_company_new.Data.Items[i].Particular.Description.ToString();



                System.Web.UI.HtmlControls.HtmlGenericControl newdivs = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                newdivs.Attributes.Add("class", "newCharges");
                newdivs.ID = "createDiv";
                newdivs.InnerHtml = "<div class='main'>" +
                    "<div class='sides'><div class='tables'><h2>Title</h2><div class='group'>" +
                    "" +
                    "<div class='el headings'>Date registered</div><div class='el'>" + dateRegistered.ToString() + "</div></div>" +
                    "" +
                    "<div class='group'><div class='el headings'>Date created</div><div class='el'>" + dateCreated.ToString() + "</div></div>" +
                    "" +
                    "<div class='group'><div class='el headings'>Date Satisfied</div><div class='el'>" + dateSatisfied.ToString() + "</div></div></div></div>" +
                    "" +
                    "<div class='sides'><div class='tables'><h2>Title</h2><div class='group'>" +
                    "" +
                    "<div class='el headings'>Person Entitled</div><div class='el'>" + pEntitled.ToString() + "</div></div>" +
                    "" +
                    "<div class='group'><div class='el headings'>Details</div><div class='el'>" + description.ToString() + "</div></div>" +
                    "" +
                    "<div class='group'><div class='el headings'>Registered Address</div><div class='el'>" + compAddress.ToString() + "</div></div></div></div></div>";

                newCharges.Controls.Add(newdivs);

            }

        }

        protected void landRegistry(CompaniesHouseClientResponse<CompaniesHouse.Response.Charges.Charges> charges_company_new)
        {

            for (int i = 0; i < charges_company_new.Data.Items.Count(); i++)
            {
                string currCharge = charges_company_new.Data.Items[i].Particular is null ? "NA" : charges_company_new.Data.Items[i].Particular.Description is null ? "NA" : charges_company_new.Data.Items[i].Particular.Description.ToString();

                //getting any possible codes from the charge itself
                string postCodePattern = @"([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})";
                Match[] postCodesCharge = Regex.Matches(currCharge, postCodePattern).Cast<Match>().ToArray();

                if(postCodesCharge.Count() > 0)
                {
                    for(int pc = 0; pc < postCodesCharge.Count(); pc++)
                    postalCodeList.Add(postCodesCharge[pc].ToString());
                }



                Match[] titleNumb_Numb = Regex.Matches(currCharge, @"\d+").Cast<Match>().ToArray();
                //Match[] titleNumb_Alpha = Regex.Matches(currCharge, @"([^\s]+?[\d*][^\s]+)").Cast<Match>().ToArray();
                Match[] titleNumb_Alpha = Regex.Matches(currCharge, @"\w*\d+\w*").Cast<Match>().ToArray();

                int count_Numb = titleNumb_Numb.Count();
                int count_Alpha = titleNumb_Alpha.Count();

                if (count_Numb > 0)
                {
                    for (int j = 0; j < count_Numb; j++)
                    {

                        string currTitle = titleNumb_Numb[j].ToString().Replace(',', ' ').Trim().TrimStart().TrimEnd();
                        if(currTitle.Contains('.'))
                        {
                            currTitle = currTitle.Substring(currTitle.LastIndexOf('.') + 1, currTitle.Length - currTitle.LastIndexOf('.') - 1);

                        }

                        string apiCall = "https://api.propertydata.co.uk/";


                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(apiCall);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            HttpResponseMessage response = client.GetAsync("title-info?key=" + propData_Key + "&title=" + currTitle).Result;

                            Thread.Sleep(3000);

                            if (response.IsSuccessStatusCode)
                            {
                                string something = response.Content.ReadAsStringAsync().Result;

                                Thread.Sleep(3000);

                                string pattern = @"([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})";
                                Regex rg = new Regex(pattern);
                                Match postData = rg.Match(something);

                                if (postData != null)
                                {
                                    postalCodeList.Add(postData.Groups[0].Value.ToString());
                                }

                                Match[] postCodesCharge_one = Regex.Matches(something, postCodePattern).Cast<Match>().ToArray();

                                if (postCodesCharge_one.Count() > 0)
                                {
                                    for (int pcOne = 0; pcOne < postCodesCharge_one.Count(); pcOne++)
                                        postalCodeList.Add(postCodesCharge_one[pcOne].ToString());
                                }

                            }
                        }

                    }
                }

                if (count_Alpha > 0)
                {
                    for (int k = 0; k < count_Alpha; k++)
                    {

                        string currTitle = titleNumb_Alpha[k].ToString().Replace(',', ' ').Trim().TrimStart().TrimEnd();
                        if (currTitle.Contains('.'))
                        {
                            currTitle = currTitle.Substring(currTitle.LastIndexOf('.') + 1, currTitle.Length - currTitle.LastIndexOf('.') - 1);

                        }
                        string apiCall = "https://api.propertydata.co.uk/";

                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(apiCall);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            HttpResponseMessage response = client.GetAsync("title-info?key=" + propData_Key + "&title=" + currTitle).Result;

                            Thread.Sleep(3000);

                            if (response.IsSuccessStatusCode)
                            {
                                string something = response.Content.ReadAsStringAsync().Result;

                                Thread.Sleep(3000);

                                string pattern = @"([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9][A-Za-z]?))))\s?[0-9][A-Za-z]{2})";
                                Regex rg = new Regex(pattern);
                                Match postData = rg.Match(something);
                                if (postData != null)
                                {
                                    postalCodeList.Add(postData.Groups[0].Value.ToString());
                                }

                                Match[] postCodesCharge_one = Regex.Matches(something, postCodePattern).Cast<Match>().ToArray();

                                if (postCodesCharge_one.Count() > 0)
                                {
                                    for (int pcOne = 0; pcOne < postCodesCharge_one.Count(); pcOne++)
                                        postalCodeList.Add(postCodesCharge_one[pcOne].ToString());
                                }

                            }
                        }
                    }

                }

            }

            string somethingNew = "";
            postalCodeList = postalCodeList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();


        }

        public void propertyDataCallFinal(List<string> postalCodeList)
        {

            string prices = "NA";
            string prices_sqf = "NA";
            string sold_prices = "NA";
            string sold_prices_sqf = "NA";
            string growth = "NA";
            string valuation = "NA";
            string valuation_rent = "NA";
            string rent = "NA";
            string HMO = "NA";
            string yeilds = "NA";
            string LHA = "NA";
            string demand = "NA";
            string demand_rent = "NA";
            string planning = "NA";
            string floor = "NA";
            string title_info = "NA";
            string titleUseClass = "NA";
            string analyzeBuildings = "NA";

            if (postalCodeList.Count > 0)
            {
                for (int i = 0; i < postalCodeList.Count; i++)
                {
                    postalCode = postalCodeList[i].ToString();

                    Task<string> propData = null;
                    string propData_Prices = null;
                    int Pos1 = 0;
                    int Pos2 = 0;

                    string apiCall = "https://api.propertydata.co.uk/";

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiCall);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        //Prices
                        HttpResponseMessage response = client.GetAsync("prices?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);


                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("average") + "average".Length, 20);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                prices = propData_Prices;

                            }

                        }

                        //Prices Per SQF
                        response = client.GetAsync("prices-per-sqf?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("average") + "average".Length, 20);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                prices_sqf = propData_Prices;
                            }

                        }

                        //Sold Prices
                        response = client.GetAsync("sold-prices?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("average") + "average".Length, 20);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                sold_prices = propData_Prices;
                            }

                        }

                        //Sold Prices Per SQF
                        response = client.GetAsync("sold-prices-per-sqf?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("average") + "average".Length, 20);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                sold_prices_sqf = propData_Prices;
                            }

                        }

                        ////Growth
                        //response = client.GetAsync("growth?key=" + propData_Key + "&postcode=" + postalCode).Result;
                        //if (response.IsSuccessStatusCode)
                        //{
                        //    propData = response.Content.ReadAsStringAsync();

                        //    propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("average") + "average".Length, 20);
                        //    Pos1 = propData_Prices.IndexOf(':') + 1;
                        //    Pos2 = propData_Prices.IndexOf(',');
                        //    propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);

                        //    lb_Research_Sold_Prices_SQF.Text = propData_Prices;

                        //}

                        //Valuation Sale
                        response = client.GetAsync("valuation-sale?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("estimate") + "estimate".Length, 15);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                valuation = propData_Prices;
                            }

                        }

                        //Valuation Rent
                        response = client.GetAsync("valuation-rent?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("estimate") + "estimate".Length, 15);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                valuation_rent = propData_Prices;
                            }

                        }


                        //Rents
                        response = client.GetAsync("rents?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("average") + "average".Length, 20);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                rent = propData_Prices;
                            }

                        }

                        //Rents HMO
                        response = client.GetAsync("rents-hmo?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("average") + "average".Length, 20);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                HMO = propData_Prices;
                            }

                        }


                        //Yields
                        response = client.GetAsync("yields?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("gross_yield") + "gross_yield".Length, 15);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                yeilds = propData_Prices;
                                if(yeilds.Contains("\""))
                                {
                                    yeilds = yeilds.Replace("\"", "");
                                }
                                if (yeilds.Contains("}"))
                                {
                                    yeilds = yeilds.Replace("}", "");
                                }
                                if (yeilds.Contains("{"))
                                {
                                    yeilds = yeilds.Replace("{", "");
                                }
                            }

                        }


                        //LHA Rate
                        response = client.GetAsync("lha-rate?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("rate") + "rate".Length, 15);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                LHA = propData_Prices;
                            }

                        }

                        //Demand
                        response = client.GetAsync("demand?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("demand_rating") + "demand_rating".Length, 15);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');
                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                demand = propData_Prices;
                            }



                        }

                        //Demand Rent
                        response = client.GetAsync("demand-rent?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("rental_demand_rating") + "rental_demand_rating".Length, 15);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                demand_rent = propData_Prices;
                            }

                        }

                        ////Planning
                        //response = client.GetAsync("demand-rent?key=" + propData_Key + "&postcode=" + postalCode).Result;
                        //if (response.IsSuccessStatusCode)
                        //{
                        //    propData = response.Content.ReadAsStringAsync();

                        //    propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("rental_demand_rating") + "rental_demand_rating".Length, 15);
                        //    Pos1 = propData_Prices.IndexOf(':') + 1;
                        //    Pos2 = propData_Prices.IndexOf(',');
                        //    propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);

                        //    lb_Research_Demand_Rent.Text = propData_Prices;

                        //}


                        //Floor Areas
                        response = client.GetAsync("floor-areas?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("square_feet") + "square_feet".Length, 15);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                floor = propData_Prices;
                                if (floor.Contains("\""))
                                {
                                    floor = floor.Replace("\"", "");
                                }
                                if (floor.Contains("}"))
                                {
                                    floor = floor.Replace("}", "");
                                }
                                if (floor.Contains("{"))
                                {
                                    floor = floor.Replace("{", "");
                                }
                            }

                        }


                        //Title Info
                        response = client.GetAsync("title-info?key=" + propData_Key + "&postcode=" + postalCode).Result;

                        Thread.Sleep(3000);

                        if (response.IsSuccessStatusCode)
                        {
                            propData = response.Content.ReadAsStringAsync();

                            Thread.Sleep(3000);

                            propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("class") + "class".Length, 20);
                            Pos1 = propData_Prices.IndexOf(':') + 1;
                            Pos2 = propData_Prices.IndexOf(',');

                            if (Pos1 >= 0 && Pos2 >= 0)
                            {
                                propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);
                                title_info = propData_Prices;
                            }

                        }

                        ////Title Use Class
                        //response = client.GetAsync("title-use-class?key=" + propData_Key + "&postcode=" + postalCode).Result;
                        //if (response.IsSuccessStatusCode)
                        //{
                        //    propData = response.Content.ReadAsStringAsync();

                        //    propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("class") + "class".Length, 20);
                        //    Pos1 = propData_Prices.IndexOf(':') + 1;
                        //    Pos2 = propData_Prices.IndexOf(',');
                        //    propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);

                        //    lb_Research_Title_Info.Text = propData_Prices;

                        //}


                        ////Analyse Buildings
                        //response = client.GetAsync("title-use-class?key=" + propData_Key + "&postcode=" + postalCode).Result;
                        //if (response.IsSuccessStatusCode)
                        //{
                        //    propData = response.Content.ReadAsStringAsync();

                        //    propData_Prices = propData.Result.ToString().Substring(propData.Result.ToString().IndexOf("class") + "class".Length, 20);
                        //    Pos1 = propData_Prices.IndexOf(':') + 1;
                        //    Pos2 = propData_Prices.IndexOf(',');
                        //    propData_Prices = propData_Prices.Substring(Pos1, Pos2 - Pos1);

                        //    lb_Research_Title_Info.Text = propData_Prices;

                        //}
                    }

                    //prepare DIVs

                    System.Web.UI.HtmlControls.HtmlGenericControl newdivs = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    newdivs.Attributes.Add("class", "newResearch");
                    newdivs.ID = "createDiv";
                    newdivs.InnerHtml = "<div class='main'><div class='sides'><div class='tables'>" +
                        "" +
                        "<h2>Postal Code: " + postalCode.ToString() + "</h2>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>prices</div>" +
                        "<div class='el'>" + prices.ToString() + "</div>" +
                        "" +
                        "</div><div class='group'>" +
                        "<div class='el headings'>prices-per-sqf</div>" +
                        "<div class='el'>" + prices_sqf.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>sold-prices</div>" +
                        "<div class='el'>" + sold_prices.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>sold-prices-per-sqf</div>" +
                        "<div class='el'>" + sold_prices_sqf.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>growth</div>" +
                        "<div class='el'>" + growth.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>valuation-sale</div>" +
                        "<div class='el'>" + valuation.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>valuation-rent</div>" +
                        "<div class='el'>" + valuation_rent.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>rents</div>" +
                        "<div class='el'>" + rent.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>rents-hmo</div>" +
                        "<div class='el'>" + HMO.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>yields</div>" +
                        "<div class='el'>" + yeilds.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>lha-rate</div>" +
                        "<div class='el'>" + LHA.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>demand</div>" +
                        "<div class='el'>" + demand.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>demand-rent</div>" +
                        "<div class='el'>" + demand_rent.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>planning</div>" +
                        "<div class='el'>" + planning.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>floor-areas</div>" +
                        "<div class='el'>" + floor.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>title-info</div>" +
                        "<div class='el'>" + title_info.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>title-use-class</div>" +
                        "<div class='el'>" + titleUseClass.ToString() + "</div></div>" +
                        "" +
                        "<div class='group'>" +
                        "<div class='el headings'>analyse-buildings</div>" +
                        "<div class='el'>" + analyzeBuildings.ToString() + "</div></div>" +
                        "" +
                        "</div></div></div>";

                    newResearch.Controls.Add(newdivs);

                }


            }

        }

        private async Task chargeSearch(string compNumber)
        {
            CompaniesHouseClientResponse<CompaniesHouse.Response.Charges.Charges> charges_company_new = null;

            var settings = new CompaniesHouseSettings(api_key);

            using (var clientNew = new CompaniesHouseClient(settings))
            {
                charges_company_new = await clientNew.GetChargesListAsync(compNumber).ConfigureAwait(false);

            }
        }

        private async Task officerSearch(string compNumber)
        {
            try
            {
                CompaniesHouseClientResponse<CompaniesHouse.Response.Officers.Officers> officerList = null;

                string nameToSearchFor = compNumber;

                var settings = new CompaniesHouseSettings(api_key);

                using (var clientNew = new CompaniesHouseClient(settings))
                {
                    var request = new SearchRequest()
                    {
                        Query = nameToSearchFor,
                        StartIndex = 0,
                        ItemsPerPage = 10
                    };

                    officerListFinal = await clientNew.GetOfficersAsync(nameToSearchFor).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;

            }


        }
    }
}