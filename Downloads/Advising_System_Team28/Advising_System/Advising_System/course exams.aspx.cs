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
using System.Security.Cryptography;

namespace Advising_system
{
    public partial class course_exams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            using (SqlConnection conn = new SqlConnection(connstr))
            {

                SqlCommand viewcourses = new SqlCommand("SELECT * FROM Courses_MakeupExams", conn);
                viewcourses.CommandType = CommandType.Text;

                SqlParameter cid = viewcourses.Parameters.AddWithValue("@course_id", SqlDbType.Int);
                SqlParameter nameParam = viewcourses.Parameters.AddWithValue("@name", SqlDbType.VarChar);
                SqlParameter eid = viewcourses.Parameters.AddWithValue("@exam_id", SqlDbType.Int);
                SqlParameter dateParam = viewcourses.Parameters.AddWithValue("@date", SqlDbType.DateTime);
                SqlParameter typeParam = viewcourses.Parameters.AddWithValue("@type", SqlDbType.VarChar);


                conn.Open();

                    SqlDataReader rdr = viewcourses.ExecuteReader(CommandBehavior.CloseConnection);
                    HtmlTable table = new HtmlTable();
                    table.Attributes["border"] = "1";
                    HtmlTableRow headerRow = new HtmlTableRow();

                    HtmlTableCell courseIdHeader = new HtmlTableCell();
                    HtmlTableCell nameHeader = new HtmlTableCell();
                    HtmlTableCell examIdHeader = new HtmlTableCell();
                    HtmlTableCell dateHeader = new HtmlTableCell();
                    HtmlTableCell typeHeader = new HtmlTableCell();

                    courseIdHeader.InnerText = "Course ID";
                    nameHeader.InnerText = "Course Name";
                    examIdHeader.InnerText = "Exam ID";
                    dateHeader.InnerText = "Date";
                    typeHeader.InnerText = "Type";
                

                    headerRow.Cells.Add(courseIdHeader);
                    headerRow.Cells.Add(nameHeader);
                    headerRow.Cells.Add(examIdHeader);
                    headerRow.Cells.Add(dateHeader);
                    headerRow.Cells.Add(typeHeader);


                    table.Rows.Add(headerRow);

                while (rdr.Read())
                {
                    int courseId = rdr.GetInt32(rdr.GetOrdinal("course_id"));
                    string courseName = rdr.GetString(rdr.GetOrdinal("name"));
                    int eId = rdr.GetInt32(rdr.GetOrdinal("exam_id"));
                    DateTime dated = rdr.GetDateTime(rdr.GetOrdinal("date"));
                    string types = rdr.GetString(rdr.GetOrdinal("type"));
                    HtmlTableRow row = new HtmlTableRow();

                        HtmlTableCell courseIdCell = new HtmlTableCell();
                        HtmlTableCell nameCell = new HtmlTableCell();
                        HtmlTableCell examIdCell = new HtmlTableCell();
                        HtmlTableCell dateCell = new HtmlTableCell();
                        HtmlTableCell typeCell = new HtmlTableCell();

                        courseIdCell.InnerText = courseId.ToString();
                        nameCell.InnerText = courseName;
                        examIdCell.InnerText = eId.ToString();
                        dateCell.InnerText = dated.ToString();
                        typeCell.InnerText = types.ToString();

                        row.Cells.Add(courseIdCell);
                        row.Cells.Add(nameCell);
                        row.Cells.Add(examIdCell);
                        row.Cells.Add(dateCell);
                        row.Cells.Add(typeCell);

                    table.Rows.Add(row);
                    }

                    form1.Controls.Add(table);



                    Response.Write("courses and exams details");
                }

            }
        }
    }
