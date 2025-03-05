<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="graduation_plan.aspx.cs" Inherits="Advising_system.graduation_plan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student View</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Student Information</h1>

      

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Student_name" HeaderText="Student Name" />
                <asp:BoundField DataField="plan_id" HeaderText="Plan ID" />
                <asp:BoundField DataField="semester_code" HeaderText="Semester Code" />
                <asp:BoundField DataField="semester_credit_hours" HeaderText="Semester Credit Hours" />
                <asp:BoundField DataField="expected_grad_date" HeaderText="Expected Graduation Date" />
                <asp:BoundField DataField="advisor_id" HeaderText="Advisor ID" />
                <asp:BoundField DataField="student_id" HeaderText="Student ID" />
                <asp:BoundField DataField="course_id" HeaderText="Course ID" />
                <asp:BoundField DataField="name" HeaderText="Course Name" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
