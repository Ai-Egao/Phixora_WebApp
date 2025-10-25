using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Phixora_WebApp
{
    public partial class ClientDashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClientID"] == null)
            {
                Response.Redirect("ClientLogin.aspx");
            }

            if (!IsPostBack)
            {
                lblName.Text = Session["ClientName"].ToString();
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Appointments WHERE ClientName=@ClientName", con);
            cmd.Parameters.AddWithValue("@ClientName", Session["ClientName"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}
