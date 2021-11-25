using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction_Web_PhamHaiDangBTL
{
    public partial class PageMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null || Session["UserID"] != null)
            {
                LoggedInAsLabel.Text = "Logged in as: " + Session["Username"].ToString();
                Login_Logout.Text = "Logout";

                Register.Enabled = false;
                Register.CssClass = "btn btn-default disabled";
            }
            else
            {
                LoggedInAsLabel.Text = "";
                Login_Logout.Text = "Login";

                Register.Enabled = true;
                Register.CssClass = "btn btn-default";

             
            }
        }

        protected void Login_Logout_Click(object sender, EventArgs e)
        {
            if (Session["Username"] != null || Session["UserID"] != null)
            {
                Session.Remove("UserID");
                Session.Remove("Username");
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Redirect("LoginView.aspx");
            }
        }
        protected void Unnamed1_Tick(object sender, EventArgs e)
        {
            if (Session["loginTime"] != null)
            {
                DateTime loginTime = (DateTime)Session["loginTime"];
                TimeSpan difference = DateTime.Now - loginTime;
                Label1.Text = "Thoi gian dang nhap : " + difference.Minutes + ":" + difference.Seconds;
            }

        }
    }
}