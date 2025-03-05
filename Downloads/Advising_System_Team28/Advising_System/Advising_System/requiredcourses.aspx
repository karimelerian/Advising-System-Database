<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requiredcourses.aspx.cs" Inherits="Advising_System.requiredcourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label2" runat="server" Text="current semester code"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="View optional all courses" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
