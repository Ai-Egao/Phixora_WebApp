<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Phixora_WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        /* Page container */
        .form-container {
            max-width: 500px;
            margin: 60px auto;
            padding: 30px;
            background-color: #f8f9fa;
            border-radius: 12px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
            text-align: center;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        /* Heading */
        h2 {
            color: #333;
            margin-bottom: 25px;
        }

        /* Label and input styling */
        asp\:Label, label {
            font-weight: 500;
            color: #444;
        }

        input[type="text"], select {
            width: 80%;
            padding: 10px;
            margin-top: 8px;
            border: 1px solid #ccc;
            border-radius: 6px;
            font-size: 14px;
            transition: border-color 0.3s ease;
        }

        input[type="text"]:focus, select:focus {
            border-color: #007bff;
            outline: none;
        }

        /* Button styling */
        input[type="submit"], .aspNetButton, button, .aspNetButton:focus {
            background-color: #007bff;
            color: white;
            padding: 10px 25px;
            border: none;
            border-radius: 6px;
            font-size: 15px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        input[type="submit"]:hover, .aspNetButton:hover {
            background-color: #0056b3;
        }

        /* Greeting label */
        #Label2 {
            display: block;
            margin-top: 20px;
            font-size: 16px;
            color: #007bff;
            font-weight: bold;
        }
    </style>

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

