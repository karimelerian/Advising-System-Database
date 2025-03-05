<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MAINPAGE_S.aspx.cs" Inherits="Advising_System.MAINPAGE_S" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Main Page - Advising System</title>
   <style>
    body {
        font-family: 'Times New Roman', Times, serif, sans-serif;
        background-color: lightpink;
        margin: 0;
        padding: 0;
        text-align: center;
    }

    form {
        max-width: 800px;
        margin: 50px auto;
        background-color: darkslategrey ;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    h1 {
        color: #3d7898;
    }

    .button-container {
        display: block;
        margin-bottom: 20px;
    }

    button {
        display: block;
        width: 100%;
        margin: 10px 0;
        padding: 10px;
        font-size: 16px;
        background-color: #cd9090 :
        color: #cd9090;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    button:hover {
        background-color: #0056b3;
    }
</style>
    <title>STUDENT</title>
</head>
<body>
    <h1> STUDENT </h1>
    <form id="form1" runat="server">
          <div style="margin-bottom: 10px;">
       <asp:Button runat="server" ID="register" Text=" student registeration " OnClick="btnreg_Click" />
   </div>
        <div>
              <asp:Button runat="server" ID="studnet_login" Text="login" OnClick="btnlogin_Click" />
        </div>
    </form>
</body>
</html>
