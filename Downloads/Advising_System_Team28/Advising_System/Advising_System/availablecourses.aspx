<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="availablecourses.aspx.cs" Inherits="Advising_System.availablecourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="semster code"></asp:Label>
            <asp:TextBox ID="smstrcodetxt" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="View all available coursesl" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
