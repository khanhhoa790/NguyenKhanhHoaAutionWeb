using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction_Web_PhamHaiDangBTL
{
    public partial class MostAffordableItemsSold : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null || Session["UserID"] != null)
            {
                Username.Text = "Logged in as: " + Session["Username"].ToString();
            }
        }
    }
}