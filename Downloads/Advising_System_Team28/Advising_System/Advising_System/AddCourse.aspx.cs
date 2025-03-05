using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class AddCourse : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                for (int i = 1; i <= 15; i++)
                {
                    ddlSemester.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
        }
        protected void btnAddCourse1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mainpage_ADMIN.aspx");

        }
        
            
        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string major = txtMajor.Text;
            int semester = Convert.ToInt32(ddlSemester.SelectedValue);
            int creditHours = Convert.ToInt32(txtCreditHours.Text);
            string courseName = txtCourseName.Text;
            bool isOffered = chkIsOffered.Checked;

            AddNewCourse(major, semester, creditHours, courseName, isOffered);
        }

        private void AddNewCourse(string major, int semester, int creditHours, string courseName, bool isOffered)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand checkcourse = new SqlCommand("SELECT COUNT(*) FROM Course WHERE name = @name", connection))
                {
                    checkcourse.Parameters.AddWithValue("@name", courseName);
                    checkcourse.Parameters.AddWithValue("@semester", semester);
                    checkcourse.Parameters.AddWithValue("@major", major);
                    connection.Open();
                    int existingCourseCount = (int)checkcourse.ExecuteScalar();
                    connection.Close();

                    if (existingCourseCount > 0)
                    {
                        Response.Write("Course with the same name already exists. Cannot add duplicate course name.");
                        return;
                    }
                }

                using (SqlCommand cmd = new SqlCommand("Procedures_AdminAddingCourse", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@major", major);
                    cmd.Parameters.AddWithValue("@semester", semester);
                    cmd.Parameters.AddWithValue("@credit_hours", creditHours);
                    cmd.Parameters.AddWithValue("@name", courseName);
                    cmd.Parameters.AddWithValue("@is_offered", isOffered);

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("Course added successfully!");
                    }
                    else
                    {
                        Response.Write("No rows were affected. Course may not have been added.");
                    }

                    connection.Close();
                }
            }
        }
    }
}
