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
    public partial class admin_deleteslots : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
             
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

        protected void admindelete(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

               
                string current_semester = TextBox1.Text;

               
                if (IsValidSemesterCode(current_semester))
                {
                    
                    using (SqlCommand admindeleteslot = new SqlCommand("Procedures_AdminDeleteSlots", conn))
                    {
                        admindeleteslot.CommandType = CommandType.StoredProcedure;
                        admindeleteslot.Parameters.AddWithValue("@current_semester", current_semester);

                        admindeleteslot.ExecuteNonQuery();

                       
                        Response.Write("Slot is deleted successfully");
                    }
                }
                else
                {
                    
                    Response.Write("Invalid semester code. Slot deletion cannot be performed.");
                }
            }
        }

    }
}



    
