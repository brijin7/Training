using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace library1
{
    public partial class Student : System.Web.UI.Page
    {
        SQLHelper obj = new SQLHelper();
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["Connect"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bindRegisterGrid();
                ItemBind();
                ItemBind2();


            }

        }
        protected void bindRegisterGrid()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Bookcollections AS BC Inner join Login As L On BC.UserId= L.id where roll='2' ", con);
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

        protected void ItemBind()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "SELECT * FROM [Book Author] ";
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
                    //  ddwnl.Items.Insert(0, new ListItem("Select", "0"));

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
        protected void ItemBind1()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "SELECT id as 'BookId',[Book Name] FROM Books Where [Author Name]='" + ddwnl.SelectedValue.Trim() + "'";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ddwnl1.DataSource = dtbl;
                        ddwnl1.DataTextField = "Book Name";
                        ddwnl1.DataValueField = "BookId";
                        ddwnl1.DataBind();

                    }
                    else
                    {
                        ddwnl1.DataBind();
                    }
                    ddwnl1.Items.Insert(0, new ListItem("Select", "0"));
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
                        SqlCommand cmd = new SqlCommand("sp_bookcollectons", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QueryType", "Insert");
                        cmd.Parameters.AddWithValue("@id", "0");
                        cmd.Parameters.AddWithValue("@Name", ddwnl2.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Bookauthor", ddwnl.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Bookname", ddwnl1.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Fromdate", Textdate.Text);
                        cmd.Parameters.AddWithValue("@UserId", ddwnl2.SelectedValue);
                        cmd.Parameters.AddWithValue("@BookId", ddwnl1.SelectedValue);
                        cmd.Parameters.AddWithValue("@AuthorId", ddwnl.SelectedValue);
                        cmd.Parameters.AddWithValue("@Duedate", Textd2.Text);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i >= 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert('Inserted Successfully');", true);
                            ItemUpdate();
                            ddwnl2.ClearSelection();
                            Textdate.Text = string.Empty;
                            Textd2.Text = string.Empty;
                            ddwnl.ClearSelection();
                            ddwnl1.ClearSelection();
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

                        SqlCommand cmd1 = new SqlCommand("sp_bookcollectons", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@QueryType", "Update");
                        cmd1.Parameters.AddWithValue("@id", hfid.Value);
                        cmd1.Parameters.AddWithValue("@Name", ddwnl2.SelectedItem.Text);
                        cmd1.Parameters.AddWithValue("@Bookauthor", ddwnl.SelectedItem.Text);
                        cmd1.Parameters.AddWithValue("@Bookname", ddwnl1.SelectedItem.Text);
                        cmd1.Parameters.AddWithValue("@Fromdate", Textdate.Text);
                        cmd1.Parameters.AddWithValue("@UserId", ddwnl2.SelectedValue);
                        cmd1.Parameters.AddWithValue("@BookId", ddwnl1.SelectedValue);
                        cmd1.Parameters.AddWithValue("@AuthorId", ddwnl.SelectedValue);
                        cmd1.Parameters.AddWithValue("@Duedate", Textd2.Text);
                        con.Open();
                        int i = cmd1.ExecuteNonQuery();
                        con.Close();
                        if (i >= 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert('Updated Successfully')", true);


                            ddwnl2.ClearSelection();
                            Textdate.Text = string.Empty;
                            Textd2.Text = string.Empty;
                            ddwnl.ClearSelection();
                            ddwnl1.ClearSelection();
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
            SqlCommand cmd1 = new SqlCommand("sp_bookcollectons", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@QueryType", "Delete");
            cmd1.Parameters.AddWithValue("@id", hfid.Value);
            cmd1.Parameters.AddWithValue("@Name", "");
            cmd1.Parameters.AddWithValue("@Bookauthor", "");
            cmd1.Parameters.AddWithValue("@Bookname", "");
            cmd1.Parameters.AddWithValue("@Fromdate", "");
            cmd1.Parameters.AddWithValue("@UserId", hfid.Value);
            cmd1.Parameters.AddWithValue("@BookId", "");
            cmd1.Parameters.AddWithValue("@AuthorId", "");
            cmd1.Parameters.AddWithValue("@Duedate", "");
            con.Open();
            int i = cmd1.ExecuteNonQuery();
            con.Close();
            if (i >= 0)

            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "deletealert('Deleted Successfully');", true);
                ddwnl2.ClearSelection();
                Textdate.Text = string.Empty;
                Textd2.Text = string.Empty;
                ddwnl.ClearSelection();
                ddwnl1.ClearSelection();
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
                ddwnl2.SelectedValue = gvRegister.DataKeys[e.NewEditIndex]["UserId"].ToString();
                ddwnl.SelectedValue = gvRegister.DataKeys[e.NewEditIndex]["AuthorId"].ToString();
                ItemBind1();
                ddwnl1.SelectedValue = gvRegister.DataKeys[e.NewEditIndex]["BookId"].ToString();
                Textdate.Text = gvRegister.DataKeys[e.NewEditIndex]["Fromdate"].ToString();
                Textd2.Text = gvRegister.DataKeys[e.NewEditIndex]["Duedate"].ToString();
                bindRegisterGrid();
                btngo.Text = "Update";
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddwnl2.ClearSelection();
            Textdate.Text = string.Empty;
            Textd2.Text = string.Empty;
            ddwnl.ClearSelection();
            ddwnl1.ClearSelection();
            btngo.Text = "Sumbit";
        }
        protected void ItemBind2()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "SELECT id as 'UserId',username FROM Login Where roll='2'";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ddwnl2.DataSource = dtbl;
                        ddwnl2.DataTextField = "username";
                        ddwnl2.DataValueField = "UserId";
                        ddwnl2.DataBind();

                    }
                    else
                    {
                        ddwnl2.DataBind();
                    }
                    ddwnl2.Items.Insert(0, new ListItem("Select", "0"));
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

        protected void ddwnl_SelectedIndexChanged(object sender, EventArgs e)
        {

            ItemBind1();
        }

        protected void ddwnl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemCount();
            ItemReturn();
            string CollectedCount = ViewState["CollectedCount"].ToString().Trim();
            string QuantityCount = ViewState["Quantity"].ToString().Trim();
            if (Convert.ToInt32(CollectedCount) > Convert.ToInt32(QuantityCount))
            {
                ddwnl2.ClearSelection();
                Textdate.Text = string.Empty;
                Textd2.Text = string.Empty;
                ddwnl.ClearSelection();
                ddwnl1.ClearSelection();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "Noalert('Sorry,The Book IS Not Available');", true);
                return;
            }
        }
        protected void ItemCount()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "SELECT COUNT(*)AS 'CollectedCount' From Bookcollections WHERE AuthorId = '" + ddwnl.SelectedValue.Trim() + "' AND BookId = '" + ddwnl1.SelectedValue.Trim() + "' and Activestatus = 'A'";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ViewState["CollectedCount"] = dtbl.Rows[0]["CollectedCount"].ToString();
                    }
                    else
                    {
                        ViewState["CollectedCount"] = "0";
                    }

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
        protected void ItemReturn()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "SELECT Quantity FROM Books WHERE [Author Name] = '" + ddwnl.SelectedValue.Trim() + "' AND id = '" + ddwnl1.SelectedValue.Trim() + "' ";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ViewState["Quantity"] = dtbl.Rows[0]["Quantity"].ToString();
                    }
                    else
                    {
                        ViewState["Quantity"] = "0";
                    }

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
        protected void ItemUpdate()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "UPDATE Books SET Quantity = Quantity - 1 WHERE[Book Name] ='" + ddwnl1.SelectedItem.Text.Trim() + "'";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {

                    }
                    else
                    {

                    }
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


        protected void gvRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRegister.PageIndex = e.NewPageIndex;
            bindRegisterGrid();
        }
    }
}
