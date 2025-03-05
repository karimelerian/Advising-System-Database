using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class LinkStudentToAdvisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAddCourse1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mainpage_ADMIN.aspx");

        }

        private bool IsStudentLinkedToAdvisor(int studentId, int instructorId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Student_Instructor_Course_take WHERE student_id = @studentId AND instructor_id = @instructorId ", connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@instructorId", instructorId);
        

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        protected void LinkStudentButton_Click(object sender, EventArgs e)
        {
           
            TextBox instructorIdTextBox = instructorId;
            TextBox studentIdTextBox = studentId;
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            if ( instructorIdTextBox != null && studentIdTextBox != null )
            {
                if (
                    string.IsNullOrWhiteSpace(instructorIdTextBox.Text) ||
                    string.IsNullOrWhiteSpace(studentIdTextBox.Text) )
                {
                    Response.Write("Error: Please fill in all the fields.");
                    return;
                }

                int coursId, instructorId, studentId;

                if ( !int.TryParse(instructorIdTextBox.Text, out instructorId) ||
                    !int.TryParse(studentIdTextBox.Text, out studentId))
                {
                    Response.Write("Error: Invalid input. Please enter valid numeric values for Instructor ID, and Student ID.");
                    return;
                }

                if (!InstructorExists(instructorId) && (!StudentExists(studentId)))
                    {
                    Response.Write("Error: The provided Instructor ID and  Student ID  does not exist.");
                    return;
                }
                    if (!InstructorExists(instructorId))
                {
                    Response.Write("Error: The provided Instructor ID does not exist.");
                    return;
                }

                if (!StudentExists(studentId))
                {
                    Response.Write("Error: The provided Student ID does not exist.");
                    return;
                }

                if (IsStudentLinkedToAdvisor(studentId, instructorId))
                {
                    Response.Write("Error: Student is already linked to the advisor .");
                }
                else
                {
                    LinkStudentToAdvisorProcedure(instructorId, studentId);
                    Response.Write("Success: Student linked to advisor.");
                }
            }
            else
            {
                Response.Write("Error: Input fields cannot be null.");
            }
        }
        private void LinkStudentToAdvisorProcedure( int instructorId, int studentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (IsStudentLinkedToAnyAdvisor(studentId))
                {
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE dbo.Student_Instructor_Course_take SET instructor_id = @instructorId WHERE student_id = @studentId ", connection))
                    {
                        updateCommand.Parameters.AddWithValue("@instructorId", instructorId);
                        updateCommand.Parameters.AddWithValue("@studentId", studentId);
                       

                        updateCommand.ExecuteNonQuery();
                       
                    }
                }
                else
                {
                    using (SqlCommand insertCommand = new SqlCommand("Procedures_AdminLinkStudent", connection))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;

                        
                        insertCommand.Parameters.AddWithValue("@instructor_id", instructorId);
                        insertCommand.Parameters.AddWithValue("@studentID", studentId);
                 

                        insertCommand.ExecuteNonQuery();
                      
                    }
                }
            }
        }

        private bool IsStudentLinkedToAnyAdvisor(int studentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Student_Instructor_Course_take WHERE student_id = @studentId ", connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);

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
