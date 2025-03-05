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
    public partial class GradPlanForStuds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSemesterCode.Text) || string.IsNullOrEmpty(txtCreditHours.Text) ||
                string.IsNullOrEmpty(txtExpectedGradDate.Text) || string.IsNullOrEmpty(txtAdvisorId.Text) ||
                string.IsNullOrEmpty(txtStudentId.Text))
            {
                Response.Write("Please fill in all required fields.");
                return;
            }
            if (!IsValidSemesterCode(txtSemesterCode.Text) && !StudentExists(Convert.ToInt32(txtStudentId.Text)) && !AdvisorExists(Convert.ToInt32(txtAdvisorId.Text)))
            {
                Response.Write("Invalid semester code and Student and advisor .");
                return;
            }
            if (!IsValidSemesterCode(txtSemesterCode.Text) && !StudentExists(Convert.ToInt32(txtStudentId.Text)))
            {
                Response.Write("Invalid semester code and Student.");
                return;
            }

            if (!IsValidSemesterCode(txtSemesterCode.Text) && !AdvisorExists(Convert.ToInt32(txtAdvisorId.Text)))
            {
                Response.Write("Invalid semester code and advisor.");
                return;

            }
            if (!AdvisorExists(Convert.ToInt32(txtAdvisorId.Text)) && !StudentExists(Convert.ToInt32(txtStudentId.Text)))
            {
                Response.Write("advisor  and Student do not exist .");
                return;
            }
            if (!IsValidSemesterCode(txtSemesterCode.Text))
            {
                Response.Write("Invalid semester code.");
                return;
            }


            if (!StudentExists(Convert.ToInt32(txtStudentId.Text)))
            {
                Response.Write("Student does not exist.");
                return;
            }


            if (!AdvisorExists(Convert.ToInt32(txtAdvisorId.Text)))
            {
                Response.Write("Advisor does not exist.");
                return;
            }

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand InsretGradPlan = new SqlCommand("Procedures_AdvisorCreateGP", conn))
                {
                    InsretGradPlan.CommandType = System.Data.CommandType.StoredProcedure;

                    InsretGradPlan.Parameters.AddWithValue("@Semester_code", txtSemesterCode.Text);
                    InsretGradPlan.Parameters.AddWithValue("@sem_credit_hours", Convert.ToInt32(txtCreditHours.Text));
                    InsretGradPlan.Parameters.AddWithValue("@expected_graduation_date", Convert.ToDateTime(txtExpectedGradDate.Text));
                    InsretGradPlan.Parameters.AddWithValue("@advisor_id", Convert.ToInt32(txtAdvisorId.Text));
                    InsretGradPlan.Parameters.AddWithValue("@student_id", Convert.ToInt32(txtStudentId.Text));


                    InsretGradPlan.ExecuteNonQuery();

                    Response.Write("The graduation plan has been successfully created");
                }
            }
        }

        private bool IsValidSemesterCode(string semesterCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Semester WHERE semester_code = @Semester_code", connection))
                {
                    command.Parameters.AddWithValue("@Semester_code", semesterCode);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
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

        private bool AdvisorExists(int advisorId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Advisor WHERE advisor_id = @advisorId", connection))
                {
                    command.Parameters.AddWithValue("@advisorId", advisorId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }


    }


}