using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Advising_System : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUserID = UserID.Text;
            string enteredPassword = Password.Text;

            if (enteredUserID == "admin" && enteredPassword == "pass1010")
            {
                Response.Redirect("Mainpage_ADMIN.aspx");
                ClientScript.RegisterStartupScript(this.GetType(), "CloseLogin", "closeLogin();", true);
            }
        }
    }
}