<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="assignment5.Protected.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Staff user list:"></asp:Label>
        <br />
        <asp:TextBox ID="txtStaffs" runat="server" Height="146px" ReadOnly="True" TextMode="MultiLine" Width="116px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddStaff" runat="server" OnClick="btnAddStaff_Click" Text="Add New Staff" />
        <asp:Label ID="Label2" runat="server" Text="(For admin use only)"></asp:Label>
    
    </div>
    </form>
</body>
</html>
