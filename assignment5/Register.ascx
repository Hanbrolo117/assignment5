<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="assignment5.Register" %>

    <h3>Login</h3>
    <hr />

    <asp:Label ID="username_label" runat="server" Text="Login:" style="margin-right:10px;"></asp:Label>
    <asp:TextBox ID="username_input" runat="server" style="margin-top:15px;"></asp:TextBox>
    <br />

    <asp:Label ID="password_label" runat="server" Text="Password:" style="margin-right:10px;"></asp:Label>
    <asp:TextBox ID="password_input" TextMode="Password" runat="server" style="margin-top:15px;" ></asp:TextBox>
    <br />

    <asp:Label ID="password_confirm_label" runat="server" Text="Confirm Password:" style="margin-right:10px;"></asp:Label>
    <asp:TextBox ID="password_confirm_input" TextMode="Password" runat="server" style="margin-top:15px;" ></asp:TextBox>
    <br />

    <asp:Button ID="login_event" runat="server" Text="Login" style="margin-bottom:10px; margin-top:20px; padding-right:50px;" OnClick="login_event_Click"/>
    <span style="padding-left:20px;"></span> 
    <asp:Button ID="register_event" runat="server" Text="Register" style="margin-bottom:10px; margin-top:20px; padding-right:50px;" OnClick="register_event_Click" /> 