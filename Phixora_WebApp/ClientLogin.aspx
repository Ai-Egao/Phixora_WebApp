<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientLogin.aspx.cs" Inherits="Phixora_WebApp.ClientLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Client Login</h2>

<table>
    <tr>
        <td>Email:</td>
        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Password:</td>
        <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </td>
    </tr>
</table>

<br />

<asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

</asp:Content>
