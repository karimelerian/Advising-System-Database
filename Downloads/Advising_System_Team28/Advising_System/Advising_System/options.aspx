<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="options.aspx.cs" Inherits="Advising_System.options" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Advising System</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            text-align: center;
        }

        form {
            max-width: 1000px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        button {
            display: block;
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            font-size: 16px;
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> options for student
            </h1>
            <asp:Button ID="addtel" runat="server" Text="Add Telephone Number" OnClick="addtel_Click" />
            <asp:Button ID="optcourse" runat="server" Text="optional courses" OnClick="optcourse_Click" />
            <asp:Button ID="avcourse" runat="server" Text="available courses" OnClick="avcourse_Click" />
            <asp:Button ID="reqcourse" runat="server" Text="required courses" OnClick="reqcourse_Click" />
            <asp:Button ID="misscourse" runat="server" Text="missing courses" OnClick="misscourse_Click" />
            <asp:Button ID="sendcoursereq" runat="server" Text="course request" OnClick="sendcoursereq_Click" />
            <asp:Button ID="sendcreditreq" runat="server" Text="credit hour request" OnClick="sendcreditreq_Click" />
            <asp:Button ID="coursedeets" runat="server" Text="View all details of all courses with their prerequisites" OnClick="coursedeets_Click" />
            <asp:Button ID="allcoursescorresponding" runat="server" Text="View all courses along with their corresponding slots details and instructors" OnClick="allcoursescorresponding_Click" />
            <asp:Button ID="certain" runat="server" Text="View the slots of a certain course that is taught by a certain instructor" OnClick="certain_Click" />
            <asp:Button ID="courseexam" runat="server" Text="View all courses along with their exams details" OnClick="courseexam_Click" />
            <asp:Button ID="courseandinstruc" runat="server" Text="Choose instructor for a certain course" OnClick="courseandinstruc_Click" />
            <asp:Button ID="frstmakeup" runat="server" Text="Register for first makeup exam" OnClick="frstmakeup_Click" />
            <asp:Button ID="scndmakeup" runat="server" Text="Register for second makeup exam" OnClick="scndmakeup_Click" />
            <asp:Button ID="gradplan" runat="server" Text="View graduation plan  with assigned courses" OnClick="gradplan_Click" />
            <asp:Button ID="install" runat="server" Text="View upcoming not paid installment" OnClick="install_Click" />
        </div>
    </form>
</body>
</html>
