<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addtelephone.aspx.cs" Inherits="Advising_System.addtelephone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             
            <asp:Label ID="phonenum" runat="server" Text="phone number"></asp:Label>
            <asp:TextBox ID="num" runat="server"></asp:TextBox>
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />

        </div>
    </form>
</body>
</html>
