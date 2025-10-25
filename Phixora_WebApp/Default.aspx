<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Phixora_WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  

    <div class="form-container">
        <h2>Welcome to Phixora</h2>

        <asp:Label ID="Label1" runat="server" Text="Enter your name: "></asp:Label><br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br /><br />

        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Select Profession" Value=""></asp:ListItem>
            <asp:ListItem Text="Plumber" Value="Plumber"></asp:ListItem>
            <asp:ListItem Text="Electrician" Value="Electrician"></asp:ListItem>
            <asp:ListItem Text="Carpenter" Value="Carpenter"></asp:ListItem>
        </asp:DropDownList>
        <br /><br />

        <asp:Button ID="Button1" runat="server" Text="Greet Me" CssClass="aspNetButton" OnClick="Button1_Click" />
        <br /><br />

        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>

