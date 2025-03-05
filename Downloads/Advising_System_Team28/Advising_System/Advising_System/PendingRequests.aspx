<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PendingRequests.aspx.cs" Inherits="Advising_System.PendingRequests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Pending Requests</title>
</head>
<body>
    <h1>All Pending Requests</h1>
    <form id="form1" runat="server">
        <asp:GridView ID="GridViewPendingRequests" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="request_id" HeaderText="Request ID" />
                <asp:BoundField DataField="type" HeaderText="Type" />
                <asp:BoundField DataField="comment" HeaderText="Comment" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:BoundField DataField="credit_hours" HeaderText="Credit Hours" />
                <asp:BoundField DataField="course_id" HeaderText="Course ID" />
                <asp:BoundField DataField="student_id" HeaderText="Student ID" />
                <asp:BoundField DataField="advisor_id" HeaderText="Advisor ID" />
            </Columns>
        </asp:GridView>
         <asp:Button runat="server" ID="Button1" Text="main page" OnClick="btnAddCourse1_Click" />
    </form>
</body>
</html>
