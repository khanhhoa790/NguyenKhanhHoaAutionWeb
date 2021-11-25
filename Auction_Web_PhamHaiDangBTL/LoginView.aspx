<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="Auction_Web_PhamHaiDangBTL.LoginView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="HomePage.aspx" class="breadcrumb" runat="server" style="line-height:35px; color: #808080">Return to Home Page</a>
    <hr/><h1 class="text-center">Login to Auction Website</h1><hr/>
    <div class="container">
        <div class="form-horizontal" style="margin-top: 10px;">
           <div class="form-group">
                <label for="Username" class="col-sm-2 control-label">Username</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="Username" runat="server" CssClass="form-control" placeholder="Username" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Username" ErrorMessage="Nhap User" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>
            </div>
            <div class="form-group">
                <label for="Password" class="col-sm-2 control-label">Password</label> 
                <div class="col-sm-4">
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" ErrorMessage="Nhap Password" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Label ID="ValidationMessage" runat="server" CssClass="text-danger"></asp:Label>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="Login" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="Login_Click"/>
                </div>
            </div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        
    </div>
</asp:Content>
