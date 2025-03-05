using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Advising_System
{
    public partial class LinkInstructorToCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string courseIdString = Request.Form["courseId"];
            string instructorIdString = Request.Form["instructorId"];
            string slotIdString = Request.Form["slotId"];
            int courseId, instructorId, slotId;

            if (!string.IsNullOrEmpty(courseIdString) ||
                !string.IsNullOrEmpty(instructorIdString) ||
                !string.IsNullOrEmpty(slotIdString))
            {
                if (!int.TryParse(courseIdString, out courseId) ||
                !int.TryParse(instructorIdString, out instructorId) ||
                !int.TryParse(slotIdString, out slotId))
                {
                    Response.Write("Invalid input format. Please provide valid integer values for Course ID, Instructor ID, and Slot ID.");
                    return;
                }
                UpdateSlot(courseId, instructorId, slotId);
            }

           
            

        }

        protected void btnAddCourse1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mainpage_ADMIN.aspx");

        }
        private bool IsValidInteger(string input)
        {
            return int.TryParse(input, out _);
        }


        private void UpdateSlot(int courseId, int instructorId, int slotId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
              
                if (!CourseExists(courseId) && !InstructorExists(instructorId) && !SlotExists(slotId))
                {
                    Response.Write("Error: ALL the provided Course ID, Instructor ID, and Specified slot do not exist. The slot has not been linked to a course.");
                }
                else if (!CourseExists(courseId) && !SlotExists(slotId))
                {
                    Response.Write("Error: The provided Course ID does not exist, and the specified slot does not exist. The slot has not been linked to a course.");
                }
                else if (!InstructorExists(instructorId) && !SlotExists(slotId))
                {
                    Response.Write("Error: The provided Instructor ID does not exist, and the specified slot does not exist. The slot has not been linked to a course.");
                }
                else if (!SlotExists(slotId))
                {
                    Response.Write("Error: The specified slot does not exist. The slot has not been linked to a course.");
                }
                else if (!CourseExists(courseId) && InstructorExists(instructorId))
                {
                    Response.Write("Error: The provided Course ID does not exist. The slot has not been linked to a course.");
                }
                else if (CourseExists(courseId) && !InstructorExists(instructorId))
                {
                    Response.Write("Error: The provided Instructor ID does not exist. The slot has not been linked to a course.");
                }
                else
                {
                    using (SqlCommand command = new SqlCommand("Procedures_AdminLinkInstructor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@cours_id", courseId);
                        command.Parameters.AddWithValue("@instructor_id", instructorId);
                        command.Parameters.AddWithValue("@slot_id", slotId);

                        command.ExecuteNonQuery();
                    }

                    Response.Write("Success: The slot has been successfully linked to a course.");
                }

                connection.Close();
            }
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
        private bool SlotExists(int slotId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.Slot WHERE slot_id = @slotId", connection))
                {
                    command.Parameters.AddWithValue("@slotId", slotId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}
