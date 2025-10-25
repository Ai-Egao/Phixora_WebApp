<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientDashboard.aspx.cs" Inherits="Phixora_WebApp.ClientDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <h2>Welcome, <asp:Label ID="lblName" runat="server" /></h2>

<hr />

<h3>Book a Service</h3>
<asp:Button ID="btnBook" runat="server" Text="Book Appointment" PostBackUrl="~/Appointments.aspx" />

<h3>Your Appointments</h3>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>

</asp:Content>
