using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class missingcourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {

                Response.Write("Your ID is " + studentID);
            }
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            using (SqlConnection conn = new SqlConnection(connstr))
            {

                if (!string.IsNullOrEmpty(studentID))
                {
                    // Use the student ID obtained from the query string
                    int studID = Convert.ToInt32(studentID);

                    SqlCommand misscourses = new SqlCommand("Procedures_ViewMS", conn);
                    misscourses.CommandType = CommandType.StoredProcedure;
                    misscourses.Parameters.AddWithValue("@StudentID", studID);
                    conn.Open();
                    SqlDataReader rdr = misscourses.ExecuteReader(CommandBehavior.CloseConnection);
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
                    Response.Write("missing courses");
                }

            }
        }
    }
}



            
