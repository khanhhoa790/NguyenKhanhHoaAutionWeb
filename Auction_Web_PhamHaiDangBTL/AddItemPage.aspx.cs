using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auction_Web_PhamHaiDangBTL
{
    public partial class AddItemPage : System.Web.UI.Page
    {
        private string SQLConnectionString;
        private SqlConnection SQLConnection;

        private String SQLQuery;
        private SqlCommand SQLCommand;
        private Int32 SQLResultID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null || Session["UserID"] != null)
            {
                Username.Text = "Logged in as: " + Session["Username"].ToString();
                OwnerName.Text = Session["Username"].ToString();
            }
        }

        protected void AddItemClick(object sender, EventArgs e)
        {
            // Make sure a user is logged in properly
            if (Session["Username"] == null || Session["UserID"] == null)
            {
                return;
            }

            DateTime startTime = DateTime.Parse(BidStartTime.Text);
            DateTime endTime = DateTime.Parse(BidEndTime.Text);

            if (startTime < DateTime.Now || startTime > endTime)
            {
                return;
            }

            if (Condition.Text.Trim() == "Explained" && Description.Text.Trim().Length < 1)
            {
                return;
            }

            SQLConnectionString = WebConfigurationManager.ConnectionStrings["AuctionWebsite"].ConnectionString;
            SQLConnection = new SqlConnection(SQLConnectionString);

            // Prepare to insert into strong entity ITEM
            SQLQuery = "INSERT INTO ITEM (NAME, CONDITION, INITIAL_PRICE, DESCRIPTION,QUANTITY,OWNER,BID_START_TIME,BID_END_TIME)" +
                       "VALUES ('" + Name.Text.Trim() + "', '" + Condition.Text.Trim() + "', '" +
                                       Price.Text.Trim().Replace("$", "") + "', '" + Description.Text.Trim() + "', '" +
                                       Quantity.Text.Trim() + "', '" + Session["UserID"] + "', '" +
                                       startTime.ToString("MM/dd/yyyy hh:mm:ss") + "', '" + endTime.ToString("MM/dd/yyyy hh:mm:ss") + "')" +
                       "SELECT CAST(scope_identity() as int)";
            SQLCommand = new SqlCommand(SQLQuery, SQLConnection);
            SqlDataAdapter ad = new SqlDataAdapter("select [NAME] from [dbo].[ITEM]", SQLConnection);
            DataSet ds = new DataSet();

            ad.Fill(ds);

            int flag = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (Name.Text == ds.Tables[0].Rows[i]["NAME"].ToString())
                {
                    flag = 1;
                    break;
                }
            }

            if (flag == 1)
            {
                Response.Write("<script>alert('Duplicated')</script>");
            }
            else
            {
                SQLConnection.Open();
                SQLResultID = (Int32)SQLCommand.ExecuteScalar();
                SQLConnection.Close();
                Response.Redirect("ItemListView.aspx");

            }
            // Perform insertion and return a FK reference for use in weak entity tables
            //SQLConnection.Open();
            //SQLResultID = (Int32)SQLCommand.ExecuteScalar();
            //SQLConnection.Close();

            // Prepare to insert into weak entity PERSON_CREDITCARD
            //SQLQuery = "INSERT INTO ITEM_PICTURE (ITEM_ID, LOCATION)" +
            //           "VALUES ('" + SQLResultID + "', '" + OwnerName.Text.Trim() + "')"; // Temporary
            //SQLCommand = new SqlCommand(SQLQuery, SQLConnection);

            // Perform insertion
            //SQLConnection.Open();
            //SQLCommand.ExecuteNonQuery();
            //SQLConnection.Close();

        }
    }
}