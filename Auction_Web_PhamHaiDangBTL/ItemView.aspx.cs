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
    
    public partial class ItemView : System.Web.UI.Page
    {
        private string connectionString;
        private SqlConnection connection;
        string item_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            string query;
            SqlCommand command;
            SqlDataReader reader;

            connectionString = WebConfigurationManager.ConnectionStrings["AuctionWebsite"].ConnectionString;
            connection = new SqlConnection(connectionString);

            item_id = Request.QueryString["id"];
            query = "SELECT * FROM ITEM WHERE ID='" + item_id + "'";
            command = new SqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read()) // only one row
                {
                    ItemName.Text = reader.GetString(1);
                    BidStartTime.Text = reader.GetDateTime(7).ToString("MM/dd/yyyy hh:mm:ss");
                    BidEndTime.Text = reader.GetDateTime(8).ToString("MM/dd/yyyy hh:mm:ss");
                }
                connection.Close();
            }
            else
            {
                ItemName.Text = "Unknown Item";
                connection.Close();
            }

            query = "SELECT * FROM HIGHEST_BIDDER WHERE ITEM_ID='" + item_id + "'";
            command = new SqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    HighestBid.Text = "$" + reader.GetSqlSingle(1).ToString();
                }
                connection.Close();
            }
            else
            {
                HighestBid.Text = "0.00";
                connection.Close();
            }
        }
        protected void BidController(object sender, EventArgs e)
        {
            string query;
            SqlCommand command;
            SqlDataReader reader;

            if (Session["UserID"] == null || Session["Username"] == null)
            {
                return;
            }

            int userID = (int)Session["UserID"];

            query = "SELECT * FROM PERSON_ITEM WHERE PERSON_ID=" + userID + " AND ITEM_ID=" + item_id;
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            bool hasrow = reader.HasRows;
            if (reader.HasRows)
            {
                connection.Close();
                if (Convert.ToSingle(NewBid.Text) > 0)
                {
                    query = "UPDATE PERSON_ITEM" +
                            " SET BID_AMOUNT=" +NewBid.Text+
                            " WHERE PERSON_ID = '" + Session["UserID"] +
                            "' AND ITEM_ID = '" + item_id + "'";
                    command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect("ItemListView.aspx");

                }
            }
            else
            {
                connection.Close();
                query = "INSERT INTO PERSON_ITEM (PERSON_ID, ITEM_ID, BID_AMOUNT)" +
                        "VALUES ('" + Session["UserID"] + "', '" + item_id + "', '" + NewBid.Text + "')";
                command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Server.Transfer("ItemListView.aspx");
            }
        }
    }
}