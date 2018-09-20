<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="TestTwilio.aspx.cs" Inherits="TableTap.TestNotification.TestTwilio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <!--- Please avoid testing me --->
    <p>
        Test Page for Twilio Please avoid testing unless you need too, else Twilio free account will run out of credit. This API will send a SMS message.
        Please Enter phone number in +61 format</p>
    

    <div>
        <asp:TextBox ID="txbData" runat="server" Width="316px"></asp:TextBox>
        <asp:Button ID="btnTest" runat="server" Text="Button" OnClick="Button1_Click" /></div>
</asp:Content>
