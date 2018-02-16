<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProgramDetails.aspx.cs" Inherits="BupaAssignment.ProgramDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Program details
    </h1>
    <hr />
    <div id="MessageBox">
        <p>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
    </div>
    <div class="container">
        <table class="table table-hover">
            <asp:Repeater ID="rptrPrograms" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>Program Name</td>
                        <td><%# Eval("Name") %></td>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td><%# Eval("Description")%></td>
                    </tr>
                    <tr>
                        <td>Start Time</td>
                        <td><%# Convert.ToDateTime(Eval("StartTime")).ToString("hh:mm tt")%></td>
                    </tr>
                    <tr>
                        <td>End Time</td>
                        <td><%# Convert.ToDateTime(Eval("EndTime")).ToString("hh:mm tt")%></td>
                    </tr>
                    <tr>
                        <td>On Air Now</td>
                        <td><%# Convert.ToBoolean(Eval("IsOnAirNow"))==true ? "Yes" : "No" %></td>
                    </tr>
                    <tr>
                        <td>Program Image</td>
                        <td><%# Convert.ToString(Eval("ProgramImage"))=="" ? "No Image": Eval("ProgramImage")%></td>
                    </tr>
                    <tr>
                        <td>Paid Program</td>
                        <td><%# Convert.ToBoolean(Eval("IsPaidProgram"))==true ? "Yes" : "No" %></td>
                    </tr>

                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div>
        <p>
            <a href="/programs">Back to list</a>
        </p>
    </div>
</asp:Content>
