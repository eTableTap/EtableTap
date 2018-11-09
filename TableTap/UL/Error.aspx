<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="404Page.aspx.cs" Inherits="TableTap._404Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



        <div class="container-fluid">
        <div class="jumbotron">
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="Label3" runat="server" Text="Uh Oh!!! Something has gone wrong. But! I drew you a flower!" Font-Bold="True" Font-Size="Large"
              CssClass="StrongText"></asp:Label>
            </div>
                   <asp:Image ID="imgLogin" runat="server" imageurl="~/Resources/Images/SorryFlower.png" CssClass="HomeImages" Width="50%" Height="50%" />
                </div>
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="Label1" runat="server" Text="Now that you’ve forgiven us; Use this button to get back on track" Font-Bold="True" Font-Size="Large"
              CssClass="StrongText"></asp:Label>
            </div>
            <div>
                <asp:Button type="button" Text="Go back to home" class="btn btn-primary btn-lg btn-block login-button" id="goToHomeButton" runat="server" />
            </div>
            
            </div>


</asp:Content>
