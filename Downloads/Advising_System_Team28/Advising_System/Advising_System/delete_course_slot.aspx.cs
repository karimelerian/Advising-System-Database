using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class delete_course_slot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand deleteRelatedCommand = new SqlCommand("DELETE FROM PreqCourse_course WHERE course_id = @courseID", conn))
                {
                    deleteRelatedCommand.Parameters.AddWithValue("@courseID", courseId.Text);
                    deleteRelatedCommand.ExecuteNonQuery();
                }  
                using (SqlCommand deleteCommand = new SqlCommand("Procedures_AdminDeleteCourse", conn))
                {
                    deleteCommand.CommandType = CommandType.StoredProcedure;
                    string courseidvalue = courseId.Text;
                    if (CourseExists(int.Parse(courseidvalue)))
                    {
                        deleteCommand.Parameters.AddWithValue("@courseID", courseidvalue);
                        deleteCommand.ExecuteNonQuery();

                       
                        Response.Write("Course and related slots deleted successfully!");
                    }
                    else
                    {
                        {
                            Response.Write("Invalid Course ID");
                        }
                    }
                }
            }
        }
    }
}
            



        

    
            
            






 
