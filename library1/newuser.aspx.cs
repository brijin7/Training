using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace library1
{
    public partial class newuser : System.Web.UI.Page
    {
        SQLHelper obj = new SQLHelper();
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["Connect"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ItemBind();

            }

        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", "Insert");
            cmd.Parameters.AddWithValue("@username", txtuser.Text);
            cmd.Parameters.AddWithValue("@password", txtpsw.Text);
            cmd.Parameters.AddWithValue("@roll", rdobtn_roll.SelectedValue);
            cmd.Parameters.AddWithValue("@id", "0");
            cmd.Parameters.AddWithValue("@Department", ddwndep.SelectedValue);
            cmd.Parameters.AddWithValue("@MobileNo", txtno.Text);
            cmd.Parameters.AddWithValue("@RollNumber", txtrollnum.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert('Created succesfully');", true);

                txtuser.Text = string.Empty;
                txtpsw.Text = string.Empty;
                rdobtn_roll.ClearSelection();
                ddwndep.ClearSelection();
                txtno.Text = string.Empty;

                Response.Redirect("Home.aspx");

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert('Oops!Sorry Process Failed ');", true);
                return;
            }
        }
        protected void ItemBind()
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = "SELECT * FROM Department";
                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)

                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ddwndep.DataSource = dtbl;
                        ddwndep.DataTextField = "Department";
                        ddwndep.DataBind();

                    }
                    else
                    {
                        ddwndep.DataBind();
                    }
                    ddwndep.Items.Insert(0, new ListItem("Select", "0"));
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
    }
}