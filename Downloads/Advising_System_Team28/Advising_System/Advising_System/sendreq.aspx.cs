using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Advising_System
{
    public partial class sendreq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string studentID = Request.QueryString["StudentID"];
                if (!string.IsNullOrEmpty(studentID))
                {
                    int studID;
                    if (int.TryParse(studentID, out studID))
                    {
                        String CID = courseIDtxt.Text;
                        int courseID;
                        if (int.TryParse(CID, out courseID))
                        {
                            String type = typetxt.Text;
                            String comment = commenttxt.Text;

                            // Check if the course exists before proceeding
                            if (CourseExists(courseID))
                            {
                                SqlCommand registerproc = new SqlCommand("Procedures_StudentSendingCourseRequest", conn);
                                registerproc.CommandType = CommandType.StoredProcedure;
                                registerproc.Parameters.Add(new SqlParameter("@courseID", courseID));
                                registerproc.Parameters.Add(new SqlParameter("@type", type));
                                registerproc.Parameters.Add(new SqlParameter("@comment", comment));
                                registerproc.Parameters.Add(new SqlParameter("@StudentID", studID));

                                conn.Open();
                                registerproc.ExecuteNonQuery();
                                conn.Close();

                                Response.Write("Request sent successfully");
                            }
                            else
                            {
                                Response.Write("Error: The specified course does not exist.");
                            }
                        }
                        else
                        {
                            Response.Write("Error: Invalid course ID format.");
                        }
                    }
                    else
                    {
                        Response.Write("Error: Invalid student ID format.");
                    }
                }
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


    }
}