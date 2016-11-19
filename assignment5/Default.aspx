<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="assignment5.Default" %>

<%@ Register Src="~/signIn.ascx" TagPrefix="uc1" TagName="signIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:signin runat="server" id="signIn" />    
    <asp:Label ID="lor" runat="server" Text="Waiting for event to happen." style="margin-right:10px;"></asp:Label>
</asp:Content>
