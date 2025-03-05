<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MAINCHOOSE.aspx.cs" Inherits="Advising_System.MAINCHOOSE" %>

<!DOCTYPE html>
<html lang="en">
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
            max-width: 400px;
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
        <h2>Choose Your Role</h2>
        <button runat="server" id="student" onserverclick="student_Click">Student</button>
        <button runat="server" id="admin" onserverclick="admin_Click">Admin</button>
        <button runat="server" id="advisor" onserverclick="advisor_Click">Advisor</button>
    </form>
</body>
</html>
