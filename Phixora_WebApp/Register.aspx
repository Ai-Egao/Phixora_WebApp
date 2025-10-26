<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Phixora_WebApp.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

    <div style="text-align:center; margin-top:50px;">
        <h1 style="color:#0d4a38;">Join Phixora Today</h1>
        <p style="max-width:600px; margin:20px auto; font-size:1.1rem;">
            Choose your role to start your journey with Phixora. Whether you're a skilled worker 
            looking for opportunities or a client needing reliable service — we’ve got you covered.
        </p>
    </div>

    <div style="display:flex; justify-content:center; gap:50px; margin-top:40px;">
        <!-- Register as Client Panel -->
        <div style="width:250px; padding:25px; border-radius:10px; box-shadow:0 0 10px rgba(0,0,0,0.2); background:#fff;">
            <h3>Register as Client</h3>
            <p>Book trusted professionals in your area.</p>
            <a href="RegisterClient.aspx" class="btn btn-success">Go to Client Form</a>
        </div>

        <!-- Register as Worker Panel -->
        <div style="width:250px; padding:25px; border-radius:10px; box-shadow:0 0 10px rgba(0,0,0,0.2); background:#fff;">
            <h3>Register as Worker</h3>
            <p>Join Phixora to offer your professional services.</p>
            <a href="RegisterWorker.aspx" class="btn btn-primary">Go to Worker Form</a>
        </div>
    </div>




</asp:Content>
