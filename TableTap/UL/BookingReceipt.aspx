<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="BookingReceipt.aspx.cs" Inherits="TableTap.UL.BookingReceipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Generates a 'reciept', that is a collection of relevant information regarding a recently processed booking
     -->

    <style type="text/css">
        .auto-style1 {
            width: 943px;
        }
        .auto-style2 {
            width: 515px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="jumbotron">
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
                <div class="panel-heading">
	                   <div class="panel-title text-center">
	               		    <h1 class="title">Your Booking</h1>
	               		    <br />
	               	  </div>
	            </div> 

                <table style="width:100%">
                    <tr>
                        <!-- Outputs information about the active booking user -->
                        <th class="auto-style2">Booking User: </th>
                        <td class="auto-style1"><asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <!-- Outputs information about the booking day -->
                        <th class="auto-style2">Day: </th>
                        <td class="auto-style1"><asp:Label ID="lblDay" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <!-- Outputs information about the booking hour -->
                        <th class="auto-style2">Hour (24H): </th>
                        <td class="auto-style1"><asp:Label ID="lblHour" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <!-- Outputs information about the booking table ID -->
                        <th class="auto-style2">Table ID: </th>
                        <td class="auto-style1"><asp:Label ID="lblTable" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <!-- Outputs information about the booking name -->
                        <th class="auto-style2">Room Name: </th>
                        <td class="auto-style1"><asp:Label ID="lblRoom" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <!-- Outputs information about the booking's building name -->
                         <th class="auto-style2">Building Name: </th>
                        <td class="auto-style1"><asp:Label ID="lblBuilding" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <!-- Outputs information about the booking building's address -->
                        <th class="auto-style2">Building Address: </th>
                        <td><asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                </table>
                <br />
            <div>     
                <!-- Opens the navigation module, which will offer directions to the booking's location -->
                <asp:Button type="button" Text="Open Directions" class="btn btn-primary btn-lg btn-block login-button" id="Directions" runat="server" OnClick="Directions_Click" />
            </div>
                <br />
            <div>
                <!-- Redirects to the homepage -->
                <asp:Button type="button" Text="Go back to home" class="btn btn-primary btn-lg btn-block login-button" id="goToHomeButton" runat="server" OnClick="goToHomeButton_Click" />
            </div>
            
            </div>
        </div>
    </div>

    <asp:Label ID="lblbuildingid" runat="server" Text="Label" Visible="False"></asp:Label>

</asp:Content>
