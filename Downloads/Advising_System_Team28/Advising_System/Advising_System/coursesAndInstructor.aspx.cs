using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_system
{
    public partial class coursesAndInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                int courseID;
                int instructorID;
                string cursem = TextBox2.Text;
                string studentID = Request.QueryString["StudentID"];

                if (!string.IsNullOrEmpty(studentID))
                {
                    int studID = Convert.ToInt32(studentID);
                }

                if (!int.TryParse(TextBox3.Text, out courseID))
                {
                    Response.Write("Invalid course id");
                }
                else if (!int.TryParse(TextBox2.Text, out instructorID))
                {
                    Response.Write("Invalid instructor id");
                }
              
                else
                {
                    SqlCommand chooseinstproc = new SqlCommand("Procedures_ChooseInstructor", conn);
                    chooseinstproc.CommandType = CommandType.StoredProcedure;

                    chooseinstproc.Parameters.AddWithValue("@CourseID", courseID);
                    chooseinstproc.Parameters.AddWithValue("@StudentID", studentID);
                    chooseinstproc.Parameters.AddWithValue("@instrucorID", instructorID);
                    chooseinstproc.Parameters.AddWithValue("@current_semester_code", cursem);

                    try
                    {
                        conn.Open();
                        chooseinstproc.ExecuteNonQuery();
                        Response.Write("Instructor Chosen");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error executing stored procedure: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

     

    }
}