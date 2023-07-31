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
    public partial class Staffstudentdetails : System.Web.UI.Page
    {
        SQLHelper obj = new SQLHelper();
        SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["Connect"]);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void bindRegisterGrid()
        {

            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Login Where roll='" + ddwnl.SelectedValue.Trim() + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvRegister.DataSource = dt;
                gvRegister.DataBind();
            }
            con.Close();
        }

        protected void gvRegister_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRegister.EditIndex = e.NewEditIndex;
            bindRegisterGrid();
        }

        protected void gvRegister_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gvRegister.Rows[e.RowIndex].FindControl("lblid") as Label;
            TextBox username = gvRegister.Rows[e.RowIndex].FindControl("txtuser") as TextBox;
            TextBox password = gvRegister.Rows[e.RowIndex].FindControl("txtpw") as TextBox;
            TextBox roll = gvRegister.Rows[e.RowIndex].FindControl("txtroll") as TextBox;
            TextBox Department = gvRegister.Rows[e.RowIndex].FindControl("txtdep") as TextBox;
            TextBox MobileNo = gvRegister.Rows[e.RowIndex].FindControl("txtmno") as TextBox;
            TextBox RollNumber = gvRegister.Rows[e.RowIndex].FindControl("txtrollno") as TextBox;

            con.Open();
            SqlCommand cmd = new SqlCommand("Update Login set username='" + username.Text + "',password='" + password.Text + "',roll='" + roll.Text + "',Department='" + Department.Text + "',MobileNo='" + MobileNo.Text + "',RollNumber='" + RollNumber.Text + "'WHERE id=" + Convert.ToInt32(id.Text), con);
            cmd.ExecuteNonQuery();
            con.Close();
            gvRegister.EditIndex = -1;
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "updatealert('Updated Successfully')", true);
            bindRegisterGrid();
        }

        protected void gvRegister_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvRegister.EditIndex = -1;
            bindRegisterGrid();
        }

        protected void btngo_Click(object sender, EventArgs e)
        {
            bindRegisterGrid();
        }

        protected void gvRegister_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRegister.PageIndex = e.NewPageIndex;
            bindRegisterGrid();
        }
    }
}