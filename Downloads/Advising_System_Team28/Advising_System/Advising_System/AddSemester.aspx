<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSemester.aspx.cs" Inherits="Advising_System.AddSemester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Add New Semester</h1>
            <label for="txtStartDate">Start Date:</label>
            <asp:TextBox runat="server" ID="txtStartDate" TextMode="Date" Required="true" />
            <br />
            <label for="txtEndDate">End Date:</label>
            <asp:TextBox runat="server" ID="txtEndDate" TextMode="Date" Required="true" />
            <br />
            <label for="txtSemesterCode">Semester Code:</label>
            <asp:TextBox runat="server" ID="txtSemesterCode" Required="true" />
            <br />
            <asp:Button runat="server" ID="btnAddSemester" Text="Add Semester" OnClick="btnAddSemester_Click" />
            
             <asp:Button runat="server" ID="Button1" Text="main page" OnClick="btnAddCourse1_Click" />
        </div>
    </form>
</body></html>
