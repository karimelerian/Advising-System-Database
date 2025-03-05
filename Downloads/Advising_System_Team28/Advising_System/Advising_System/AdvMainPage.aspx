<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvMainPage.aspx.cs" Inherits="Advising_System.AdvMainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advisor Main Page</title>
    <style>
        body {
            margin: 0;
            font-family: 'Arial', sans-serif;
            background-color: #FFF;
            color: #000;
            text-align: center;
        }

        h2 {
            color: #FFD100;
            font-family: 'Impact', sans-serif;
            font-size: 36px;
            letter-spacing: 2px;
            margin: 20px 0;
        }

        div {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 50px;
        }

        .custom-button {
            margin: 10px;
            padding: 15px 30px;
            font-size: 18px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            text-align: center;
            background-color: #000;
            color: #FFD100;
            text-decoration: none;
            transition: background-color 0.3s ease, color 0.3s ease, transform 0.2s ease;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .custom-button:hover {
            background-color: #D00;
            color: #FFF;
            transform: scale(1.05);
        }

        .button-label {
            margin: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Welcome To Advisor Main Page</h2>
            
            <asp:Label ID="LoginMainLabel" runat="server" Text="Login Page:" CssClass="button-label"></asp:Label>
            <asp:Button ID="LoginPgButton" runat="server" Text="Sign In" OnClick="LoginPgButton_Click" CssClass="custom-button" />
            
            <br />
            
            <asp:Label ID="Label2" runat="server" Text="Registration Page:" CssClass="button-label"></asp:Label> 
            <asp:Button ID="RegPgButton" runat="server" Text="Sign Up" OnClick="RegPgButton_Click" CssClass="custom-button" />
        </div>
    </form>
</body>
</html>
