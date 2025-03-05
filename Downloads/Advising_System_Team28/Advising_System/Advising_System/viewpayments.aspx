 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewpayments.aspx.cs" Inherits="Advising_System.viewpayments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <h2>details for all payments along with their corresponding students</h2>
        <div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="sqldatasourse1">
                
            </asp:GridView>
            <asp:SqlDataSource ID="sqldatasourse1" runat="server" ConnectionString="<%$ ConnectionStrings:Advising_System %>"
                SelectCommand="Select Graduation_Plan.*, Advisor.advisor_id as AdvisorID, Advisor.advisor_name
                               from Graduation_Plan inner join Advisor on Graduation_Plan.advisor_id = Advisor.advisor_id "></asp:SqlDataSource>              
            </div>
    </form>
</body>
</html>
