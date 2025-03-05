using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace Advising_System
{
    public partial class ApproveRejectCoursesRequest : System.Web.UI.Page
    {
        string currentSemesterCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int requestID = GetRequestID();
                DisplayRequestDetails(requestID);
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int requestID = GetRequestID();
            ApproveRequest(requestID);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int requestID = GetRequestID();
            RejectRequest(requestID);
        }

        private int GetRequestID()
        {
            int requestID = Convert.ToInt32(Request.QueryString["request_id"]);
            return requestID;
        }

        private void DisplayRequestDetails(int requestID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand viewRequestDetailsCmd = new SqlCommand("SELECT * FROM Request WHERE request_id = @request_id", conn))
                {
                    viewRequestDetailsCmd.Parameters.AddWithValue("@request_id", requestID);

                    using (SqlDataReader reader = viewRequestDetailsCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblRequestDetails.Text = "Request ID: " + reader["request_id"] + ", Type: " + reader["type"] + ", ...";
                        }
                    }
                }
            }
        }

        private void ApproveRequest(int requestID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand approveRequestCmd = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", conn))
                {
                    approveRequestCmd.CommandType = CommandType.StoredProcedure;
                    approveRequestCmd.Parameters.AddWithValue("@requestID", requestID);
                    approveRequestCmd.Parameters.AddWithValue("@current_semester_code", currentSemesterCode);

                    approveRequestCmd.ExecuteNonQuery();
                }
            }
        }

        private void RejectRequest(int requestID)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand rejectRequestCmd = new SqlCommand("Procedures_AdvisorApproveRejectCourseRequest", conn))
                {
                    rejectRequestCmd.CommandType = CommandType.StoredProcedure;
                    rejectRequestCmd.Parameters.AddWithValue("@requestID", requestID);
                    rejectRequestCmd.Parameters.AddWithValue("@current_semester_code", currentSemesterCode);

                    rejectRequestCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
