<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorDetails.aspx.cs" Inherits="Advising_System.InstructorDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Instructors Assigned Courses</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Instructors Assigned Courses</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="instructor_id" HeaderText="Instructor ID" SortExpression="instructor_id" />
                    <asp:BoundField DataField="Instructor" HeaderText="Instructor" SortExpression="Instructor" />
                    <asp:BoundField DataField="course_id" HeaderText="Course ID" SortExpression="course_id" />
                    <asp:BoundField DataField="Course" HeaderText="Course" SortExpression="Course" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Advising_System %>"
                SelectCommand="SELECT * FROM Instructors_AssignedCourses"></asp:SqlDataSource>
        </div>
        <asp:Button runat="server" ID="Button1" Text="Main Page" OnClick="btnAddCourse1_Click" />

    </form>
</body>
</html>
