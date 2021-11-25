<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaster.Master" AutoEventWireup="true" CodeBehind="RegisterView.aspx.cs" Inherits="Auction_Web_PhamHaiDangBTL.RegisterView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-horizontal" style="margin-top: 10px;"> 
             <div style="margin: 20px 40px 20px 20px; padding: 20px 40px 20px 20px;">
            <fieldset>
                <legend>Basic Information</legend>
                <div class="form-group">
                    <label for="Name" class="col-sm-2 control-label">Name</label>
                    <asp:TextBox ID="Name" runat="server" CssClass="form-control col-sm-10" style="width: 50%;"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="Username" class="col-sm-2 control-label">Username</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="Username" runat="server" CssClass="form-control col-sm-5" style="width: 50%;"></asp:TextBox>
                        <asp:Label ID="UsernameValidation" runat="server" CssClass="col-sm-5 text-danger" style="line-height: 35px;"></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <label for="Password" class="col-sm-2 control-label">Password</label>
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control col-sm-10" style="width: 50%;" TextMode="Password"></asp:TextBox>
                </div>
             </fieldset>
            <fieldset>
                <legend>Contact Info</legend>
                <fieldset class="col-sm-offset-1">
                    <legend>Address</legend>
                    <div class="form-group">
                        <label for="Street" class="col-sm-2 control-label">Street</label>
                        <asp:TextBox ID="Street" runat="server" CssClass="form-control col-sm-10" style="width: 50%;"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="City" class="col-sm-2 control-label">City</label>
                        <asp:TextBox ID="City" runat="server" CssClass="form-control col-sm-10" style="width: 50%;"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="State" class="col-sm-2 control-label">State</label>
                        <asp:TextBox ID="State" runat="server" CssClass="form-control col-sm-10" style="width: 50%;"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ZIP" class="col-sm-2 control-label">ZIP</label>
                        <asp:TextBox ID="ZIP" runat="server" CssClass="form-control col-sm-10" style="width: 50%;" placeholder="VD:123"></asp:TextBox>
                    </div>
                </fieldset>
                <fieldset class="col-sm-offset-1">
                    <legend>Communications</legend>
                    <div class="form-group">
                        <label for="Email" class="col-sm-2 control-label">Email</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="Email" runat="server" CssClass="form-control col-sm-5" style="width: 50%;" TextMode="Email"></asp:TextBox>
                            <asp:Label ID="EmailValidation" runat="server" CssClass="col-sm-5 text-danger" style="line-height: 35px;"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="Telephone" class="col-sm-2 control-label">Telephone</label>
                        <asp:TextBox ID="Telephone" runat="server" CssClass="form-control col-sm-10" style="width: 50%;" TextMode="Phone"></asp:TextBox>
                    </div>
                </fieldset>
            </fieldset>
            <fieldset>
                <legend>Payment Information</legend>
                <div class="form-group">
                    <label for="OwnerName" class="col-sm-2 control-label">Owner Name</label>
                    <asp:TextBox ID="OwnerName" runat="server" CssClass="form-control col-sm-10" style="width: 50%;"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="CardNumber" class="col-sm-2 control-label">Card No.</label>
                    <asp:TextBox ID="CardNumber" runat="server" CssClass="form-control col-sm-10" style="width: 50%;" TextMode="Number"></asp:TextBox>
                </div>
                <div class="form-group form-inline">
                    <label for="ExpirationDate" class="col-sm-2 control-label">Expiration Date</label>
                    <asp:TextBox ID="ExpirationDate" runat="server" CssClass="form-control col-sm-10" TextMode="Month" style="width: 30%;"></asp:TextBox>
                </div>
            </fieldset>
            <hr/>
            <div class="form-group">
                <asp:Button ID="Register" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="Register_Click" />
            </div>
        </div>
        </div>
    </div>
</asp:Content>
