<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programs.aspx.cs" Inherits="BupaAssignment.Programs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Programs
    </h1>
    <hr />
    <div id="MessageBox">
        <p>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
    </div>
    <div class="container" id="dvPrivate" runat="server" visible="false">
        <h3>Private programs</h3>
        <table class="table table-hover">
            <tr>
                <th>Program Name</th>
                <th>Description</th>
                <th>Details</th>
            </tr>
            <asp:Repeater ID="rptrPrivatePrograms" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Description")%></td>
                        <td><a class="btn btn-primary" href="/programdetails?Id=<%# Eval("ProgramId")%>">View Details</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div class="container">
        <h3>Public programs</h3>
        <table class="table table-hover">
            <tr>
                <th>Program Name</th>
                <th>Description</th>
                <th>Details</th>
            </tr>
            <asp:Repeater ID="rptrPublicPrograms" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Description")%></td>
                        <td><a class="btn btn-primary" href="/programdetails?Id=<%# Eval("ProgramId")%>">View Details</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
</asp:Content>
