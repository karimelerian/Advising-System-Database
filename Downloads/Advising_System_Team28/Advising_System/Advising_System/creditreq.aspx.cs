using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class creditreq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string studentID = Request.QueryString["StudentID"];
                if (!string.IsNullOrEmpty(studentID))
                {
                    // Use the student ID obtained from the query string
                    int studID = Convert.ToInt32(studentID);

                    // Get the text from the TextBox controls
                    string creditText = credittxt.Text;
                    string type = typetxt.Text;
                    string comment = commenttxt.Text;

                    // Convert the text to integers
                    if (int.TryParse(creditText, out int Credit))
                    {
                        SqlCommand registerproc = new SqlCommand("Procedures_StudentSendingCHRequest", conn);
                        registerproc.CommandType = CommandType.StoredProcedure;
                        registerproc.Parameters.Add(new SqlParameter("@credit_hours", Credit));
                        registerproc.Parameters.Add(new SqlParameter("@type", type));
                        registerproc.Parameters.Add(new SqlParameter("@comment", comment));
                        registerproc.Parameters.Add(new SqlParameter("@StudentID", studID));
                        conn.Open();
                        registerproc.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("Request sent successfully");
                    }
                    else
                    {
                        // Handle the case where creditText cannot be converted to an integer
                        Response.Write("Invalid credit hours value. Please enter a valid number.");
                    }
                }
            }
        }

    }

}