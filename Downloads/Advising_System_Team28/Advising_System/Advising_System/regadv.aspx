<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regadv.aspx.cs" Inherits="Advising_System.regadv" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advisor Registration</title>
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
    <form id="form2" runat="server">
        <div class="header-container">
            <h2>Advisor Registration</h2>
        </div>

        <div>
            <label>Name</label>
            <asp:TextBox ID="AdvName" runat="server" CssClass="custom-input"></asp:TextBox>
            <br />
            
            <label>Office</label>
            <asp:TextBox ID="AdvOff" runat="server" CssClass="custom-input"></asp:TextBox>
            <br />
            
            <label>Email</label>
            <asp:TextBox ID="AdvEmail" runat="server" CssClass="custom-input"></asp:TextBox>
            <br />
            
            <label>Password</label>
            <asp:TextBox ID="AdvPass" runat="server" TextMode="Password" CssClass="custom-input"></asp:TextBox>
            <br />
            
            <label>ID</label>
            <asp:TextBox ID="AdvID" runat="server" CssClass="custom-input"></asp:TextBox>
            <br />
            
            <asp:Button runat="server" Text="Register" OnClick="RegOnClick" CssClass="custom-button" />
        </div>
    </form>
</body>
</html>
