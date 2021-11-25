using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction_Web_PhamHaiDangBTL
{
    public partial class LoginView : System.Web.UI.Page
    {
        private string SQLConnectionString;
        private SqlConnection SQLConnection;

        private String SQLQuery;
        private SqlCommand SQLCommand;
        private SqlDataReader SQLReader;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        private bool checkLogin()
        {
            Dictionary<string, LoginLimit> ip_Limit = (Dictionary<string, LoginLimit>)Application["Ip_Limit"];
            String ip = GetIPAddress();
            if (ip_Limit.ContainsKey(ip))
            {
                LoginLimit loginLimit = ip_Limit[ip];
                if (loginLimit.timeLimit.ToString().Equals("1/1/0001 12:00:00 AM") ||
                    loginLimit.timeLimit.ToString().Equals("01/01/0001 12:00:00 SA"))
                {
                    return true;
                }

                if (loginLimit.timeLimit <= DateTime.Now)
                {
                    loginLimit.failCount = 0;
                    loginLimit.timeLimit = new DateTime();
                    String time = loginLimit.timeLimit.ToString();

                    return true;
                }
                else
                {
                    Label1.Text = "Vui lòng đăng nhập vào sau lúc " + loginLimit.timeLimit;
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (checkLogin())
            {
                SQLConnectionString = WebConfigurationManager.ConnectionStrings["AuctionWebsite"].ConnectionString;
                SQLConnection = new SqlConnection(SQLConnectionString);

                SQLQuery = "SELECT ID, NAME, USERNAME FROM PERSON WHERE PERSON.USERNAME = '" + Username.Text.Trim() + "' AND PERSON.PASSWORD = '" + Password.Text + "'";
                SQLCommand = new SqlCommand(SQLQuery, SQLConnection);

                SQLConnection.Open();
                SQLReader = SQLCommand.ExecuteReader();
                if (SQLReader.HasRows && SQLReader.Read())
                {
                    Session["UserID"] = SQLReader.GetInt32(0);
                    Session["Username"] = SQLReader.GetString(2);
                    SQLConnection.Close();
                    Session["loginTime"] = DateTime.Now;
                    Server.Transfer("HomePage.aspx");
                }
                else
                {
                    ValidationMessage.Text = "Invalid Username or Password Provided.";
                    Dictionary<string, LoginLimit> ip_Limit = (Dictionary<string, LoginLimit>)Application["Ip_Limit"];
                    String ip = GetIPAddress();
                    LoginLimit loginLimit;
                    if (ip_Limit.ContainsKey(ip))
                    {
                        loginLimit = ip_Limit[ip];
                    }
                    else
                    {
                        loginLimit = new LoginLimit();
                        ip_Limit.Add(ip, loginLimit);
                    }
                    if (loginLimit.failCount < int.Parse(System.Configuration.ConfigurationManager.AppSettings["K"]))
                    {
                        loginLimit.failCount = loginLimit.failCount + 1;
                    }
                    else
                    {
                        loginLimit.timeLimit = DateTime.Now.AddMinutes(int.Parse(System.Configuration.ConfigurationManager.AppSettings["T"]));
                    }

                    SQLConnection.Close();
                }
            }
        }
    }
}