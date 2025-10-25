<%@ Page Title="Book Appointment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Appointments.aspx.cs" Inherits="Phixora_WebApp.Appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Book Appointment</h2>

    <table>
        <tr>
            <td>Client Name:</td>
            <td>
                <asp:TextBox ID="txtClientName" runat="server" ReadOnly="true" CssClass="readonlyBox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Profession:</td>
            <td>
                <asp:DropDownList ID="ddlProfession" runat="server"
                    DataTextField="CategoryName" DataValueField="CategoryName">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Date:</td>
            <td><asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Time:</td>
            <td><asp:TextBox ID="txtTime" runat="server" TextMode="Time"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnBook" runat="server" Text="Book Appointment" OnClick="btnBook_Click" />
            </td>
        </tr>
    </table>

    <hr />

    <h3>Your Appointments</h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" CssClass="table table-bordered"></asp:GridView>

</asp:Content>
 