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
    public partial class forgot : System.Web.UI.Page
    {
        SQLHelper obj = new SQLHelper();
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["Connect"]);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_forgot_Click(object sender, EventArgs e)
        {
            try
            {
                string sQuery = string.Empty;
                string sError = string.Empty;
                DataTable dtbl = new DataTable();
                sQuery = " SELECT * FROM Login WHERE MobileNo = '" + txtmno.Text + "'";

                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)
                {
                    if (dtbl.Rows.Count > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Congrats!','Login success!', 'PROCEED');", true);
                        Response.Redirect("Forgotpass.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Oops!','Something went wrong on the page!','');", true); return;
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