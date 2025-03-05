<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="Advising_System.AddCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Course</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add New Course</h1>
            <label for="txtMajor">Major:</label>
            <asp:TextBox runat="server" ID="txtMajor" Required="true" />
            <br />
            <label for="ddlSemester">Semester:</label>
        <asp:DropDownList runat="server" ID="ddlSemester" Required="true"></asp:DropDownList>

            <br />
            <label for="txtCreditHours">Credit Hours:</label>
            <asp:TextBox runat="server" ID="txtCreditHours" Required="true" />
            <br />
            <label for="txtCourseName">Course Name:</label>
            <asp:TextBox runat="server" ID="txtCourseName" Required="true" />
            <br />
            <label for="chkIsOffered">Is Offered:</label>
            <asp:CheckBox runat="server" ID="chkIsOffered" />
            <br />
            <asp:Button runat="server" ID="btnAddCourse" Text="Add Course" OnClick="btnAddCourse_Click" />

             <asp:Button runat="server" ID="Button1" Text="main page" OnClick="btnAddCourse1_Click" />
        </div>
    </form>
</body>
</html>
