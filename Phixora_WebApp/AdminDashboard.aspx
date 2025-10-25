<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Phixora_WebApp.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container mt-4">
        <h2>Welcome, Ibtisam </h2>
        <p class="lead">Manage all sections of Phixora from one place.</p>
        <hr />

        <!-- Navigation Buttons -->
        <div class="btn-group mb-4" role="group">
            <asp:Button ID="btnCategories" runat="server" Text="Manage Categories" CssClass="btn btn-primary" OnClick="btnCategories_Click" />
            <asp:Button ID="btnClients" runat="server" Text="View Clients" CssClass="btn btn-success" OnClick="btnClients_Click" />
            <asp:Button ID="btnWorkers" runat="server" Text="View Workers" CssClass="btn btn-info" OnClick="btnWorkers_Click" />
            <asp:Button ID="btnAppointments" runat="server" Text="View Appointments" CssClass="btn btn-warning" OnClick="btnAppointments_Click" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
        </div>

        <!-- MANAGE CATEGORIES -->
        <asp:Panel ID="pnlCategories" runat="server" Visible="false">
            <h3>Manage Categories</h3>
            <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control w-25 d-inline"></asp:TextBox>
            <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" CssClass="btn btn-primary" OnClick="btnAddCategory_Click" />
            <hr />
            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID"
                OnRowEditing="gvCategories_RowEditing"
                OnRowUpdating="gvCategories_RowUpdating"
                OnRowCancelingEdit="gvCategories_RowCancelingEdit"
                OnRowDeleting="gvCategories_RowDeleting"
                CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <!-- VIEW CLIENTS -->
        <asp:Panel ID="pnlClients" runat="server" Visible="false">
            <h3>Registered Clients</h3>
            <asp:GridView ID="gvClients" runat="server" AutoGenerateColumns="True" CssClass="table table-striped"></asp:GridView>
        </asp:Panel>

        <!-- VIEW WORKERS -->
        <asp:Panel ID="pnlWorkers" runat="server" Visible="false">
            <h3>Registered Workers</h3>
            <asp:GridView ID="gvWorkers" runat="server" AutoGenerateColumns="True" CssClass="table table-striped"></asp:GridView>
        </asp:Panel>

        <!-- VIEW APPOINTMENTS -->
        <asp:Panel ID="pnlAppointments" runat="server" Visible="false">
            <h3>All Appointments</h3>
            <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="True" CssClass="table table-striped"></asp:GridView>
        </asp:Panel>

    </div>



</asp:Content>
