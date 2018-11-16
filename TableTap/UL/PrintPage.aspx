<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true"  CodeBehind="PrintPage.aspx.cs" Inherits="TableTap.UL.PrintPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Facilitiates the viewing of the QR code for user scanning
     -->

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="jumbotron">
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
                <div class="panel-heading">
	                <div class="panel-title text-center">
	               		<h1 class="title">Scan me!</h1>
	               		<br />
	               	</div>
	            </div> 
                <!-- Displays the QR code -->
                <table style="width:100%">
                    <tr>
                        <th class="auto-style2"><asp:Image ID="Image1" runat="server" ImageUrl="null"/></th>
                   </tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="lblInfo" runat="server" Text="Scan to book table or enter:"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"><asp:Label ID="lblURL" runat="server" Text=""></asp:Label></td>
                    </tr>                                   
                 </table>   
            </div>
        </div>        
</asp:Content>
