<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Building.aspx.cs" Inherits="TableTap.UL.Building" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Serves as an initial page for booking, permits a user to select a building as part of the booking process
     -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron">
            <div class="row">
                <div class="mx-auto">
                     <asp:Label ID="lblHeading" runat="server" Text="Room list" CssClass="h1"></asp:Label>
                </div>
            </div>
            <br />     
            <!-- User selects the building required for booking -->
            <div class="form-group">
                <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <asp:label class="input-group-text" for="inputGroupSelect01" runat="server" Text="Select Room:" ID="sideLbl"></asp:label>
                  </div>
                  <select runat="server" class="custom-select" id="inputRoomSelecter">                  
                  </select>
                </div>
            </div>
            <!-- User confirms the building required for booking, and the moves to the next stage of booking -->
            <div class="form-group ">
				<asp:Button type="button" Text="Go to room" class="btn btn-primary btn-lg btn-block login-button" id="goToRoomingButton" onclick="goToRoomButton_Click" runat="server" />
			</div>
        </div>
    </div>
</asp:Content>
