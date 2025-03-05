<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveRejectCHRequest.aspx.cs" Inherits="Advising_System.ApproveRejectCHRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Approve/Reject Request</title>
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
        <div class="header-container">
            <h2>Approve/Reject Request</h2>
        </div>

        <div>
     
            <label class="custom-label">Request Details:</label>
            <asp:Label ID="lblRequestDetails" runat="server" CssClass="custom-label" Text=""></asp:Label>

            <div class="button-container">
                <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" CssClass="custom-button" />
                <asp:Button ID="btnReject" runat="server" Text="Reject" OnClick="btnReject_Click" CssClass="custom-button" />
                <label for="current_semester_code">Current Semester Code:</label>
                  <input type="text" id="current_semester_code" name="current_semester_code" 
            </div>
        </div>
    </form>
</body>
</html>
