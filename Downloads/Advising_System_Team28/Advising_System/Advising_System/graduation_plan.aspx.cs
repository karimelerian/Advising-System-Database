using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Advising_system
{
    public partial class graduation_plan : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Advising_system"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {

                int studID = Convert.ToInt32(studentID);


                if (StudentExists(studID))
                {
                    DataTable studentData = GetStudentData(studID);
                    GridView1.DataSource = studentData;
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("Invalid Student ID. Please enter a valid ID.");
                }
            }
        }


        private DataTable GetStudentData(int studentId)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"SELECT * FROM [FN_StudentViewGP](@student_ID)", connection))
                {
                    command.Parameters.AddWithValue("@student_ID", studentId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(result);
                    }
                }
            }

            return result;
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {

                int studID = Convert.ToInt32(studentID);


                DataTable studentData = GetStudentData(studID);

                GridView1.DataSource = studentData;
                GridView1.DataBind();
            }
        }
            private bool StudentExists(int studentId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Student WHERE student_id = @student_ID", connection))
                    {
                        command.Parameters.AddWithValue("@student_ID", studentId);
                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }

        }
    }

