<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updatestatus.aspx.cs" Inherits="Advising_System.updatestatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            update status
            <br />
            stuent id :  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="update status" />
        </div>
    </form>
</body>
</html>
