using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class loginadv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string AdvisorID = Request.QueryString["AdvisorID"];
                if (!string.IsNullOrEmpty(AdvisorID))
                {
                    Response.Write("Your ID is " + AdvisorID);
                }
            }
        }

        protected void LoginOnClick(object sender, EventArgs e)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            SqlConnection conn = new SqlConnection(connstr);

            int AdvisorID = int.Parse(AdvID.Text);
            string pass = AdvPass.Text;

            string query = "SELECT dbo.FN_AdvisorLogin(@advisor_id, @password)";
            SqlCommand Advloginproc = new SqlCommand(query, conn);
            if (int.TryParse(AdvID.Text, out int ID))
            {
                Advloginproc.Parameters.AddWithValue("@advisor_id", AdvisorID);
                Advloginproc.Parameters.AddWithValue("@password", pass);

                conn.Open();
                object result = Advloginproc.ExecuteScalar();

                conn.Close();


                if (result != null)
                {
                    bool successValue = (bool)result;

                    if (successValue)
                    {
                        Response.Redirect("AdvPortal.aspx?AdvisorID=" + AdvID);
                    }
                    else
                    {
                        Response.Write("Login failed");
                        Response.Write("Please register if you don't have an account");
                    }
                }
                else
                {
                    Response.Write("null");
                }
            }
            else
            {
                Response.Write("Invalid ID value. Please enter a valid number.");
            }
        }
    }
}