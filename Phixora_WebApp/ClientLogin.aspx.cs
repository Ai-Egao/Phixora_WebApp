using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Phixora_WebApp
{
    public partial class ClientLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Clients WHERE Email=@Email AND Password=@Password", con);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Successful login
                Session["ClientID"] = dt.Rows[0]["ClientID"].ToString();
                Session["ClientName"] = dt.Rows[0]["FullName"].ToString();

                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Login successful! Redirecting...";

                Response.Redirect("ClientDashboard.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid email or password!";
            }
        }
    }
}
