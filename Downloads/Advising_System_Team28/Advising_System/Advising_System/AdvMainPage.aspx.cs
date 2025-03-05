using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class AdvMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Write("Your ID is " + AdvisorID);
            }
        }

        protected void LoginPgButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginadv.aspx");
           
        }

        protected void RegPgButton_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("regadv.aspx");
        }
    }
}