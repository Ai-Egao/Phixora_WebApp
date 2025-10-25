using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Phixora_WebApp
{
    public partial class WorkerDashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["WorkerID"] == null)
            {
                Response.Redirect("WorkerLogin.aspx");
            }

            if (!IsPostBack)
            {
                lblName.Text = Session["WorkerName"].ToString();
                lblProfession.Text = Session["Profession"].ToString();
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Appointments WHERE Profession=@Profession", con);
            cmd.Parameters.AddWithValue("@Profession", Session["Profession"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // 📍 Save worker's current location into WorkerLocation table
        protected void btnSaveLocation_Click(object sender, EventArgs e)
        {
            string workerID = Session["WorkerID"].ToString();
            string latitude = hfLatitude.Value;
            string longitude = hfLongitude.Value;

            if (!string.IsNullOrEmpty(latitude) && !string.IsNullOrEmpty(longitude))
            {
                // Check if this worker already has a location entry
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM WorkerLocation WHERE WorkerID = @WorkerID", con);
                checkCmd.Parameters.AddWithValue("@WorkerID", workerID);
                con.Open();
                int count = (int)checkCmd.ExecuteScalar();
                con.Close();

                SqlCommand cmd;
                if (count > 0)
                {
                    // Update existing location
                    cmd = new SqlCommand(
                        "UPDATE WorkerLocation SET Latitude=@Latitude, Longitude=@Longitude, UpdatedAt=GETDATE() WHERE WorkerID=@WorkerID", con);
                }
                else
                {
                    // Insert new location record
                    cmd = new SqlCommand(
                        "INSERT INTO WorkerLocation (WorkerID, Latitude, Longitude, UpdatedAt) VALUES (@WorkerID, @Latitude, @Longitude, GETDATE())", con);
                }

                cmd.Parameters.AddWithValue("@WorkerID", workerID);
                cmd.Parameters.AddWithValue("@Latitude", latitude);
                cmd.Parameters.AddWithValue("@Longitude", longitude);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('✅ Location saved successfully!');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('⚠️ Please click Get My Location first.');", true);
            }
        }

    }
}
