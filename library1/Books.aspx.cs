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
    public partial class Books : System.Web.UI.Page
    {
        SQLHelper obj = new SQLHelper();
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["Connect"]);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                bindRegisterGrid();
                ItemBind();

            }
        }
        protected void bindRegisterGrid()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT B.[Author Name] AS 'AuthorId',B.id,B.[Book Name],BA.AuthorName, B.Quantity From Books " +
                    "AS B Inner Join[Book Author] AS BA ON B.[Author Name] = BA.id ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                gvRegister.DataSource = dt;
                dt.DefaultView.Sort = "Book Name ASC";


                gvRegister.DataBind();
            }
            catch (Exception ex)
            {
                string sVa = ex.ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "otheralert('" + sVa + "');", true);
            }
        }
        protected void ItemBind()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "SELECT * FROM [Book Author]";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ddwnl.DataSource = dtbl;
                        ddwnl.DataTextField = "AuthorName";
                        ddwnl.DataValueField = "id";
                        ddwnl.DataBind();

                    }
                    else
                    {
                        ddwnl.DataBind();
                    }
                    ddwnl.Items.Insert(0, new ListItem("Select", "0"));

                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert('" + sError + "');", true);
                    return;
                }
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
                        SqlCommand cmd = new SqlCommand("sp_books", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QueryType", "Insert");
                        cmd.Parameters.AddWithValue("@id", "0");
                        cmd.Parameters.AddWithValue("@BookName", Textbookname.Text);
                        cmd.Parameters.AddWithValue("@AuthorName", ddwnl.SelectedValue);
                        cmd.Parameters.AddWithValue("@Quantity", Textqty.Text);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i >= 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert('Inserted Successfully');", true);


                            Textbookname.Text = string.Empty;
                            ddwnl.ClearSelection();
                            Textqty.Text = string.Empty;
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

                        SqlCommand cmd1 = new SqlCommand("sp_books", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@QueryType", "Update");
                        cmd1.Parameters.AddWithValue("@id", hfid.Value);
                        cmd1.Parameters.AddWithValue("@BookName", Textbookname.Text.ToString());
                        cmd1.Parameters.AddWithValue("@AuthorName", ddwnl.SelectedValue);
                        cmd1.Parameters.AddWithValue("@Quantity", Textqty.Text.ToString());
                        con.Open();
                        int i = cmd1.ExecuteNonQuery();
                        con.Close();
                        if (i >= 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert('Updated Successfully')", true);


                            Textbookname.Text = string.Empty;
                            ddwnl.ClearSelection();
                            Textqty.Text = string.Empty;

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
            SqlCommand cmd1 = new SqlCommand("sp_books", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@QueryType", "Delete");
            cmd1.Parameters.AddWithValue("@id", hfid.Value);
            cmd1.Parameters.AddWithValue("@BookName", "");
            cmd1.Parameters.AddWithValue("@AuthorName", "");
            cmd1.Parameters.AddWithValue("@Quantity", "");
            con.Open();
            int i = cmd1.ExecuteNonQuery();
            con.Close();
            if (i >= 0)

            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "deletealert('Deleted Successfully');", true);


                Textbookname.Text = string.Empty;
                ddwnl.ClearSelection();
                Textqty.Text = string.Empty;

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


                hfid.Value = gvRegister.DataKeys[e.NewEditIndex]["id"].ToString();
                Textbookname.Text = gvRegister.DataKeys[e.NewEditIndex]["Book Name"].ToString();
                ddwnl.SelectedValue = gvRegister.DataKeys[e.NewEditIndex]["AuthorId"].ToString();
                Textqty.Text = gvRegister.DataKeys[e.NewEditIndex]["Quantity"].ToString();
                bindRegisterGrid();
                btngo.Text = "Update";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            Textbookname.Text = string.Empty;
            ddwnl.ClearSelection();
            Textqty.Text = string.Empty;
            btngo.Text = "Sumbit";
        }

        protected void gvRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRegister.PageIndex = e.NewPageIndex;
            bindRegisterGrid();
        }
    }
}