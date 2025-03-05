using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advising_System
{
    public partial class options : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Write("Your ID is " + studentID);
            }

        }

        protected void addtel_Click(object sender, EventArgs e)
        {
            
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("addtelephone.aspx?StudentID=" + studentID);
            }
            else
            {
                Response.Write("Student ID is not available.");
            }

        }
        protected void optcourse_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("optionalcourses.aspx?StudentID=" + studentID);
            }
            else
            {
                Response.Write("Student ID is not available.");
            }
        }

        protected void avcourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("availablecourses.aspx");
            
            
            

        }
        protected void reqcourse_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("requiredcourses.aspx?StudentID=" + studentID);
            }
            else
            {
                Response.Write("Student ID is not available.");
            }

        }
        protected void misscourse_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("missingcourses.aspx?StudentID=" + studentID);
            }
            else
            {
                Response.Write("Student ID is not available.");
            }

        }


        protected void sendcoursereq_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("sendreq.aspx?StudentID=" + studentID);
            }
            else
            {

                Response.Write("Student ID is not available.");
            }
        }
        protected void sendcreditreq_Click(object sender, EventArgs e)
        {

            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("creditreq.aspx?StudentID=" + studentID);
            }
            else
            {

                Response.Write("Student ID is not available.");
            }
        }
       //
        protected void allcoursescorresponding_Click(object sender, EventArgs e)
        {
            Response.Redirect("slotscourseinstructor.aspx");
        }

        protected void coursedeets_Click(object sender, EventArgs e)
        {
            Response.Redirect("courseprereq.aspx");
        }


        protected void certain_Click(object sender, EventArgs e)
        {

            Response.Redirect("certainCoursecertainInstructor.aspx");
        }

        protected void courseexam_Click(object sender, EventArgs e)
        {

            Response.Redirect("course exams.aspx");
        }

        protected void courseandinstruc_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("coursesAndInstructor.aspx?StudentID=" + studentID);
            }
            else
            {

                Response.Write("Student ID is not available.");
            }
        }

        protected void frstmakeup_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("firstmakeup.aspx?StudentID=" + studentID);
            }
            else
            {

                Response.Write("Student ID is not available.");
            }
        }

        protected void scndmakeup_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("secondmakeup.aspx?StudentID=" + studentID);
            }
            else
            {

                Response.Write("Student ID is not available.");
            }
        }

        protected void gradplan_Click(object sender, EventArgs e)
        {

            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("graduation_plan.aspx?StudentID=" + studentID);
            }
            else
            {

                Response.Write("Student ID is not available.");
            }
        }

        protected void install_Click(object sender, EventArgs e)
        {
            string studentID = Request.QueryString["StudentID"];
            if (!string.IsNullOrEmpty(studentID))
            {
                Response.Redirect("installments.aspx?StudentID=" + studentID);
            }
            else
            {

                Response.Write("Student ID is not available.");
            }

        }
    }
}
    