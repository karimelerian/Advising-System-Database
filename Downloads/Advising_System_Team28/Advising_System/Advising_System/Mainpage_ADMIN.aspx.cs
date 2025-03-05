using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class Mainpage_ADMIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdvisors_Click(object sender, EventArgs e)
        {
            Response.Redirect("Advisors.aspx");
        }

        protected void btnStudentsWithAdvisors_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentsWithAdvisors.aspx");
        }

        protected void btnPendingRequests_Click(object sender, EventArgs e)
        {
            Response.Redirect("PendingRequests.aspx");
        }

        protected void btnAddSemester_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddSemester.aspx");
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }

        protected void btnLinkInstructorToCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("LinkInstructorToCourse.aspx");
        }

        protected void btnLinkStudentToAdvisor_Click(object sender, EventArgs e)
        {
            Response.Redirect("LinkStudentToAdvisor.aspx");
        }

        protected void btnLinkStudentToCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("LinkStudentToCourse.aspx");
        }

        protected void btnViewInstructorDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstructorDetails.aspx");
        }

        protected void btnFetchSemesters_Click(object sender, EventArgs e)
        {
            Response.Redirect("FetchSemesters.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("delete_course_slot.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_deleteslots.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("addmakeup.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewpayments.aspx");
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("issueinstallment.aspx");
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("updatestatus.aspx");
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("activestudents.aspx");
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewgradplan.aspx");
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("studenttranscript.aspx");
        }

    }
}