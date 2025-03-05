<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentsWithAdvisors.aspx.cs" Inherits="Advising_System.StudentsWithAdvisors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Students with Advisors</h1>
        <asp:GridView ID="GridViewStudentsWithAdvisors" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="student_id" HeaderText="Student ID" />
                <asp:BoundField DataField="f_name" HeaderText="First Name" />
                <asp:BoundField DataField="l_name" HeaderText="Last Name" />
                <asp:BoundField DataField="advisor_id" HeaderText="Advisor ID" />
                <asp:BoundField DataField="advisor_name" HeaderText="Advisor Name" />
            </Columns>
        </asp:GridView>
         <asp:Button runat="server" ID="Button1" Text="main page" OnClick="btnAddCourse1_Click" />
    </form>
</body>
</html>
