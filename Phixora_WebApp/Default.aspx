<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Phixora_WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  

    <!-- 🌟 Landing Section -->
    <div style="text-align:center; margin-top:60px;">
        <h1 style="font-size:2.5rem; color:#0d4a38; font-weight:bold;">Welcome to Phixora</h1>
        <p style="max-width:600px; margin:20px auto; font-size:1.1rem; line-height:1.6;">
            Phixora is your one-stop digital platform connecting clients with skilled professionals such as 
            plumbers, electricians, and carpenters. Whether you’re seeking reliable service or offering your expertise,
            Phixora makes the process simple, fast, and trustworthy.
        </p>
    </div>

    <hr style="margin:40px 0;" />

    <!-- 💼 Login Buttons Section -->
    <div style="text-align:center;">
        <h2 style="color:#0d4a38;">Login to Continue</h2>
        <p style="color:gray;">Choose your role to sign in</p>

        <div style="display:flex; justify-content:center; gap:40px; margin-top:30px; flex-wrap:wrap;">
            <asp:Button ID="btnClient" runat="server" Text="Client Login" CssClass="btn btn-success" OnClick="btnClient_Click"
                Style="min-width:150px; padding:12px 20px; font-size:1rem; border-radius:6px;" />
            
            <asp:Button ID="btnWorker" runat="server" Text="Worker Login" CssClass="btn btn-primary" OnClick="btnWorker_Click"
                Style="min-width:150px; padding:12px 20px; font-size:1rem; border-radius:6px;" />
            
            <asp:Button ID="btnAdmin" runat="server" Text="Admin Login" CssClass="btn btn-warning" OnClick="btnAdmin_Click"
                Style="min-width:150px; background-color:#9b59b6; border:none; padding:12px 20px; font-size:1rem; border-radius:6px; color:white;" />
        </div>

        <p style="text-align:center; margin-top:30px;">
            New to Phixora?
            <a href="Register.aspx" style="color:#0d4a38; text-decoration:none; font-weight:bold;">Register now</a>
        </p>
    </div>


</asp:Content>

