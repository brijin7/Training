using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library1
{
    public partial class BookCollection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["roll"].ToString().Trim() == "1")
                {
                    lblstudent.Visible = false;

                }
                if (Session["roll"].ToString().Trim() == "2")
                {
                    lblstaff.Visible = false;
                }
 
            }
        }
    }
}