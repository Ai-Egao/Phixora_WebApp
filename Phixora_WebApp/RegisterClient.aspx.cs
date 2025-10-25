using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Phixora_WebApp
{
    public partial class RegisterClient : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadClients();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Clients (FullName, Email, Phone, Address, Password) VALUES (@FullName, @Email, @Phone, @Address, @Password)", con);
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            txtFullName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";

            LoadClients();
        }

        private void LoadClients()
        {
            SqlCommand cmd = new SqlCommand("SELECT ClientID, FullName, Email, Phone, Address FROM Clients", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
