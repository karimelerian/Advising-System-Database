using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Advising_system
{
    using System;

    public partial class slotscourseinstructor : System.Web.UI.Page
    {
          protected global::System.Web.UI.WebControls.GridView GridView1;

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
            GridView1.DataSource = dataAccess.GetCoursesSlotsInstructor();
            GridView1.DataBind();
        }
    }

}