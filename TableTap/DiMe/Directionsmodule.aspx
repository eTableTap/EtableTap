<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Directionsmodule.aspx.cs" Inherits="TableTap.DirectionsModule.Directionsmodule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:button runat="server" text="Button" OnClick="Unnamed1_Click" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <a href="google.navigation:q=142+Nagles+Falls+Road,+Sherwood,+NSW,+Australia">Navigation to local address</a>


     <a href="intent://www.google.com.au/maps/dir//Blue+Gum+Rd+%26+Mordue+Parade,+Jesmond+NSW+2299#Intent;scheme=http;package=com.google.android.apps.maps;S.browser_fallback_url=https://www.google.com.au/maps/dir//Mordue+Parade+%26+Blue+Gum+Road,+Jesmond+NSW+2299end"> Please work </a>
</asp:Content>
