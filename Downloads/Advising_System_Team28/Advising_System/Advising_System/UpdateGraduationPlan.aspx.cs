using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class UpdateGraduationPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdateGradPlan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtExpectedGradDate.Text) || string.IsNullOrEmpty(txtStudentId.Text))
            {
                Response.Write("Please fill in all required fields.");
                return;
            }

            if (!StudentExists(Convert.ToInt32(txtStudentId.Text)))
            {
                Response.Write("Student does not exist.");
                return;
            }

            if (IsInvalidDate(Convert.ToDateTime(txtExpectedGradDate.Text)))
            {
                Response.Write("Invalid date. Expected graduation date must be greater than today's date.");
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand updateGradPlanCmd = new SqlCommand("Procedures_AdvisorUpdateGP", conn))
                {
                    updateGradPlanCmd.CommandType = System.Data.CommandType.StoredProcedure;

                    updateGradPlanCmd.Parameters.AddWithValue("@expected_grad_date", Convert.ToDateTime(txtExpectedGradDate.Text));
                    updateGradPlanCmd.Parameters.AddWithValue("@studentID", Convert.ToInt32(txtStudentId.Text));

                    updateGradPlanCmd.ExecuteNonQuery();
                }
            }

        }

        private bool IsInvalidDate(DateTime expectedGradDate)
        {
           
            return expectedGradDate <= DateTime.Today;
        }

        private bool StudentExists(int studentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Student WHERE student_id = @studentId", connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
