<%@ Page Title="Home" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TableTap.UL.Home"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Serves as the landing page for all standard users, and facilitate functionality such as Scan a QR code (makke a booking) , login and view map 
     -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron">
        <div class="row">
            <!-- Permits user login -->
            <div class="col-sm-6" runat ="server" id="loginArea">
                    <asp:hyperlink ID="hlLogin" runat="server" href="Login.aspx">
                            <asp:Image ID="imgLogin" runat="server" imageurl="~/Resources/Images/LoginBtn.png" CssClass="HomeImages"/>
                    </asp:hyperlink>
            </div>

            <!-- Permits user map access -->
            <div class="col-sm-6">
                <asp:hyperlink ID="hlMap" runat="server" href="Map.aspx">
                    <asp:Image ID="imgMap" runat="server" imageurl="~/Resources/Images/MapBtn.png" CssClass="HomeImages"/>
                </asp:hyperlink>
            </div>
        </div> 
        
        <!-- Scan QR code to commence a booking -->
        <div class="row">
            <div class="col-sm-6">
                 <asp:hyperlink ID="hlScan" runat="server" href="Scan.aspx">
                         <!--<asp:Image ID="imgScan" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>-->
                 </asp:hyperlink>
            </div>

            <!-- Access the user account -->
            <div class="col-sm-6">
                 <asp:hyperlink ID="hlAccount" runat="server" href="Account.aspx">
                         <!--<asp:Image ID="imgAccount" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>-->
                 </asp:hyperlink>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-4" style="background-color:orangered">
                <!--<asp:Image ID="Image1" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>-->
            </div>
            <div class="col-sm-4" style="background-color:orange">
                <!--<asp:Image ID="Image2" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>-->
            </div>
            <div class="col-sm-4" style="background-color:darkorange">
                <!--<asp:Image ID="Image3" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>-->
            </div>
        </div>
    </div>
  </div>
</asp:Content>
