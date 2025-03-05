using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Advising_system
{
    public partial class certainCoursecertainInstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string query = "SELECT  Course, Instructor, slot_id, day, time, location FROM dbo.FN_StudentViewSlot (@CourseID, @InstructorID)";

                using (SqlCommand certain = new SqlCommand(query, conn))
                {
                    int courseID;
                    int instructorID;

                    if (int.TryParse(TextBox1.Text, out courseID))
                    {
                        if (int.TryParse(TextBox2.Text, out instructorID))
                        {
                            //int courseID = Convert.ToInt32(TextBox1);
                            //int instructorID = Convert.ToInt32(TextBox2);

                            certain.Parameters.AddWithValue("@CourseID", courseID);
                            certain.Parameters.AddWithValue("@InstructorID", instructorID);



                            using (SqlDataReader rdr = certain.ExecuteReader(CommandBehavior.CloseConnection))
                            {

                                HtmlTable table = new HtmlTable();
                                table.Attributes["border"] = "1";

                                HtmlTableRow headerRow = new HtmlTableRow();

                                HtmlTableCell slotIdHeader = new HtmlTableCell();
                                HtmlTableCell dayHeader = new HtmlTableCell();
                                HtmlTableCell timeHeader = new HtmlTableCell();
                                HtmlTableCell locationHeader = new HtmlTableCell();
                                HtmlTableCell courseIDHeader = new HtmlTableCell();
                                HtmlTableCell instructorIDHeader = new HtmlTableCell();

                                slotIdHeader.InnerText = "slot ID";
                                dayHeader.InnerText = "day";
                                timeHeader.InnerText = "time";
                                locationHeader.InnerText = "location";
                                courseIDHeader.InnerText = "Course Name";
                                instructorIDHeader.InnerText = "Instructor Name";


                                headerRow.Cells.Add(slotIdHeader);
                                headerRow.Cells.Add(dayHeader);
                                headerRow.Cells.Add(timeHeader);
                                headerRow.Cells.Add(locationHeader);
                                headerRow.Cells.Add(courseIDHeader);
                                headerRow.Cells.Add(instructorIDHeader);

                                table.Rows.Add(headerRow);

                                while (rdr.Read())
                                {

                                    int slotId = rdr.GetInt32(rdr.GetOrdinal("slot_id"));
                                    string day = rdr.GetString(rdr.GetOrdinal("day"));
                                    string time = rdr.GetString(rdr.GetOrdinal("time"));
                                    string location = rdr.GetString(rdr.GetOrdinal("location"));
                                    string courseId = rdr.GetString(rdr.GetOrdinal("Course"));
                                    string instructorId = rdr.GetString(rdr.GetOrdinal("Instructor"));


                                    HtmlTableRow row = new HtmlTableRow();

                                    HtmlTableCell slotIdCell = new HtmlTableCell();
                                    HtmlTableCell dayCell = new HtmlTableCell();
                                    HtmlTableCell timeCell = new HtmlTableCell();
                                    HtmlTableCell locationCell = new HtmlTableCell();
                                    HtmlTableCell courseIDCell = new HtmlTableCell();
                                    HtmlTableCell instructorIDCell = new HtmlTableCell();

                                    slotIdCell.InnerText = slotId.ToString();
                                    dayCell.InnerText = day.ToString();
                                    timeCell.InnerText = time.ToString();
                                    locationCell.InnerText = location.ToString();
                                    courseIDCell.InnerText = courseId;
                                    instructorIDCell.InnerText = instructorId;

                                    row.Cells.Add(slotIdCell);
                                    row.Cells.Add(dayCell);
                                    row.Cells.Add(timeCell);
                                    row.Cells.Add(locationCell);
                                    row.Cells.Add(courseIDCell);
                                    row.Cells.Add(instructorIDCell);

                                    table.Rows.Add(row);
                                }

                                form1.Controls.Add(table);
                                Response.Write("slots of a certain course that is taught by a certain instructor");
                            }
                        }
                        else
                        {
                            Response.Write("invalid  Instructor ID");
                        }
                        }

                        else
                        {
                            Response.Write("invalid Course ID");
                        }
                    }
                }
            }
        }
    } 
