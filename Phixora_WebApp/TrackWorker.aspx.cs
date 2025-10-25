using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Phixora_WebApp
{
    public partial class TrackWorker : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void btnTrack_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtWorkerID.Text))
            {
                lblMessage.Text = "Please enter a valid Worker ID.";
                pnlLocation.Visible = false;
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 Latitude, Longitude, UpdatedAt FROM WorkerLocation WHERE WorkerID = @WorkerID ORDER BY UpdatedAt DESC", con);
            cmd.Parameters.AddWithValue("@WorkerID", txtWorkerID.Text);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblLatitude.Text = dr["Latitude"].ToString();
                lblLongitude.Text = dr["Longitude"].ToString();
                lblUpdatedAt.Text = Convert.ToDateTime(dr["UpdatedAt"]).ToString("g");

                pnlLocation.Visible = true;
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "No location record found for this worker.";
                pnlLocation.Visible = false;
            }

            con.Close();
        }
    }
}
