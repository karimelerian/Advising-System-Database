<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkInstructorToCourse.aspx.cs" Inherits="Advising_System.LinkInstructorToCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Link Instructor to Slot For Course</title>
</head>
<body>

    <h1>Link Instructor to Slot For Course</h1>

    <form id="form1" runat="server">

        <label for="courseId">Course ID:</label>
        <input type="text" id="courseId" name="courseId" required>

        <label for="instructorId">Instructor ID:</label>
        <input type="text" id="instructorId" name="instructorId" required>

        <label for="slotId">Slot ID:</label>
        <input type="text" id="slotId" name="slotId" required>

        <input type="submit" value="Link Instructor">
         <asp:Button runat="server" ID="Button1" Text="main page" OnClick="btnAddCourse1_Click" />
    </form>

</body>
</html>
