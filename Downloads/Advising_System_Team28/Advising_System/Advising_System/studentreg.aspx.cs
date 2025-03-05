using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class studentreg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                String f_name = txtFirstName.Text;
                String l_name = txtLastName.Text; // Corrected parameter name
                String password = txtPassword.Text; // Corrected parameter name
                String faculty = txtFaculty.Text; // Corrected parameter name
                String email = txtEmail.Text; // Corrected parameter name
                String major = txtMajor.Text; // Corrected parameter name
                String semester = txtSemester.Text; // Corrected parameter name

                SqlCommand registerproc = new SqlCommand("Procedures_StudentRegistration", conn);
                registerproc.CommandType = CommandType.StoredProcedure;
                registerproc.Parameters.Add(new SqlParameter("@first_name", f_name)); // Corrected parameter name
                registerproc.Parameters.Add(new SqlParameter("@last_name", l_name)); // Corrected parameter name
                registerproc.Parameters.Add(new SqlParameter("@password", password));
                registerproc.Parameters.Add(new SqlParameter("@faculty", faculty));
                registerproc.Parameters.Add(new SqlParameter("@email", email));
                registerproc.Parameters.Add(new SqlParameter("@major", major));
                registerproc.Parameters.Add(new SqlParameter("@Semester", semester));
                SqlParameter sid = registerproc.Parameters.Add("@Student_id", SqlDbType.Int);
                sid.Direction = ParameterDirection.Output;

                conn.Open();
                registerproc.ExecuteNonQuery();
                conn.Close();

                if (sid.Value != null)
                {
                    Response.Write("Registration successful ");
                    Response.Write("Your ID is " + sid.Value);

                    // Show the "Go to Login" button after successful registration
                    Response.Redirect("studentlogin.aspx?StudentID=" + sid.Value);

                }
            }
        }

    }


}

   

