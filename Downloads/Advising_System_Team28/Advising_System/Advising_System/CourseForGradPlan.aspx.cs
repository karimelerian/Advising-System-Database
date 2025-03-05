using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Xml.Linq;

namespace Advising_System
{
    public partial class CourseForGradPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            if (string.IsNullOrEmpty(txtStudentId.Text) || string.IsNullOrEmpty(txtSemesterCode.Text) || string.IsNullOrEmpty(txtCourseName.Text))
            {
                Response.Write("Please fill in all required fields.");
                return;
            }
            if (!int.TryParse(txtStudentId.Text, out int studentId))
            {
                Response.Write("Invalid student ID format.");
                return;
            }
            if (CourseExistsForStudentAndSemester(txtCourseName.Text, Convert.ToInt32(txtStudentId.Text), txtSemesterCode.Text))
            {
                Response.Write("Course with the given name already exists for the specified student and semester.");
                return;
            }
            if (!IsValidSemesterCode(txtSemesterCode.Text) && !StudentExists(Convert.ToInt32(txtStudentId.Text)) && (!CourseExistsName(txtCourseName.Text)))
            {
                Response.Write("Invalid semester code and student and course name .");
                return;
            }
            if (!IsValidSemesterCode(txtSemesterCode.Text) && !StudentExists(Convert.ToInt32(txtStudentId.Text)))
            {
                Response.Write("Invalid semester code and student.");
                return;
            }

            if (!IsValidSemesterCode(txtSemesterCode.Text) && !CourseExistsName(txtCourseName.Text))
            {
                Response.Write("Invalid semester code and course name .");
                return;
            }
            if (!StudentExists(Convert.ToInt32(txtStudentId.Text)) && !CourseExistsName(txtCourseName.Text))
            {
                Response.Write("Invalid student id and course name .");
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
            if (!CourseExistsName(txtCourseName.Text))
            {
                Response.Write("Invalid course name .");
                return;
            }



            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand InsertCourseForGP = new SqlCommand("Procedures_AdvisorAddCourseGP", conn))
                {
                    InsertCourseForGP.CommandType = System.Data.CommandType.StoredProcedure;

                    InsertCourseForGP.Parameters.AddWithValue("@student_id", Convert.ToInt32(txtStudentId.Text));
                    InsertCourseForGP.Parameters.AddWithValue("@Semester_code", txtSemesterCode.Text);
                    InsertCourseForGP.Parameters.AddWithValue("@course_name", txtCourseName.Text);

                    int rowsAffected = InsertCourseForGP.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("Course added to Graduation Plan successfully.");
                    }
                    else
                    {
                        Response.Write("Failed to add the course to Graduation Plan.");
                    }
                }
            }
        }

        private bool CourseExistsForStudentAndSemester(string courseName, int studentId, string semesterCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int courseId;


                using (SqlCommand getCourseIdCommand = new SqlCommand("SELECT course_id FROM dbo.Course WHERE name = @course_name", connection))
                {
                    getCourseIdCommand.Parameters.AddWithValue("@course_name", courseName);
                    var result = getCourseIdCommand.ExecuteScalar();


                    if (result != null && result != DBNull.Value)
                    {
                        courseId = (int)result;
                    }
                    else
                    {

                        return false;
                    }
                }


                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.GradPlan_Course GC " +
                                                           "INNER JOIN dbo.Graduation_Plan GP ON GC.plan_id = GP.plan_id " +
                                                           "WHERE GC.course_id = @course_id " +
                                                           "AND GP.student_id = @student_id AND GP.semester_code = @semester_code", connection))
                {
                    command.Parameters.AddWithValue("@course_id", courseId);
                    command.Parameters.AddWithValue("@student_id", studentId);
                    command.Parameters.AddWithValue("@semester_code", semesterCode);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }





        private int GetPlanId(int studentId, string semesterCode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT plan_id FROM Graduation_Plan WHERE student_id = @studentId AND semester_code = @semesterCode", conn))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@semesterCode", semesterCode);

                    object result = command.ExecuteScalar();

                    return result != null ? (int)result : -1;
                }
            }
        }
        private bool CourseExistsName(string courseName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Course WHERE name = @course_name", connection))
                {
                    command.Parameters.AddWithValue("@course_name", courseName);
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
        private bool IsValidSemesterCode(string semesterCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Semester WHERE semester_code = @semesterCode", connection))
                {
                    command.Parameters.AddWithValue("@semesterCode", semesterCode);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}