<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="activestudents.aspx.cs" Inherits="Advising_System.activestudents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <h2>details for all active students</h2>
        <div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="sqldatasourse1">
                
            </asp:GridView>
            <asp:SqlDataSource ID="sqldatasourse1" runat="server" ConnectionString="<%$ ConnectionStrings:Advising_System %>"
                SelectCommand="Select * from Student where financial_status = 1 "></asp:SqlDataSource>              
            </div>
    </form>
</body>
</html>
