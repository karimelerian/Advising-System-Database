using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class addmakeup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DateTime examDate = DateTime.Parse(Request.Form["date"]);
                string examType = Request.Form["type"];
                int courseId = int.Parse(Request.Form["courseId"]);

                using (SqlCommand command = new SqlCommand("INSERT INTO MakeUp_Exam (date, type, course_id) VALUES (@date, @type, @courseId)", connection))
                {
                    command.Parameters.AddWithValue("@date", examDate);
                    command.Parameters.AddWithValue("@type", examType);
                    command.Parameters.AddWithValue("@courseId", courseId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("Makeup exam added successfully!");
                    }
                    else
                    {
                        Response.Write("Failed to add makeup exam.");
                    }
                }
            }
        }
    }
    
}