using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class studentlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string studentID = Request.QueryString["StudentID"];
                if (!string.IsNullOrEmpty(studentID))
                {
                    // Display the student ID as needed
                    Response.Write("Your ID is " + studentID);
                }
            }

        }
        protected void login_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connstr))
            {
               // int ID = Int16.Parse(txtID.Text);
                string password = txtPassword.Text;

                string query = "SELECT dbo.FN_StudentLogin(@Student_id, @Password)";
                SqlCommand studloginproc = new SqlCommand(query, conn);

                if (int.TryParse(txtID.Text, out int ID))
                {
                    studloginproc.Parameters.AddWithValue("@Student_id", ID);
                    studloginproc.Parameters.AddWithValue("@Password", password);

                    conn.Open();


                    object result = studloginproc.ExecuteScalar();

                    conn.Close();




                    if (result != null)
                    {
                        bool successValue = (bool)result;

                        if (successValue)
                        {
                            Response.Redirect("options.aspx?StudentID=" + ID); ;
                        }
                        else
                        {
                            Response.Write("Login failed");
                        }
                    }
                    else
                    {
                        Response.Write("null");
                    }
                }

                else
                {
                    // Handle the case where creditText cannot be converted to an integer
                    Response.Write("Invalid ID value. Please enter a valid number.");
                }
                }
        }
    }
}