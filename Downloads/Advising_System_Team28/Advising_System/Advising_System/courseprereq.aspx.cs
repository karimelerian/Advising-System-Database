using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_system
{
    public partial class courseprereq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            DataAccess dataAccess = new DataAccess();
            GridView1.DataSource = dataAccess.GetCoursePrerequisites();
            GridView1.DataBind();
        }
    }
}
