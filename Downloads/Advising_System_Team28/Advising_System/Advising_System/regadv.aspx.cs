using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class regadv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegOnClick(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            SqlConnection conn = new SqlConnection(connstr);

            string name = AdvName.Text;
            string pass = AdvPass.Text;
            string off = AdvOff.Text;
            string email = AdvEmail.Text;
            int id = int.Parse(AdvID.Text);
            SqlCommand registerproc = new SqlCommand("Procedures_AdvisorRegistration", conn);
            registerproc.CommandType = CommandType.StoredProcedure;
            registerproc.Parameters.Add(new SqlParameter("@advisor_name", name));
            registerproc.Parameters.Add(new SqlParameter("@password", pass));
            registerproc.Parameters.Add(new SqlParameter("@email", email));
            registerproc.Parameters.Add(new SqlParameter("@office", off));
            registerproc.Parameters.Add(new SqlParameter("@Advisor_id", id));

           
            SqlParameter advid = registerproc.Parameters.Add("@Advisor_id", SqlDbType.Int);
            advid.Direction = ParameterDirection.Output;

            conn.Open();
            registerproc.ExecuteNonQuery();
            conn.Close();

            if (advid.Value != null)
            {
                Response.Write("Registration successful ");
                Response.Write("Your ID is " + advid.Value);

                Response.Redirect("loginadv.aspx?AdvisorID=" + advid.Value);

            }
        }
    }

}

      