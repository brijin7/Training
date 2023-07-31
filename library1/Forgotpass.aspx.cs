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
    public partial class Forgotpass : System.Web.UI.Page
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
                sQuery = " UPDATE Login SET password= '" + txtpass.Text + "' WHERE MobileNo = '" + txtmno.Text + "'";

                obj.CreateConnection("Connect");
                if (obj.FillDataTableByQueryString(ref dtbl, ref sError, sQuery) == true)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert('Forgot succesfully');", true);
                    txtpass.Text = string.Empty;
                    txtmno.Text = string.Empty;
                    
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