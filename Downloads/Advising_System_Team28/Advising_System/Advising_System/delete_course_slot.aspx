<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete_course_slot.aspx.cs" Inherits="Advising_System.delete_course_slot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Course</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="courseId">Course ID:</label>
            <asp:TextBox ID="courseId" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnDeleteCourse" OnClick="btnDeleteCourse_Click" runat="server" Text="Delete Course" />
        </div>
    </form>
</body>
</html>