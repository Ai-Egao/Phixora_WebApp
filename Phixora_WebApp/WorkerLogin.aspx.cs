using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Phixora_WebApp
{
    public partial class WorkerLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text.Trim();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Workers WHERE Phone=@Phone AND Password=@Password", con);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Login success
                Session["WorkerID"] = dt.Rows[0]["WorkerID"].ToString();
                Session["WorkerName"] = dt.Rows[0]["FullName"].ToString();
                Session["Profession"] = dt.Rows[0]["Profession"].ToString();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Login successful! Redirecting...";

                // Redirect to dashboard page (you’ll create it next)
                Response.Redirect("WorkerDashboard.aspx");
            }
            else
            {
                // Invalid login
                lblMessage.Text = "Invalid phone or password!";
            }
        }
    }
}
