<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="IncidentModule.aspx.cs" Inherits="TableTap.IncidentModule.IncidentModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Test Add data" OnClick="Button1_Click" />
<asp:Label ID="lbltime" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lbluser" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lblText" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lblTable" runat="server" Text="Label"></asp:Label>
</asp:Content>
