using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Advising_system
{
    public partial class installments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool StudentExists(int studentId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_system"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) { 
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Student WHERE student_id = @student_ID", connection))
                {
                    command.Parameters.AddWithValue("@student_ID", studentId);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_system"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string studentID = Request.QueryString["StudentID"];
                if (!string.IsNullOrEmpty(studentID))
                {

                    int studID = Convert.ToInt32(studentID);

                    using (SqlCommand command = new SqlCommand("SELECT dbo.FN_StudentUpcoming_installment(@student_ID) AS InstallmentDeadline", connection))
                    {
                        command.Parameters.AddWithValue("@student_ID", studentID);
                        connection.Open();

                        object result = command.ExecuteScalar();

                       
                        if (result != null && result != DBNull.Value)
                        {
                            DateTime installmentDeadline = (DateTime)result;
                            Response.Write("Next Installment Deadline: " + installmentDeadline.ToString());
                        }
                        else
                        {
                            Response.Write("No upcoming installment found for the given student ID.");
                        }
                    }
                }
                else
                {
                    Response.Write("Invalid student ID. Please enter a valid numeric ID.");
                }
            }
        }



    }
}
