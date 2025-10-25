<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkerLogin.aspx.cs" Inherits="Phixora_WebApp.WorkerLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Worker Login</h2>

<table>
    <tr>
        <td>Phone:</td>
        <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
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
