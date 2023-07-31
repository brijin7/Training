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
    public partial class Collections : System.Web.UI.Page
    {
        SQLHelper obj = new SQLHelper();
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["Connect"]);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            {
                DataTable dt = new DataTable();
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Bookcollections WHERE Fromdate='" + Textdate.Text.Trim() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    gvRegister.DataSource = dt;
                
                    if (dt.Rows.Count > 1)
                    {
                        gvRegister.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "otheralert('No Record Found');", true);
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
}