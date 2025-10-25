using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
 
namespace Phixora_WebApp
{
    public partial class Appointments : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect to login if client not logged in
            if (Session["ClientID"] == null)
            {
                Response.Redirect("ClientLogin.aspx");
            }

            if (!IsPostBack)
            {
                // Display logged-in client’s name
                txtClientName.Text = Session["ClientName"].ToString();

                // Load dropdown and appointments
                LoadProfessions();
                LoadAppointments();
            }
        }

        // Load available professions from Categories table
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

        // Book a new appointment
        protected void btnBook_Click(object sender, EventArgs e)
        {
            string clientID = Session["ClientID"].ToString();
            string clientName = Session["ClientName"].ToString();

            if (ddlProfession.SelectedIndex == 0 || string.IsNullOrEmpty(txtDate.Text) || string.IsNullOrEmpty(txtTime.Text))
            {
                // Basic input validation
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Appointments (ClientID, ClientName, Profession, Date, Time, Status) " +
                "VALUES (@ClientID, @ClientName, @Profession, @Date, @Time, 'Pending')", con);

            cmd.Parameters.AddWithValue("@ClientID", clientID);
            cmd.Parameters.AddWithValue("@ClientName", clientName);
            cmd.Parameters.AddWithValue("@Profession", ddlProfession.SelectedValue);
            cmd.Parameters.AddWithValue("@Date", txtDate.Text);
            cmd.Parameters.AddWithValue("@Time", txtTime.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            // Reset input fields
            ddlProfession.SelectedIndex = 0;
            txtDate.Text = "";
            txtTime.Text = "";

            LoadAppointments();
        }

        // Load all appointments for this client
        private void LoadAppointments()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT AppointmentID, Profession, Date, Time, Status " +
                "FROM Appointments WHERE ClientID = @ClientID", con);

            cmd.Parameters.AddWithValue("@ClientID", Session["ClientID"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
