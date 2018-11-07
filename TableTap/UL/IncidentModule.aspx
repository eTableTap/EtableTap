<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="IncidentModule.aspx.cs" Inherits="TableTap.IncidentModule.IncidentModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Test Add data" OnClick="Button1_Click" />
<asp:Label ID="lbltime" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lbluser" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lblText" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lblTable" runat="server" Text="Label"></asp:Label>

    <div></div>
        <asp:Button ID="Button2" runat="server" Text="Test User Delete data" OnClick="Button2_Click"/>
        <div></div>
        <asp:Button ID="Button3" runat="server" Text="Test table Delete data" OnClick="Button3_Click"/>
        <div></div>
        <asp:Button ID="Button4" runat="server" Text="Test room Delete data" OnClick="Button4_Click"/>
        <div></div>
        <asp:Button ID="Button5" runat="server" Text="Test building Delete data" OnClick="Button5_Click"/>
    <div></div>
    <div></div>

    <asp:Button ID="Button6" runat="server" Text="Button" />


    <div></div>

</asp:Content>
