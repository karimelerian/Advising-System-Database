<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="optionalcourses.aspx.cs" Inherits="Advising_System.optionalcourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label2" runat="server" Text="Current Semester Code"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
           
        </div>
        
        <div>
            
         
            <asp:Button ID="btnShowData" runat="server" Text="Show Data" OnClick="btnShowData_Click" />
        </div>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Name" />
                <asp:BoundField DataField="course_id" HeaderText="Course ID" />
                <asp:BoundField DataField="major" HeaderText="Major" />
                <asp:BoundField DataField="is_offered" HeaderText="Is_Offered" />
                <asp:BoundField DataField="credit_hours" HeaderText="Credit_Hours" />
                <asp:BoundField DataField="semester" HeaderText="Semester" />
            </Columns>
        </asp:GridView>
       
    </form>
</body>
</html>
