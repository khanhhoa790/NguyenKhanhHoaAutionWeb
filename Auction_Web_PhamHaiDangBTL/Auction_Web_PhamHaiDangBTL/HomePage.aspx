<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Auction_Web_PhamHaiDangBTL.HomePage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 style="margin: 50px auto; text-align: center; color: #c3c3c3">CÁC TÁC VỤ CÓ THỂ THỰC HIỆN</h1>
        <div class="container-fluid" style="margin-top: 20px; margin-bottom: 50px">
            <div class="row" style="margin: 0 10px 0 10px; padding: 10px 0 10px 0;">
            <asp:Panel ID="BuyerOptions" runat="server">
                <h2>Buyer Options</h2>
                <a href="ItemListView.aspx" style="display: inherit;">List of Items</a>
            </asp:Panel>
            <asp:Panel ID="SellerOptions" runat="server">
                <h2>Seller Options</h2>
                <a href="AddItemPage.aspx" style="display: inherit;">Add An Item To Sell</a>
                <a href="ViewAllUserPosts.aspx" style="display: inherit;">View All Of Your Posts</a>
            </asp:Panel>
            <asp:Panel ID="AccountManagement" runat="server">
                <h2>Account Management</h2>
                <a href="UpdateUser.aspx" style="display: inherit;">Update Username/Password</a>
                <a href="UpdateContactInfo.aspx" style="display: inherit;">Update Contact Info</a>
                <a href="UpdateAddressInfo.aspx" style="display: inherit;">Update Address</a>
                <a href="UpdateCreditCard.aspx" style="display: inherit;">Update Credit Card Info</a>
            </asp:Panel>
            <asp:Panel ID="BAStatistics" runat="server">
                <h2>BA Statistics</h2>
                <a href="MostActiveBuyers.aspx" style="display: inherit;">Top 5 Most Active Buyers</a>
                <a href="MostActiveSellers.aspx" style="display: inherit;">Top 5 Most Active Sellers</a>
                <a href="MostPopularSellers.aspx" style="display: inherit;">Top 5 Most Popular Sellers</a>
                <a href="MostExpensiveItemsSold.aspx" style="display: inherit;">Top 5 Most Expensive Items Sold</a>
                <a href="MostExpensiveItemsAvailable.aspx" style="display: inherit;">Top 5 Most Expensive Items Available</a>
                <a href="MostAffordableItemsSold.aspx" style="display: inherit;">Top 5 Most Affordable Items Sold</a>
                <a href="MostAffordableItemsAvailable.aspx" style="display: inherit;">Top 5 Most Affordable Items Available</a>
            </asp:Panel>
           </div>
        </div>
      
</asp:Content>
