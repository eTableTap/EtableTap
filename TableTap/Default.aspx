<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TableTap.UL.TesterHeaderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="test1" runat="server" Text="Hayden Testing Page" OnClick="test1_Click" />
    <asp:Button ID="test2" runat="server" Text="Beau test page" OnClick="test2_Click" />
    <asp:Button ID="test3" runat="server" Text="admin home page" OnClick="test3_Click" />
    <asp:Button ID="test4" runat="server" Text="testQR" OnClick="test4_Click" />
    <asp:Button ID="test5" runat="server" Text="Registration page" OnClick="test5_Click" />
    <asp:Button ID="Button1" runat="server" Text="Directions Module" OnClick="Button1_Click" />
    <asp:Button ID="btntestnotify" runat="server" OnClick="btntestnotify_Click" Text="Test notify" />
    <div>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Test background worker" Width="77px" />
    </div>
    </asp:Content>



