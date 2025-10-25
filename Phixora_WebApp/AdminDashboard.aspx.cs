using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Phixora_WebApp
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Admin"] == null)
            //    Response.Redirect("AdminLogin.aspx");

            if (!IsPostBack)
                ShowPanel("categories");
        }

        // Show specific section
        private void ShowPanel(string panel)
        {
            pnlCategories.Visible = panel == "categories";
            pnlClients.Visible = panel == "clients";
            pnlWorkers.Visible = panel == "workers";
            pnlAppointments.Visible = panel == "appointments";

            if (panel == "categories") LoadCategories();
            if (panel == "clients") LoadClients();
            if (panel == "workers") LoadWorkers();
            if (panel == "appointments") LoadAppointments();
        }

        // NAVIGATION BUTTONS
        protected void btnCategories_Click(object sender, EventArgs e) => ShowPanel("categories");
        protected void btnClients_Click(object sender, EventArgs e) => ShowPanel("clients");
        protected void btnWorkers_Click(object sender, EventArgs e) => ShowPanel("workers");
        protected void btnAppointments_Click(object sender, EventArgs e) => ShowPanel("appointments");

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("AdminLogin.aspx");
        }

        // ========== CATEGORIES CRUD ==========
        private void LoadCategories()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvCategories.DataSource = dt;
            gvCategories.DataBind();
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategory.Text))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@name)", con);
                cmd.Parameters.AddWithValue("@name", txtCategory.Text);
                con.Open(); cmd.ExecuteNonQuery(); con.Close();
                txtCategory.Text = "";
                LoadCategories();
            }
        }

        protected void gvCategories_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvCategories.EditIndex = e.NewEditIndex;
            LoadCategories();
        }

        protected void gvCategories_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvCategories.EditIndex = -1;
            LoadCategories();
        }

        protected void gvCategories_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvCategories.DataKeys[e.RowIndex].Value);
            TextBox txtName = (TextBox)gvCategories.Rows[e.RowIndex].Cells[1].Controls[0];
            SqlCommand cmd = new SqlCommand("UPDATE Categories SET CategoryName=@name WHERE CategoryID=@id", con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open(); cmd.ExecuteNonQuery(); con.Close();
            gvCategories.EditIndex = -1;
            LoadCategories();
        }

        protected void gvCategories_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCategories.DataKeys[e.RowIndex].Value);
            SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE CategoryID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open(); cmd.ExecuteNonQuery(); con.Close();
            LoadCategories();
        }

        // ========== VIEW CLIENTS ==========
        private void LoadClients()
        {
            SqlCommand cmd = new SqlCommand("SELECT ClientID, FullName, Email, Phone, Address FROM Clients", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvClients.DataSource = dt;
            gvClients.DataBind();
        }

        // ========== VIEW WORKERS ==========
        private void LoadWorkers()
        {
            SqlCommand cmd = new SqlCommand("SELECT WorkerID, FullName, Phone, Profession FROM Workers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvWorkers.DataSource = dt;
            gvWorkers.DataBind();
        }

        // ========== VIEW APPOINTMENTS ==========
        private void LoadAppointments()
        {
            SqlCommand cmd = new SqlCommand("SELECT AppointmentID, ClientName, Profession, Date, Time, Status FROM Appointments", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvAppointments.DataSource = dt;
            gvAppointments.DataBind();
        }
    }
}
