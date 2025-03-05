<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinkStudentToAdvisor.aspx.cs" Inherits="Advising_System.LinkStudentToAdvisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Link Student to Advisor</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Link Student to Advisor</h2>
            
            <div>
                <label for="instructorId">Instructor ID:</label>
                <asp:TextBox ID="instructorId" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="studentId">Student ID:</label>
                <asp:TextBox ID="studentId" runat="server"></asp:TextBox>
            </div>
           
            <div>
                <asp:Button ID="linkStudentButton" runat="server" Text="Link Student" OnClick="LinkStudentButton_Click" />
            </div>
            <div>
                <asp:Literal ID="resultMessage" runat="server"></asp:Literal>
            </div>
        </div>
                   <asp:Button runat="server" ID="Button1" Text="main page" OnClick="btnAddCourse1_Click" />
    </form>
</body>
</html>
