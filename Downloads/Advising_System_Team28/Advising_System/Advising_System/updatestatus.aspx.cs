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
    public partial class updatestatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string studentid = TextBox1.Text;
                if (StudentExists(int.Parse(studentid)))
                {
                    using (SqlCommand update = new SqlCommand("Procedure_AdminUpdateStudentStatus", conn))
                    {
                        update.CommandType = CommandType.StoredProcedure;
                        update.Parameters.AddWithValue("@student_id", studentid);
                        update.ExecuteNonQuery();
                        Response.Write("status is updated successfully");
                    }
                }
                else
                    Response.Write("please enter a valid semester");
              

            }
            
        }
    }
}