using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Advising_System
{
    public partial class requiredcourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Write("Your ID is " + studentID);
            }

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
                    SqlCommand reqcourses = new SqlCommand("Procedures_ViewRequiredCourses", conn);
                    String cursem = TextBox2.Text;
                    if (!IsValidSemesterCode(cursem))
                    {
                        Response.Write("Invalid semester code.");
                        return;
                    }
                    else
                    {
                        reqcourses.Parameters.AddWithValue("@current_semester_code", cursem);
                    }

                    
                    reqcourses.CommandType = CommandType.StoredProcedure;
                    reqcourses.Parameters.AddWithValue("@StudentID", studID);
                    //reqcourses.Parameters.AddWithValue("@current_semester_code", cursem);

                    conn.Open();
                    SqlDataReader rdr = reqcourses.ExecuteReader(CommandBehavior.CloseConnection);
                    HtmlTable table = new HtmlTable();
                    table.Attributes["border"] = "1";
                    HtmlTableRow headerRow = new HtmlTableRow();
                    HtmlTableCell courseIdHeader = new HtmlTableCell();
                    HtmlTableCell nameHeader = new HtmlTableCell();
                    courseIdHeader.InnerText = "Course ID";
                    nameHeader.InnerText = "Course Name";
                    headerRow.Cells.Add(courseIdHeader);
                    headerRow.Cells.Add(nameHeader);
                    table.Rows.Add(headerRow);

                    while (rdr.Read())
                    {
                        string courseName = rdr.GetString(rdr.GetOrdinal("name"));
                        int courseId = rdr.GetInt32(rdr.GetOrdinal("course_id"));

                        HtmlTableRow row = new HtmlTableRow();

                        HtmlTableCell courseIdCell = new HtmlTableCell();
                        HtmlTableCell nameCell = new HtmlTableCell();

                        courseIdCell.InnerText = courseId.ToString();
                        nameCell.InnerText = courseName;

                        row.Cells.Add(courseIdCell);
                        row.Cells.Add(nameCell);

                        table.Rows.Add(row);
                    }

                    form1.Controls.Add(table);
                    Response.Write("required courses");
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
