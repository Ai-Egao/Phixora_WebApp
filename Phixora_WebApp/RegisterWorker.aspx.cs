using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
 
namespace Phixora_WebApp
{
    public partial class RegisterWorker : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProfessions();
                LoadWorkers();
            }
        }

        // Load professions dynamically from Categories table
        private void LoadProfessions()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlProfession.DataSource = dt;
            ddlProfession.DataTextField = "CategoryName";
            ddlProfession.DataValueField = "CategoryName";
            ddlProfession.DataBind();
            ddlProfession.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Profession", ""));
        }

        // Register a new worker
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Workers (FullName, Profession, Phone, CNIC, Address, Password) VALUES (@FullName, @Profession, @Phone, @CNIC, @Address, @Password)", con);
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
            cmd.Parameters.AddWithValue("@Profession", ddlProfession.SelectedValue);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@CNIC", txtCNIC.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            txtFullName.Text = "";
            ddlProfession.SelectedIndex = 0;
            txtPhone.Text = "";
            txtCNIC.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";

            LoadWorkers();
        }

        // Display all registered workers
        private void LoadWorkers()
        {
            SqlCommand cmd = new SqlCommand("SELECT WorkerID, FullName, Profession, Phone, CNIC, Address FROM Workers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
