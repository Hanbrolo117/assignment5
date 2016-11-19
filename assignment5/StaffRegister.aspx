<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffRegister.aspx.cs" Inherits="assignment5.StaffRegister" %>
<%@ Register TagPrefix="uc" TagName="Register" Src="Register.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:Register id="reg" 
        runat="server" 
        MinValue="1" 
        MaxValue="10" />
    </div>
    </form>
</body>
</html>
