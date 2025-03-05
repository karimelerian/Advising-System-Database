using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class LinkStudentToCourse : System.Web.UI.Page
    {
        protected void btnAddCourse1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mainpage_ADMIN.aspx");

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLinkStudent_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(CourseID.Text, out int courseId) ||
                !int.TryParse(InstructorID.Text, out int instructorId) ||
                !int.TryParse(StudentID.Text, out int studentID))
            {
                Response.Write("Invalid input format. Please provide valid integer values for Course ID, Instructor ID, and Student ID.");
                return;
            }

            string semesterCode = SemesterCode.Text;

            LinkStudent(courseId, instructorId, studentID, semesterCode);
        }


        private void LinkStudent(int courseId, int instructorId, int studentID, string semesterCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("Procedures_AdminLinkStudent", connection))
                {
                   

                    if (!CourseExists(courseId) && !InstructorExists(instructorId) && !StudentExists(studentID) && !IsValidSemesterCode(semesterCode))
                    {
                        Response.Write("Error: Course ID, Instructor ID, Student ID, and Semester Code do not exist. The slot has not been linked to a course.");
                        return;
                    }
                    if (!CourseExists(courseId) && !InstructorExists(instructorId) && !IsValidSemesterCode(semesterCode))
                    {
                        Response.Write("Error: Course ID, Instructor ID, and Semester Code do not exist.");
                        return;
                    }
                    if (!CourseExists(courseId) && !StudentExists(studentID) && !IsValidSemesterCode(semesterCode))
                    {
                        Response.Write("Error: Course ID, Student ID, and Semester Code do not exist.");
                        return;
                    }

                    if (!InstructorExists(instructorId) && !StudentExists(studentID) && !IsValidSemesterCode(semesterCode))
                    {
                        Response.Write("Error: Instructor ID, Student ID, and Semester Code do not exist.");
                        return;
                    }
                     if (!CourseExists(courseId) && !InstructorExists(instructorId) && !StudentExists(studentID) )
                    {
                        Response.Write("Error: Course ID, Student ID and Instructor ID do not exist. The slot has not been linked to a course.");
                        return;
                    }
                   
                    if (!IsValidSemesterCode(semesterCode) && !InstructorExists(instructorId))
                    {
                        Response.Write("Error: Semester Code and Instructor ID do not exist.");
                        return;
                    }

                    if (!IsValidSemesterCode(semesterCode) && !StudentExists(studentID))
                    {
                        Response.Write("Error: Semester Code and Student ID do not exist.");
                        return;
                    }

                    if (!IsValidSemesterCode(semesterCode) && !CourseExists(courseId))
                    {
                        Response.Write("Error: Semester Code and Course ID do not exist.");
                        return;
                    }

                    if (!CourseExists(courseId) && !InstructorExists(instructorId))
                    {
                        Response.Write("Error: Course ID and Instructor ID do not exist. The slot has not been linked to a course.");
                        return;
                    }

                    if (!InstructorExists(instructorId) && !StudentExists(studentID))
                    {
                        Response.Write("Error: Instructor ID and Student ID do not exist.");
                        return;
                    }

                    if (!CourseExists(courseId) && !StudentExists(studentID))
                    {
                        Response.Write("Error: Course ID and Student ID do not exist. The slot has not been linked to a course.");
                        return;
                    }


                    if (!CourseExists(courseId))
                    {
                        Response.Write("Error: The provided Course ID does not exist. The slot has not been linked to a course.");
                        return;
                    }

                    if (!InstructorExists(instructorId))
                    {
                        Response.Write("Error: The provided Instructor ID does not exist. The slot has not been linked to a course.");
                        return;
                    }

                    if (!StudentExists(studentID))
                    {
                        Response.Write("Error: The provided Student ID does not exist.");
                        return;
                    }

                    if (!IsValidSemesterCode(semesterCode))
                    {
                        Response.Write("Error: Semester Code does not exist in the Semester table.");
                        return;
                    }
                    if(StudentInstructorCourseTakeExists(courseId, instructorId, semesterCode))
{
                        Response.Write("Error: The combination of Course ID, Instructor ID, and Semester Code already exists.");
                        return;
                    }

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@cours_id", courseId);
                    command.Parameters.AddWithValue("@instructor_id", instructorId);
                    command.Parameters.AddWithValue("@studentID", studentID);
                    command.Parameters.AddWithValue("@semester_code", semesterCode);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Write("Success: Student linked to instructor for the course.");
        }

        private bool CourseExists(int courseId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Course WHERE course_id = @courseId", connection))
                {
                    command.Parameters.AddWithValue("@courseId", courseId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool InstructorExists(int instructorId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Instructor WHERE instructor_id = @instructorId", connection))
                {
                    command.Parameters.AddWithValue("@instructorId", instructorId);
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
        private bool StudentInstructorCourseTakeExists(int courseId, int instructorId, string semesterCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Student_Instructor_Course_take WHERE course_id = @courseId AND instructor_id = @instructorId AND semester_code = @semesterCode", connection))
                {
                    command.Parameters.AddWithValue("@courseId", courseId);
                    command.Parameters.AddWithValue("@instructorId", instructorId);
                    command.Parameters.AddWithValue("@semesterCode", semesterCode);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}