using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class AdvPortal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Write("Your ID is " + AdvisorID);
            }
        }
        protected void BackToLogin_OnClick(object sender, EventArgs e)
        {
            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("loginadv.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }
        protected void ViewAdvStuds_OnClick(object sender, EventArgs e)
        {
            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("ViewAllAdvStuds.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void InsertGradPlan_OnClick(object sender, EventArgs e)
        {
            
            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("GradPlanForStuds.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void InsertCoursesForGradPlan_OnClick(object sender, EventArgs e)
        {

            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("CourseForGradPlan.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void UpdateExpectedGradDateForGradPlan_OnClick(object sender, EventArgs e)
        {

            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("UpdateGraduationPlan.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void DeleteCoursesFromGradPlan_OnClick(object sender, EventArgs e)
        {

            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("DeleteCourseFromGP.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void ViewAssignedStuds_OnClick(object sender, EventArgs e)
        {

            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("ViewAssignedStudsToAdv.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void ViewReqs_OnClick(object sender, EventArgs e)
        {

            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("ViewReqs.aspx?AdvisorID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void ViewPendingReqs_OnClick(object sender, EventArgs e)
        {
            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("ViewPendingReqs.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void AppOrRejExCH_Request_OnClick(object sender, EventArgs e)
        {

            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("ApproveRejectCHRequest.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

        protected void AppOrRejExCourses_Request_OnClick(object sender, EventArgs e)
        {

            string AdvisorID = Request.QueryString["AdvisorID"];
            if (!string.IsNullOrEmpty(AdvisorID))
            {
                Response.Redirect("ApproveRejectCoursesRequest.aspx?AdvisorSID=" + AdvisorID);
            }
            else
            {

                Response.Write("Advisor ID is not available.");
            }
        }

    }
}