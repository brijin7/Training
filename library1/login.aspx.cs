using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace library1
{
    public partial class Login : System.Web.UI.Page
    {
        SQLHelper obj = new SQLHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = " SELECT username,password,roll"
                      + " FROM Login WHERE username= '" + txtusername.Text + "' and password='" + txtpass.Text + "'";

                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)
                {
                    if (dtbl.Rows.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Success!','login succesfully,'');", true);
                        Session["roll"] = dtbl.Rows[0]["roll"].ToString();             
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Oops!','Wrong User Name Password!','');", true); return;
                    }
                }

            }
            catch (Exception ex)
            {
                string sVa = ex.ToString();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "erroralert('" + sVa + "');", true);
            }
        }
    }
}