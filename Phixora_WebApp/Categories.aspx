
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Phixora_WebApp.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2>Manage Categories</h2>

<asp:Label ID="Label1" runat="server" Text="Add a New Category:"></asp:Label>
<asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
<hr />

<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID"
    OnRowEditing="GridView1_RowEditing"
    OnRowCancelingEdit="GridView1_RowCancelingEdit"
    OnRowUpdating="GridView1_RowUpdating"
    OnRowDeleting="GridView1_RowDeleting"
    CssClass="table table-striped">

    <Columns>
        <asp:BoundField DataField="CategoryID" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>

     
     

</asp:Content>