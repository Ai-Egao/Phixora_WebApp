<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Phixora_WebApp.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div style="max-width:400px; margin:80px auto; background-color:#fff; padding:25px; border-radius:10px; box-shadow:0 0 10px rgba(0,0,0,0.2);">
        <h2 style="text-align:center; margin-bottom:20px;">Admin Login</h2>

        <div>
            <asp:Label ID="Label1" runat="server" Text="Username:" AssociatedControlID="txtUsername"></asp:Label><br />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Placeholder="Enter username" />
        </div>
        <br />
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password:" AssociatedControlID="txtPassword"></asp:Label><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Enter password" />
        </div>
        <br />
        <div style="text-align:center;">
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
        </div>
        <br />
        <asp:Label ID="lblError" runat="server" ForeColor="Red" Font-Bold="true" Style="display:block; text-align:center;"></asp:Label>
    </div>

</asp:Content>
