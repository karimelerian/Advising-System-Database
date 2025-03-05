<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="courseprereq.aspx.cs" Inherits="Advising_system.courseprereq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Course Prerequisites View</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="course_id" HeaderText="Course ID" SortExpression="course_id" />
                    <asp:BoundField DataField="major" HeaderText="Major" SortExpression="major" />
                    <asp:BoundField DataField="is_offered" HeaderText="is_offered" SortExpression="is_offered" />
                    <asp:BoundField DataField="credit_hours" HeaderText="credit_hours" SortExpression="credit_hours" />
                    <asp:BoundField DataField="semester" HeaderText=" semester" SortExpression="semester" />
                    <asp:BoundField DataField="name" HeaderText="Course Name" SortExpression="name" />
                    <asp:BoundField DataField="preRequsite_course_id" HeaderText="Prerequisite ID" SortExpression="preRequsite_course_id" />
                    <asp:BoundField DataField="preRequsite_course_name" HeaderText="Prerequisite Name" SortExpression="preRequsite_course_name" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
