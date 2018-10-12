<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Directionsmodule.aspx.cs" Inherits="TableTap.DirectionsModule.Directionsmodule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:button runat="server" text="Button" OnClick="Unnamed1_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <a href="google.navigation:q=142+Nagles+Falls+Road,+Sherwood,+NSW,+Australia">Navigation to local address</a>
      <a href="google.navigation:q=San+Francisco">Navigation to San Francisco</a>  
</asp:Content>
