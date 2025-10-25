<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterClient.aspx.cs" Inherits="Phixora_WebApp.RegisterClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Client Registration</h2> 

<table>
    <tr>
        <td>Full Name:</td>
        <td><asp:TextBox ID="txtFullName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Email:</td>
        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Phone:</td>
        <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Address:</td>
        <td><asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="2" Columns="30"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Password:</td>
        <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnRegister" runat="server" Text="Register Client" OnClick="btnRegister_Click" /></td>
    </tr>
</table>

<hr />

<h3>Registered Clients</h3>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>

</asp:Content>
