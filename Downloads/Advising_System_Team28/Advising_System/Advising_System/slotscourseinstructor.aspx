<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="slotscourseinstructor.aspx.cs" Inherits="Advising_system.slotscourseinstructor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Course Slots Instructor View</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="CourseID" HeaderText="Course ID" SortExpression="CourseID" />
                    <asp:BoundField DataField="Course" HeaderText="Course" SortExpression="Course" />
                    <asp:BoundField DataField="slot_id" HeaderText="Slot ID" SortExpression="SlotID" />
                    <asp:BoundField DataField="day" HeaderText="Day" SortExpression="Day" />
                    <asp:BoundField DataField="time" HeaderText="Time" SortExpression="Time" />
                    <asp:BoundField DataField="location" HeaderText="Location" SortExpression="Location" />
                    <asp:BoundField DataField="Instructor" HeaderText="Instructor" SortExpression="Instructor" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>