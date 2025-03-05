<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewgradplan.aspx.cs" Inherits="Advising_System.viewgradplan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2> graduation plans along with their initiated advisors</h2>
        <div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="sqldatasourse1">
               
            </asp:GridView>
            <asp:SqlDataSource ID="sqldatasourse1" runat="server" ConnectionString="<%$ ConnectionStrings:Advising_System %>"
                SelectCommand="Select Student.student_id as studentID , Student.f_name, Student.l_name, Payment.* 
                                    from Payment Inner join Student on Payment.student_id = Student.student_id "></asp:SqlDataSource>              
            </div>
    </form>
</body>
</html>
