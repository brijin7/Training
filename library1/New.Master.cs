using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library1
{
    public partial class New : System.Web.UI.MasterPage
    { 
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            { 

                if (Session["roll"].ToString().Trim() == "3")
                { 
                    lblbc.Visible = false;
                    lblbr.Visible = false;
                    lbltrans.Visible = false;
                    

                }
                if (Session["roll"].ToString().Trim() == "1")
                {
                    lblmaster.Visible = false;
                    lblbooka.Visible = false;
                    lblbook.Visible = false;
                    lblot.Visible = false;
                    lblout.Visible = false;
                    lblc.Visible = false;
                    lblnew.Visible = false;
                    lbldet.Visible = false;
                    lblreport.Visible = false;

                }
                if (Session["roll"].ToString().Trim() == "2")
                {
                    lblmaster.Visible = false;
                    lblbooka.Visible = false;
                    lblbook.Visible = false;
                    lblot.Visible = false;
                    lblout.Visible = false;
                    lblc.Visible = false;
                    lblnew.Visible = false;
                    lbldet.Visible = false;
                    lblreport.Visible = false;
                }



            }
        }
    }
}
