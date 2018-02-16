﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="BupaAssignment.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .row {
            padding-bottom: 20px;
        }
    </style>
    <h1>Register</h1>
    <hr />
    <div id="MessageBox">
        <p>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
    </div>
    <div class="container">
        <div class="row control-group">
            <div class="col-md-2">
                <asp:Label ID="lbluserId" runat="server" Text="UserId :" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" Enabled="false" placeholder="UserId"></asp:TextBox>
            </div>
        </div>
        <div class="row control-group">
            <div class="col-md-2">
                <asp:Label ID="lblUsername" runat="server" Text="Username :" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Enabled="false" placeholder="UserName"></asp:TextBox>
            </div>
        </div>
        <div class="row control-group">
            <div class="col-md-2">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name :" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="FirstName"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:RequiredFieldValidator ID="reqTxtFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Required" ValidationGroup="vgMyProfile"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexTxtFirstName" runat="server" ControlToValidate="txtFirstName" ValidationExpression="^[a-zA-Z\s]+$" ErrorMessage="First name can contain any letters or spaces" ValidationGroup="vgMyProfile"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row control-group">
            <div class="col-md-2">
                <asp:Label ID="Label1" runat="server" Text="Last Name :" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="LastName"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:RequiredFieldValidator ID="reqTxtLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Required" ValidationGroup="vgMyProfile"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regTxtLastName" runat="server" ControlToValidate="txtLastName" ValidationExpression="^[a-zA-Z\s]+$" ErrorMessage="Last name can contain any letters spaces" ValidationGroup="vgMyProfile"></asp:RegularExpressionValidator>
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
                <asp:RequiredFieldValidator ID="reqTxtPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Required" ValidationGroup="vgMyProfile"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexTxtPassword" runat="server" ControlToValidate="txtPassword" ValidationExpression="((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20})" ErrorMessage="Password length should be atleast 6, contains at least one digit and contains at least one lower case and one upper case alphabet" ValidationGroup="vgMyProfile"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="row control-group">
            <div class="col-md-2">
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password :" CssClass="font-weight-bold"></asp:Label>
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:RequiredFieldValidator ID="reqTxtConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Required" ValidationGroup="vgMyProfile"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="compTxtConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match" ValidationGroup="vgMyProfile"></asp:CompareValidator>
            </div>
        </div>
        <div class="row control-group">
            <div class="controls">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
            </div>
        </div>
    </div>
</asp:Content>
