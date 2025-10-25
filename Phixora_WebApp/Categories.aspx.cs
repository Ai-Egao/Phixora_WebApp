

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Phixora_WebApp
{
    public partial class Categories : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PhixoraConnection"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        } 

        // CREATE
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string category = txtCategory.Text.Trim();
            if (category != "")
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@name)", con);
                cmd.Parameters.AddWithValue("@name", category);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                txtCategory.Text = "";
                LoadCategories();
            }
        }

        // READ
        private void LoadCategories()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        // UPDATE
        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadCategories();
        }

        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadCategories();
        }

        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];

            SqlCommand cmd = new SqlCommand("UPDATE Categories SET CategoryName=@name WHERE CategoryID=@id", con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridView1.EditIndex = -1;
            LoadCategories();
        }

        // DELETE
        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            SqlCommand cmd = new SqlCommand("DELETE FROM Categories WHERE CategoryID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadCategories();
        }
    }
}
