using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Phixora_WebApp
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If already logged in, redirect to dashboard
            if (Session["AdminID"] != null)
            {
                Response.Redirect("AdminDashboard.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Hardcoded login (you can change)
            if (username == "ibtisam" && password == "1234560")
            {
                Session["AdminID"] = "1";
                Session["AdminName"] = "Administrator";
                Response.Redirect("AdminDashboard.aspx");
            }
            else
            {
                lblError.Text = "Invalid username or password!";
            }
        }
    }
}
