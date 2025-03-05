using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class MAINCHOOSE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void admin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Adminlogin.aspx");
        }

        protected void student_Click(object sender, EventArgs e)
        {
            Response.Redirect("MAINPAGE_S.aspx");
        }

        protected void advisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvMainPage.aspx");
        }

    }
}