using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public class DataAccess
{
    private readonly string connectionString = "Advising_System";

    public DataTable GetCoursesSlotsInstructor()
    {
        string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
        using (SqlConnection conn = new SqlConnection(connstr))
        {
            conn.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Courses_Slots_Instructor", conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }

    public DataTable GetCoursePrerequisites()
    {
        string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
        using (SqlConnection conn = new SqlConnection(connstr))
        {
            conn.Open();

            using (SqlCommand command = new SqlCommand("SELECT * FROM view_Course_prerequisites", conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }
    }
}