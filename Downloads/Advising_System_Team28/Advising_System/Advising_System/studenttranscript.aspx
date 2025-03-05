<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studenttranscript.aspx.cs" Inherits="Advising_System.studenttranscript" %>

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
                SelectCommand=" Select Student.student_id, student.f_name,student.l_name, t.course_id,Course.name , t.exam_type,t.grade, t.semester_code
from Student inner join Student_Instructor_Course_take t on Student.student_id = t.student_id
inner join Course On Course.course_id = t.course_id"></asp:SqlDataSource>              
            </div>
    </form>
</body>
</html>
