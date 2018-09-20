<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="QRtest.aspx.cs" Inherits="TableTap.UL.QRtest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Image runat="server" ID ="QRImage" />
        <asp:TextBox runat="server" ID="TextBox1" />
        <asp:Button runat="server" ID="QRButton" OnClick="QRButton_Click" />

    </div>
</asp:Content>
