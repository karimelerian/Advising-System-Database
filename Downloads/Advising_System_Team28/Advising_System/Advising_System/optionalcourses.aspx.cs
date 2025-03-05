using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class optionalcourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                // Display the student ID as needed
                Response.Write("Your ID is             " + studentID);
            }
        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string studentID = Request.QueryString["StudentID"];
                if (!string.IsNullOrEmpty(studentID))
                {
                    // Use the student ID obtained from the query string
                    int studID = Convert.ToInt32(studentID);

                    // Check the validity of the semester code
                    string cursem = TextBox2.Text;
                    if (!IsValidSemesterCode(cursem))
                    {
                        Response.Write("Invalid semester code.");
                        return;
                    }

                    SqlCommand optcourses = new SqlCommand("Procedures_ViewOptionalCourse", conn);
                    optcourses.CommandType = CommandType.StoredProcedure;
                    optcourses.Parameters.AddWithValue("@StudentID", studID);
                    optcourses.Parameters.AddWithValue("@current_semester_code", cursem);

                    conn.Open();
                    SqlDataReader rdr = optcourses.ExecuteReader(CommandBehavior.CloseConnection);
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

                    Response.Write("Optional courses");
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
