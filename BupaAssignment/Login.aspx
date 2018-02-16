<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BupaAssignment.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .row {
            padding-bottom: 20px;
        }
    </style>
    <h1>Login</h1>
    <hr />
    <div id="MessageBox">
        <p>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
    </div>
    <div class="container">
        <div class="row control-group">
            <div class="col-md-2">
                <asp:Label ID="lblUsername" runat="server" Text="Username :" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="UserName"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:RequiredFieldValidator ID="reqTxtUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Required" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexTxtUserName" runat="server" ControlToValidate="txtUserName" ValidationExpression="^[a-zA-Z0-9]+$" ErrorMessage="Username can contain any letters or numbers, without spaces" ValidationGroup="vgLogin"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row control-group">
            <div class="col-md-2">
                <asp:Label ID="lblPassword" runat="server" Text="Password :" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:RequiredFieldValidator ID="reqTxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Required" ValidationGroup="vgLogin"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row control-group">
            <div class="col-md-2">&nbsp;</div>
            <div class="controls">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>
</asp:Content>

