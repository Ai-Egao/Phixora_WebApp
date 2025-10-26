using System;
using System.Web.UI;

namespace Phixora_WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientLogin.aspx");
        }

        protected void btnWorker_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkerLogin.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }
    }
}
