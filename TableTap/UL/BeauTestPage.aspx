<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="BeauTestPage.aspx.cs" Inherits="TableTap.UL.BeauTestPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:button runat="server" id="TestButton" onclick="TestButton_Click" />
    <ul>
    <asp:TextBox runat="server" ID="txtbxUserID" />
    <asp:TextBox  runat="server" ID="txtbxEmail"/>
    <asp:TextBox  runat="server" ID="txtbxPassword"/>
    <asp:TextBox  runat="server" ID="txtbxFname"/>
    <asp:TextBox  runat="server" ID="txtbxLname"/>
    <asp:TextBox  runat="server" ID="txtbxAdminP"/>
    </ul>
</asp:Content>
