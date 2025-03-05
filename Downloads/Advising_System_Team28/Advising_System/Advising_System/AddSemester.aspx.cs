using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class AddSemester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnAddCourse1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mainpage_ADMIN.aspx");

        }
        protected void btnAddSemester_Click(object sender, EventArgs e)
        {

            DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
            DateTime endDate = Convert.ToDateTime(txtEndDate.Text);
            string semesterCode = txtSemesterCode.Text;

            if (DateTime.TryParseExact(txtStartDate.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out startDate)
              && DateTime.TryParseExact(txtEndDate.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out endDate))
            {

                AddNewSemester(startDate, endDate, semesterCode);

            }
        }


        private void AddNewSemester(DateTime startDate, DateTime endDate, string semesterCode)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand checksemester = new SqlCommand("SELECT COUNT(*) FROM Semester WHERE semester_code = @semester_code", connection))
                {
                    checksemester.Parameters.AddWithValue("@semester_code", semesterCode);
                    connection.Open();
                    int existingSemesterCount = (int)checksemester.ExecuteScalar();
                    connection.Close();

                    if (existingSemesterCount > 0)
                    {
                        Response.Write("Semester with the same code already exists. Cannot add duplicate semester code.");
                        return;
                    }
                }

                using (SqlCommand cmd = new SqlCommand("AdminAddingSemester", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@start_date", startDate);
                    cmd.Parameters.AddWithValue("@end_date", endDate);
                    cmd.Parameters.AddWithValue("@semester_code", semesterCode);

                 
                        connection.Open();
              

                  cmd.ExecuteNonQuery();

                    
                        Response.Write("Semester added successfully!");
                    

                    connection.Close();
                }
            }
        }



    }
}
