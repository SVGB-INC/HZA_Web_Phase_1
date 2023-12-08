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
    public partial class sign_up : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string encryptpass(string password)
        {
            string msg = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                string strConnString = ConfigurationManager.ConnectionStrings["MySQL_HZA"].ConnectionString;
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = strConnString;

                MySqlCommand cmd = new MySqlCommand("select * from user_data where user_name=@username", conn);
                cmd.Parameters.AddWithValue("@username", username.Text.Trim());

                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);

                conn.Open();

                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();

                sda.Fill(dt);

                conn.Close();

                if (dt.Rows.Count > 0)
                {
                    lblMessage.Text = "This username already exists.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    cmd = new MySqlCommand("select * from user_data where user_email=@useremail", conn);
                    cmd.Parameters.AddWithValue("@useremail", email.Text.Trim());

                    sda = new MySqlDataAdapter(cmd);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    dt = new DataTable();

                    sda.Fill(dt);

                    conn.Close();

                    if (dt.Rows.Count > 0)
                    {
                        lblMessage.Text = "This useremail already exists.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        if (password.Text.Trim() == confirm_password.Text.Trim())
                        {
                            cmd = new MySqlCommand("insert into user_data (user_name,user_email,user_password, user_key) values(@username,@useremail,@userpass, @userkey)", conn);
                            cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                            cmd.Parameters.AddWithValue("@useremail", email.Text.Trim());
                            cmd.Parameters.AddWithValue("@userpass", encryptpass(password.Text.Trim()));
                            cmd.Parameters.AddWithValue("@userkey", api_key.Text.Trim());


                            conn.Open();

                            cmd.ExecuteReader();

                            conn.Close();

                            Response.Redirect("index.aspx");

                        }
                        else
                        {
                            lblMessage.Text = "Please enter same passowrds.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
           
        }
    }
}