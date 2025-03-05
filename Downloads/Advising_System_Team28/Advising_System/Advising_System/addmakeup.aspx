<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addmakeup.aspx.cs" Inherits="Advising_System.addmakeup" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Add Makeup Exam</title>
</head>
 <body>
    <form runat="server" id="form1">
        <div>
            <h2>Add Makeup Exam</h2>
            <label for="date">Exam Date:</label>
            <input type="date" id="date" name="date" required>
            <br>
            <label for="type">Exam Type:</label>
            <input type="text" id="type" name="type" required>
            <br>
            <label for="courseId">Course ID:</label>
            <input type="number" id="courseId" name="courseId" required>
            <br>
            <asp:Button ID="Button1" runat="server" Text="add exam" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
