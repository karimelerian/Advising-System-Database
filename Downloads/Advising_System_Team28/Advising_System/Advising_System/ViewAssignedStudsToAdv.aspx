<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAssignedStudsToAdv.aspx.cs" Inherits="Advising_System.ViewAssignedStudsToAdv" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Assigned Students</title>
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
            <h2>View Assigned Students</h2>

            <asp:Label ID="LabelAdvisorId" runat="server" Text="Advisor ID:" CssClass="header-label"></asp:Label>
            <asp:TextBox ID="txtAdvisorId" runat="server" Height="16px" CssClass="custom-input"></asp:TextBox><br />

            <asp:Label ID="LabelMajor" runat="server" Text="Major:" CssClass="header-label"></asp:Label>
            <asp:TextBox ID="txtMajor" runat="server" Height="16px" CssClass="custom-input"></asp:TextBox><br />

            <asp:Button ID="btnViewStudents" runat="server" Text="View Assigned Students" OnClick="btnViewStudents_Click" CssClass="custom-button" />

            <asp:GridView ID="GridViewAssignedStudents" runat="server" AutoGenerateColumns="False" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="student_id" HeaderText="Student ID" />
                    <asp:BoundField DataField="Student_name" HeaderText="Student Name" />
                    <asp:BoundField DataField="major" HeaderText="Major" />
                    <asp:BoundField DataField="Course_name" HeaderText="Course Name" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
