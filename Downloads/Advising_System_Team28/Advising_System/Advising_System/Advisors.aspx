<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisors.aspx.cs" Inherits="Advising_System.Advisors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Admin List Advisors</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Admin List Advisors</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"></asp:GridView>
                 <asp:Button runat="server" ID="Button1" Text="main page" OnClick="btnAddCourse1_Click" />

    </form>

</body>
</html>
