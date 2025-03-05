<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="creditreq.aspx.cs" Inherits="Advising_System.creditreq" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label1" runat="server" Text="Credit hours"></asp:Label>
            <asp:TextBox ID="credittxt" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="type"></asp:Label>
            <asp:TextBox ID="typetxt" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="comment"></asp:Label>
            <asp:TextBox ID="commenttxt" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
