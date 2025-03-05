<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FetchSemesters.aspx.cs" Inherits="Advising_System.FetchSemesters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Semesters with Offered Courses</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Semesters with Offered Courses</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="Course ID" SortExpression="course_id" />
                    <asp:BoundField DataField="name" HeaderText="Course Name" SortExpression="name" />
                    <asp:BoundField DataField="semester_code" HeaderText="Semester Code" SortExpression="semester_code" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Advising_System %>"
                SelectCommand="SELECT * FROM Semster_offered_Courses"></asp:SqlDataSource>

          
            <asp:Button runat="server" ID="Button1" Text="Main Page" OnClick="btnAddCourse1_Click" />
        </div>
    </form>
</body>
</html>
