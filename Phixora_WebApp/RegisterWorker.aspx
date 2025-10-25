<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterWorker.aspx.cs" Inherits="Phixora_WebApp.RegisterWorker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <h2>Worker Registration</h2>

<table>
    <tr>
        <td>Full Name:</td>
        <td><asp:TextBox ID="txtFullName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Profession:</td>
        <td>
            <asp:DropDownList ID="ddlProfession" runat="server" DataTextField="CategoryName" DataValueField="CategoryName"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Phone:</td>
        <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>CNIC:</td>
        <td><asp:TextBox ID="txtCNIC" runat="server"></asp:TextBox></td>
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
        <td><asp:Button ID="btnRegister" runat="server" Text="Register Worker" OnClick="btnRegister_Click" /></td>
    </tr>
</table>

<hr />

<h3>Registered Workers</h3>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>



</asp:Content>
