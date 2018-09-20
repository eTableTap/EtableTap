<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="TestEmail.aspx.cs" Inherits="TableTap.TestNotification.TestEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--- Email Test Page --->
    <p> Test Page for e-mail. Enter a e-mail address</p>
    
    <div>
    <asp:TextBox ID="Subject" runat="server">Subject</asp:TextBox>
    <asp:TextBox ID="Message" runat="server">Message</asp:TextBox>
    </div>
    <div>
        <asp:TextBox ID="txb" runat="server"></asp:TextBox>
        <asp:TextBox ID="txbSubject" runat="server"></asp:TextBox>
        <asp:TextBox ID="txbMessage" runat="server" Width="1014px"></asp:TextBox>
    </div>
    <asp:Label ID="Label1" runat="server" Text="Address"></asp:Label>
    <asp:TextBox ID="txbData" runat="server" Width="549px" Height="16px"></asp:TextBox>
    <asp:Button ID="btnTest" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
