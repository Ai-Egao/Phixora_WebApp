using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

namespace Phixora_WebApp
{
    public partial class WorkerLocation : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["WorkerID"] == null)
                Response.Redirect("WorkerLogin.aspx");
        }

        protected void btnSaveLocation_Click(object sender, EventArgs e)
        {
            string workerID = Session["WorkerID"].ToString();
            string latitude = hfLatitude.Value;
            string longitude = hfLongitude.Value;

            if (!string.IsNullOrEmpty(latitude) && !string.IsNullOrEmpty(longitude))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO WorkerLocation (WorkerID, Latitude, Longitude, UpdatedAt) VALUES (@WorkerID, @Latitude, @Longitude, GETDATE())", con);

                cmd.Parameters.AddWithValue("@WorkerID", workerID);
                cmd.Parameters.AddWithValue("@Latitude", latitude);
                cmd.Parameters.AddWithValue("@Longitude", longitude);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
