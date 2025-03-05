<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_deleteslots.aspx.cs" Inherits="Advising_System.admin_deleteslots" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            current semester : 
        </div>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" OnClick="admindelete" runat="server" Text="delete slot" />
        </p>
    </form>
</body>
</html>
