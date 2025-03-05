<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkStudentToCourse.aspx.cs" Inherits="Advising_System.LinkStudentToCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Link Student to Instructor to course </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Link Student to Instructor to course</h1>
            <label for="txtCourseID">Course ID:</label>
       <asp:TextBox runat="server" ID="CourseID" Required="true" />
            <br />
            <label for="txtInstructorID">Instructor ID:</label>
          <asp:TextBox runat="server" ID="InstructorID" Required="true" />
            <br />
            <label for="txtStudentID">Student ID:</label>
        <asp:TextBox runat="server" ID="StudentID" Required="true" />

            <br />
            <label for="txtSemesterCode">Semester Code:</label>
          <asp:TextBox runat="server" ID="SemesterCode" Required="true" />

            <br />
<asp:Button runat="server" ID="btnLinkStudent" Text="Link Student" OnClick="btnLinkStudent_Click" />
                         <asp:Button runat="server" ID="Button1" Text="main page" OnClick="btnAddCourse1_Click" />
        </div>
    </form>
</body>
</html>
