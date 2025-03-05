using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class MAINPAGE_S : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnreg_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentreg.aspx");
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("studentlogin.aspx");
        }
    }
}