<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adminlogin.aspx.cs" Inherits="Advising_System.Advising_System" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>Advising System</title>
    <script type="text/javascript">
        function closeLogin() {
            window.close();
        }
    </script>
</head>

    <title>Advising System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            <label for="txtUserID">User ID:</label>
            <asp:TextBox runat="server" ID="UserID" />
            <br />
            <label for="txtPassword">Password:</label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password" />
            <br />
            <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
