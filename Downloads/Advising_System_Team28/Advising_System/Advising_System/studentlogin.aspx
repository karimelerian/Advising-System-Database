<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentlogin.aspx.cs" Inherits="Advising_System.studentlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Login" style="font-size: 20px; text-align: center;"></asp:Label>
             </br>
            <asp:Label runat="server" Text="ID"></asp:Label>
            <asp:TextBox runat="server" ID="txtID" ></asp:TextBox>
            </br>
             <asp:Label runat="server" Text="Password"></asp:Label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
            </br>
            <asp:Button ID="studlogin" runat="server" OnClick="login_Click" Text="Login" />

        </div>
    </form>
</body>
</html>
