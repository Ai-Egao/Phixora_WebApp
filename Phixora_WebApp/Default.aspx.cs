using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phixora_WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string profession = DropDownList1.SelectedValue;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(profession))
            {
                Label2.Text = "Hello, " + name + "! You selected " + profession + ".";
            }
            else
            {
                Label2.Text = "Please enter your name and select a profession.";
            }
        }

    }
}

    