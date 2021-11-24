using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction_Web_PhamHaiDangBTL
{
    public partial class HomePage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null || Session["UserID"] != null)
            {
                AccountManagement.Visible = true;
                SellerOptions.Visible = true;
                BuyerOptions.CssClass = " col-md-3 text-center";
                SellerOptions.CssClass = "col-md-3 text-center";
                AccountManagement.CssClass = "col-md-3 text-center";
                BAStatistics.CssClass = "col-md-3 text-center";
            }
            else
            {
                AccountManagement.Visible = false;
                SellerOptions.Visible = false;
                BuyerOptions.CssClass = "col-md-offset-4 col-md-2 text-center";
                SellerOptions.CssClass = "col-md-offset-4 col-md-2 text-center";
                AccountManagement.CssClass = "col-md-4 text-center";
                BAStatistics.CssClass = "col-md-4 text-center";
            }
        }

      
    }
}