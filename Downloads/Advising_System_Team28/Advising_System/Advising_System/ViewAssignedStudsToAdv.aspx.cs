using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class ViewAssignedStudsToAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewStudents_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdvisorId.Text) || string.IsNullOrEmpty(txtMajor.Text))
            {
                Response.Write("Please fill in all required fields.");
                return;
            }

            int advisorId;
            if (!int.TryParse(txtAdvisorId.Text, out advisorId))
            {
                Response.Write("Invalid Advisor ID.");
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand viewStudentsCmd = new SqlCommand("Procedures_AdvisorViewAssignedStudents", conn))
                {
                    viewStudentsCmd.CommandType = System.Data.CommandType.StoredProcedure;

                    viewStudentsCmd.Parameters.AddWithValue("@AdvisorID", advisorId);
                    viewStudentsCmd.Parameters.AddWithValue("@major", txtMajor.Text);

                    SqlDataReader reader = viewStudentsCmd.ExecuteReader();
                    GridViewAssignedStudents.DataSource = reader;
                    GridViewAssignedStudents.DataBind();
                }
            }
        }
    }
}