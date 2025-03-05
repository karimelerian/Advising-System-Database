<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mainpage_ADMIN.aspx.cs" Inherits="Advising_System.Mainpage_ADMIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Main Page - Advising System</title>
   <style>
    body {
        font-family: 'Times New Roman', Times, serif, sans-serif;
        background-color: #b6ff00;
        margin: 0;
        padding: 0;
        text-align: center;
    }

    form {
        max-width: 800px;
        margin: 50px auto;
        background-color: #fff;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    h1 {
        color: #3d7898;
    }

    .button-container {
        display: block;
        margin-bottom: 20px;
    }

    button {
        display: block;
        width: 100%;
        margin: 10px 0;
        padding: 10px;
        font-size: 16px;
        background-color: #cd9090 
        color: #cd9090;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    button:hover {
        background-color: #0056b3;
    }
</style>

</head>
<body>
  <form id="form1" runat="server">
        <h1>Main Page</h1>

        <div class="button-container">
            <asp:Button runat="server" ID="btnAdvisors" Text="List Advisors" OnClick="btnAdvisors_Click" />
            <asp:Button runat="server" ID="btnStudentsWithAdvisors" Text="List Students with Advisors" OnClick="btnStudentsWithAdvisors_Click" />
        </div>

        <div class="button-container">
            <asp:Button runat="server" ID="btnPendingRequests" Text="List Pending Requests" OnClick="btnPendingRequests_Click" />
            <asp:Button runat="server" ID="btnAddSemester" Text="Add New Semester" OnClick="btnAddSemester_Click" />
        </div>

        <div class="button-container">
            <asp:Button runat="server" ID="btnAddCourse" Text="Add New Course" OnClick="btnAddCourse_Click" />
            <asp:Button runat="server" ID="btnLinkInstructorToCourse" Text="Link Instructor to Course" OnClick="btnLinkInstructorToCourse_Click" />
        </div>

        <div class="button-container">
            <asp:Button runat="server" ID="btnLinkStudentToAdvisor" Text="Link Student to Advisor" OnClick="btnLinkStudentToAdvisor_Click" />
            <asp:Button runat="server" ID="btnLinkStudentToCourse" Text="Link Student to Course" OnClick="btnLinkStudentToCourse_Click" />
        </div>

        <div class="button-container">
            <asp:Button runat="server" ID="btnViewInstructorDetails" Text="View Instructor Details" OnClick="btnViewInstructorDetails_Click" />
            <asp:Button runat="server" ID="btnFetchSemesters" Text="Fetch Semesters" OnClick="btnFetchSemesters_Click" />
        </div>

        <div class="button-container">
            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="delete course with slots" />
            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="delete slot" />
            <asp:Button ID="button3" OnClick="Button3_Click" runat="server" Text="add makeup" />
        </div>

        <div class="button-container">
            <asp:Button ID="Button4" OnClick="Button4_Click" runat="server" Text="payment details" />
            <asp:Button ID="Button5" OnClick="Button5_Click" runat="server" Text="issue instalment" />
            <asp:Button ID="Button6" OnClick="Button6_Click" runat="server" Text="update status" />
        </div>

        <div class="button-container">
            <asp:Button ID="Button7" OnClick="Button7_Click" runat="server" Text="active students" />
            <asp:Button ID="Button8" OnClick="Button8_Click" runat="server" Text="graduation plan" />
            <asp:Button ID="Button9" OnClick="Button9_Click" runat="server" Text="transcript details" />
        </div>
    </form>
</body>
</html>
