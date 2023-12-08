using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace HZA_Web_Phase_1
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {

                string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = strConnString;

                MySqlCommand cmd = new MySqlCommand("select * from user_data where user_name=@username and user_password=@userpass", conn);
                cmd.Parameters.AddWithValue("@username", email.Text.Trim());
                cmd.Parameters.AddWithValue("@userpass", encryptpass(password.Text.Trim()));

                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                conn.Open();

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();

                sda.Fill(dt);

                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    Session["username"] = email.Text.Trim();
                    Response.Redirect("single-comp-search.aspx", false);
                }
                else
                {
                    lblMessage.Text = "Your Username or Password is incorrect.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.InnerException.ToString();
                lblMessage.Text = msg;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                
            }



        }

        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }



        


    }
}