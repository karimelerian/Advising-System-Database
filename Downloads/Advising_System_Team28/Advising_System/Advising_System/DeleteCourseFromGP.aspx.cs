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
    public partial class DeleteCourseFromGP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentId.Text) || string.IsNullOrEmpty(txtSemesterCode.Text) || string.IsNullOrEmpty(txtCourseId.Text))
            {
                Response.Write("Please fill in all required fields.");
                return;
            }

            if (!StudentExists(Convert.ToInt32(txtStudentId.Text)))
            {
                Response.Write("Student does not exist.");
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand deleteCourseCmd = new SqlCommand("Procedures_AdvisorDeleteFromGP", conn))
                {
                    deleteCourseCmd.CommandType = System.Data.CommandType.StoredProcedure;

                    deleteCourseCmd.Parameters.AddWithValue("@studentID", Convert.ToInt32(txtStudentId.Text));
                    deleteCourseCmd.Parameters.AddWithValue("@sem_code", txtSemesterCode.Text);
                    deleteCourseCmd.Parameters.AddWithValue("@courseID", Convert.ToInt32(txtCourseId.Text));

                    deleteCourseCmd.ExecuteNonQuery();
                }
            }

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