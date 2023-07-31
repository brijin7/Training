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
    public partial class Bookreturn : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Bookreturn", con);
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
                sQuery = "SELECT * FROM Login Where roll <>'3'";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ddwnlname.DataSource = dtbl;
                        ddwnlname.DataTextField = "username";
                        ddwnlname.DataValueField = "id";
                        ddwnlname.DataBind();

                    }
                    else
                    {
                        ddwnlname.DataBind();
                    }
                    ddwnlname.Items.Insert(0, new ListItem("Select", "0"));
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
                sQuery = "SELECT * FROM Bookcollections WHERE UserId = '" + ddwnlname.SelectedValue.Trim() + "'";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ddwnlaname.DataSource = dtbl;
                        ddwnlaname.DataTextField = "Bookauthor";
                        ddwnlaname.DataValueField = "AuthorId";
                        ddwnlaname.DataBind();

                    }
                    else
                    {
                        ddwnlaname.DataBind();
                    }
                    ddwnlaname.Items.Insert(0, new ListItem("Select", "0"));
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

        protected void ddwnlname_SelectedIndexChanged(object sender, EventArgs e)
        {

            ItemBind1();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddwnlbname_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemBind3();
        }
        protected void ItemBind2()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "SELECT * FROM Bookcollections WHERE UserId = '" + ddwnlname.SelectedValue.Trim() + "' AND AuthorId  = '" + ddwnlaname.SelectedValue.Trim() + "'";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ddwnlbname.DataSource = dtbl;
                        ddwnlbname.DataTextField = "Bookname";
                        ddwnlbname.DataValueField = "BookId";
                        ddwnlbname.DataBind();

                    }

                    else
                    {
                        ddwnlbname.DataBind();
                    }
                    ddwnlbname.Items.Insert(0, new ListItem("Select", "0"));
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

        protected void ddwnlaname_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemBind2();
        }
        protected void ItemBind3()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                //sQuery = "SELECT Cast (Duedate as Date) as Duedate FROM Bookcollections WHERE  UserId = '" + ddwnlname.SelectedValue.Trim() + "' AND AuthorId  = '" + ddwnlaname.SelectedValue.Trim() + "' AND BookId = '" + ddwnlbname.SelectedValue.Trim() + "'";
                sQuery = "SELECT CONVERT(varchar, Duedate, 103) as Duedate FROM Bookcollections WHERE  UserId = '" + ddwnlname.SelectedValue.Trim() + "' AND AuthorId  = '" + ddwnlaname.SelectedValue.Trim() + "' AND BookId = '" + ddwnlbname.SelectedValue.Trim() + "'";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        Textduedate.Text = dtbl.Rows[0]["Duedate"].ToString();


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

        protected void btngo_Click(object sender, EventArgs e)
        {
            {
                DataTable dt = new DataTable();
                try
                {
                    if (btngo.Text == "Submit")
                    {
                        SqlCommand cmd = new SqlCommand("sp_bookreturn", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@QueryType", "Insert");
                        cmd.Parameters.AddWithValue("@id", "0");
                        cmd.Parameters.AddWithValue("@Name", ddwnlname.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Bookauthor", ddwnlaname.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Bookname", ddwnlbname.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@Returndate", Textdate.Text);
                        cmd.Parameters.AddWithValue("@UserId", ddwnlname.SelectedValue);
                        cmd.Parameters.AddWithValue("@BookId", ddwnlbname.SelectedValue);
                        cmd.Parameters.AddWithValue("@AuthorId", ddwnlaname.SelectedValue);
                        cmd.Parameters.AddWithValue("@Duedate", Textduedate.Text);
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i >= 0)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "returnalert('Inserted Successfully');", true);

                            ItemUpdate1();
                            ItemUpdate();
                            ddwnlname.ClearSelection();
                            Textduedate.Text = string.Empty;
                            ddwnlaname.ClearSelection();
                            ddwnlbname.ClearSelection();
                          


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

        protected void ItemUpdate()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "Update Bookcollections set Activestatus = 'D' WHERE UserId = '" + ddwnlname.SelectedValue.Trim() + "' And AuthorId = '" + ddwnlaname.SelectedValue.Trim() + "' AND BookId = '" + ddwnlbname.SelectedValue.Trim() + "''";
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

        protected void ItemUpdate1()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "UPDATE Books SET Quantity = Quantity + 1 WHERE[Book Name] ='" + ddwnlbname.SelectedItem.Text.Trim() + "'";
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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Textduedate.Text = string.Empty;
            ddwnlname.ClearSelection();
            ddwnlaname.ClearSelection();
            ddwnlbname.ClearSelection();
            Textdate.Text = string.Empty;
            btngo.Text = "Sumbit";
        }
    }
}

