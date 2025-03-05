using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class issueinstallment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool paymentExists(int paymentid)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM dbo.payment WHERE payment_id = @paymentid", connection))
                {
                    command.Parameters.AddWithValue("@paymentid", paymentid);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Advising_System"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string paymentid = TextBox1.Text;
                if (paymentExists(int.Parse(paymentid)))
                {
                    using (SqlCommand issue = new SqlCommand("Procedures_AdminIssueInstallment", conn))
                    {
                        issue.CommandType = CommandType.StoredProcedure;
                        issue.Parameters.AddWithValue("@payment_id", paymentid);
                        issue.ExecuteNonQuery();
                        Response.Write("instalment is issued successfully");
                    }
                }
                else
                    Response.Write("please enter a valid payment id");


            }

        }
    }
}
