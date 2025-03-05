using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Advising_system
{
    public partial class firstmakeup : System.Web.UI.Page
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

                    int studID = Convert.ToInt32(studentID);
                }
                    string cursem = TextBox2.Text;
                if (!IsValidSemesterCode(cursem))
                {
                    Response.Write("Invalid semester code.");
                    return;
                }
                else
                {
                    int courseID;
                    if (!int.TryParse(TextBox1.Text, out courseID))
                    {
                        Response.Write("Invalid course id");
                    }
                    else
                    {

                       
                       
                        SqlCommand firstmakeup = new SqlCommand("Procedures_StudentRegisterFirstMakeup", conn);

                        firstmakeup.CommandType = CommandType.StoredProcedure;
                        firstmakeup.Parameters.Add(new SqlParameter("@StudentID", studentID));
                        firstmakeup.Parameters.Add(new SqlParameter("@studentCurr_sem", cursem));
                        firstmakeup.Parameters.Add(new SqlParameter("@courseID", courseID));



                        conn.Open();

                        firstmakeup.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("Registration successful ");

                    }
                }
            }
        }
            private bool IsValidSemesterCode(string semesterCode)
            {
                string connectionString = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

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
        } 
}