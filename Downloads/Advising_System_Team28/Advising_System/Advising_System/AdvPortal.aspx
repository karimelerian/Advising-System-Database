<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvPortal.aspx.cs" Inherits="Advising_System.AdvPortal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Advisor Portal</title>
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
        <div class="button-container">
            <h2 class="AdvPortalWelcome">Welcome to the Advisor Portal</h2>
            
            <div class="button-row">
                <asp:Button ID="BackToLoginID" runat="server" Text="Go Back" OnClick="BackToLogin_OnClick" CssClass="custom-button" />
            </div>

            <div class="button-row">
                <asp:Button ID="ViewAdvStudsID" runat="server" Text="Advising Students" OnClick="ViewAdvStuds_OnClick" CssClass="custom-button" />
                <asp:Button ID="InsertGradPlanID" runat="server" Text="Insert Graduation Plan" OnClick="InsertGradPlan_OnClick" CssClass="custom-button" />
                <asp:Button ID="InsertCoursesForGradPlanID" runat="server" Text="Insert Courses For Graduation Plan" OnClick="InsertCoursesForGradPlan_OnClick" CssClass="custom-button" />
                <asp:Button ID="UpdateExpectedGradDateForGradPlanID" runat="server" Text="Update Expected Graduation Date" OnClick="UpdateExpectedGradDateForGradPlan_OnClick" CssClass="custom-button" />
                <asp:Button ID="DeleteCoursesFromGradPlanID" runat="server" Text="Delete Courses For Graduation Plan" OnClick="DeleteCoursesFromGradPlan_OnClick" CssClass="custom-button" />
            </div>
            
            <div class="button-row">
                <asp:Button ID="ViewAssignedStudsID" runat="server" Text="View Assigned Students" OnClick="ViewAssignedStuds_OnClick" CssClass="custom-button" />
                <asp:Button ID="ViewReqsID" runat="server" Text="View Requests" OnClick="ViewReqs_OnClick" CssClass="custom-button" />
                <asp:Button ID="ViewPendingReqs" runat="server" Text="View Pending Requests" OnClick="ViewPendingReqs_OnClick" CssClass="custom-button" />
                <asp:Button ID="AppOrRejExCH_RequestID" runat="server" Text="Approve Or Reject Extra Credit Hours Request" OnClick="AppOrRejExCH_Request_OnClick" CssClass="custom-button" />
                <asp:Button ID="AppOrRejExCourses_RequestID" runat="server" Text="Approve Or Reject Extra Courses Request" OnClick="AppOrRejExCourses_Request_OnClick" CssClass="custom-button" />
            </div>
        </div>
    </form>
</body>
</html>
