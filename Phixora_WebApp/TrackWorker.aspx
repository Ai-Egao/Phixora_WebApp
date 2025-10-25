<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackWorker.aspx.cs" Inherits="Phixora_WebApp.TrackWorker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Track Worker Location</h2>
    <p>Enter the Worker ID to view their latest location.</p>

    <asp:TextBox ID="txtWorkerID" runat="server" CssClass="form-control w-25 d-inline" placeholder="Enter Worker ID"></asp:TextBox>
    <asp:Button ID="btnTrack" runat="server" Text="Track" CssClass="btn btn-primary" OnClick="btnTrack_Click" />
    <hr />

    <asp:Panel ID="pnlLocation" runat="server" Visible="false">
        <h4>Worker’s Last Known Location:</h4>
        <p><strong>Latitude:</strong> <asp:Label ID="lblLatitude" runat="server" /></p>
        <p><strong>Longitude:</strong> <asp:Label ID="lblLongitude" runat="server" /></p>
        <p><strong>Last Updated:</strong> <asp:Label ID="lblUpdatedAt" runat="server" /></p>
    </asp:Panel>

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>


</asp:Content>
