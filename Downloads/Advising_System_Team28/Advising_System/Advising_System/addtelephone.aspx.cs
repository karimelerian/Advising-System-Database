using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System;

namespace Advising_System
{
    public partial class addtelephone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Write("Your ID is " + studentID);
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    string studentID = Request.QueryString["StudentID"];
                    if (!string.IsNullOrEmpty(studentID))
                    {
                        int studID = Convert.ToInt32(studentID);
                        string phonenum = num.Text;
                        SqlCommand addnumproc = new SqlCommand("Procedures_StudentaddMobile", conn);
                        addnumproc.CommandType = CommandType.StoredProcedure;
                        addnumproc.Parameters.AddWithValue("@StudentID", studID);
                        addnumproc.Parameters.AddWithValue("@mobile_number", phonenum);
                        conn.Open();
                        addnumproc.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("Phone number added");
                    }
                    else
                    {
                        Response.Write("Student ID is not available.");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) 
                {
                    Response.Write("Error: This phone number already exists for the student.");
                }
                else
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}