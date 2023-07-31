using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace library1
{
    public partial class Bookauthor : System.Web.UI.Page
    {

        SQLHelper obj = new SQLHelper();
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["Connect"]);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                bindRegisterGrid();
                
            }
        }
        protected void bindRegisterGrid()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Book Author] ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gvRegister.DataSource = dt;
                gvRegister.DataBind();
            }
            catch (Exception ex)
            {
                string sVa = ex.ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "otheralert('" + sVa + "');", true);
            }
        }


        protected void btngo_Click(object sender, EventArgs e)
        {
            {
                DataTable dt = new DataTable();
                try
                {
                    if (btngo.Text == "Submit")
                    {
                        SqlCommand cmd = new SqlCommand("sp_bookauthor", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QueryType", "Insert");
                        cmd.Parameters.AddWithValue("id", "0");
                        cmd.Parameters.AddWithValue("@AuthorName", Textaname.Text);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i >= 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert('Inserted Successfully');", true);
                            Textaname.Text = string.Empty;
                            bindRegisterGrid();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert('Oops!Sorry Process Failed ');", true);
                            return;
                        }
                    }
                    else if (btngo.Text == "Update")
                    {

                        SqlCommand cmd1 = new SqlCommand("sp_bookauthor", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@QueryType", "Update");
                        cmd1.Parameters.AddWithValue("@id", hfid.Value);
                        cmd1.Parameters.AddWithValue("@AuthorName", Textaname.Text.ToString());
                        con.Open();
                        int i = cmd1.ExecuteNonQuery();
                        con.Close();
                        if (i >= 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert('Updated Successfully')", true);
                            Textaname.Text = string.Empty;

                            bindRegisterGrid();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert('Oops!Sorry Process Failed ');", true);
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "otheralert('" + ex + "');", true);
                }

            }
        }

        protected void gvRegister_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            hfid.Value = gvRegister.DataKeys[e.RowIndex]["id"].ToString();
            SqlCommand cmd1 = new SqlCommand("sp_bookauthor", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@QueryType", "Delete");
            cmd1.Parameters.AddWithValue("@id", hfid.Value);
            cmd1.Parameters.AddWithValue("@AuthorName", "");
            con.Open();
            int i = cmd1.ExecuteNonQuery();
            con.Close();
            if (i >= 0)

            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "deletealert('Deleted Successfully');", true);


                Textaname.Text = string.Empty;
                bindRegisterGrid();
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert('Oops!Sorry Process Failed ');", true);
                return;
            }
        }

        protected void gvRegister_RowEditing(object sender, GridViewEditEventArgs e)
        {
            {

                Textaname.Text = gvRegister.DataKeys[e.NewEditIndex]["AuthorName"].ToString();
                hfid.Value = gvRegister.DataKeys[e.NewEditIndex]["id"].ToString();
                bindRegisterGrid();
                btngo.Text = "Update";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Textaname.Text = string.Empty;
            btngo.Text = "Sumbit";
            
        }
    }
}