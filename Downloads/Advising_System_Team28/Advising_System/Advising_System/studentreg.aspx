<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentreg.aspx.cs" Inherits="Advising_System.studentreg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" Text="Student Registration" style="font-size: 20px; text-align: center;"></asp:Label>


             </br>
            <asp:Label runat="server" Text="First Name"></asp:Label>
            <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
            </br>
            <asp:Label runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
            </br>
            <asp:Label runat="server" Text="Password"></asp:Label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
            </br>
            <asp:Label runat="server" Text="Faculty"></asp:Label>
            <asp:TextBox runat="server" ID="txtFaculty"></asp:TextBox>
            </br>
            <asp:Label runat="server" Text="Email"></asp:Label>
            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
            </br>
            <asp:Label runat="server" Text="Major"></asp:Label>
            <asp:TextBox runat="server" ID="txtMajor"></asp:TextBox>
            </br>
            <asp:Label runat="server" Text="Semester"></asp:Label>
            <asp:TextBox runat="server" ID="txtSemester"></asp:TextBox>
<asp:Button ID="Register" runat="server" OnClick="Register_Click" Text="Register" />
          
            
        </div>
    </form>
</body>
</html>
