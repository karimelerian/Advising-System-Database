<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="issueinstallment.aspx.cs" Inherits="Advising_System.issueinstallment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Issue installment
            <br />
            payment id :
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="issue instllment" />

        </div>
    </form>
</body>
</html>
