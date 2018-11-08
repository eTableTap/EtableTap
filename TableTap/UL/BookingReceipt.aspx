<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="BookingReceipt.aspx.cs" Inherits="TableTap.UL.BookingReceipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <th class="auto-style2">Booking User: </th>
                            <td class="auto-style1"><asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>

                        </tr>

                    <tr>
                            <th class="auto-style2">Day: </th>
                        <td class="auto-style1"><asp:Label ID="lblDay" runat="server" Text="Label"></asp:Label></td>
                    </tr>

                    <tr>
                        
                            <th class="auto-style2">Hour (24H): </th>
                        <td class="auto-style1"><asp:Label ID="lblHour" runat="server" Text="Label"></asp:Label></td>
                    </tr>

                    <tr>
                        
                            <th class="auto-style2">Table ID: </th>
                        <td class="auto-style1"><asp:Label ID="lblTable" runat="server" Text="Label"></asp:Label></td>
                    </tr>

                    <tr>
                        
                            <th class="auto-style2">Room Name: </th>
                        <td class="auto-style1"><asp:Label ID="lblRoom" runat="server" Text="Label"></asp:Label></td>
                    </tr>

                    <tr>
                        
                            <th class="auto-style2">Building Name: </th>
                        <td class="auto-style1"><asp:Label ID="lblBuilding" runat="server" Text="Label"></asp:Label></td>
                    </tr>

                    <tr>
                        
                            <th class="auto-style2">Building Address: </th>
                        <td><asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></td>
                    </tr>

                    </table>
                <br />

            <div>
                
                <asp:Button type="button" Text="Open Directions" class="btn btn-primary btn-lg btn-block login-button" id="Directions" runat="server" OnClick="Directions_Click" />
            </div>
                <br />
            <div>
                <asp:Button type="button" Text="Go back to home" class="btn btn-primary btn-lg btn-block login-button" id="goToHomeButton" runat="server" OnClick="goToHomeButton_Click" />
            </div>
            
            </div>
            </div>
            </div>


        <asp:Label ID="lblbuildingid" runat="server" Text="Label" Visible="False"></asp:Label>


</asp:Content>
