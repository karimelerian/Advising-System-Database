<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendreq.aspx.cs" Inherits="Advising_System.sendreq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="course ID"></asp:Label>
            <asp:TextBox ID="courseIDtxt" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="type"></asp:Label>
            <asp:TextBox ID="typetxt" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="comment"></asp:Label>
            <asp:TextBox ID="commenttxt" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
