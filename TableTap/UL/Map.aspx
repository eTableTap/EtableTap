<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="TableTap.UL.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Facilitates the selection of a building for the map service viewing
     -->
<script src="/Seats.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron">
            <div class="row">
                <div class="mx-auto">
                      <asp:Label ID="lblHeading" runat="server" Text="Select Building:" CssClass="h1"></asp:Label>
                </div>
            </div>
            <br />

            <!-- User selects a building -->
            <div class="form-group">
                <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <asp:label class="input-group-text" for="inputGroupSelect01" runat="server" Text="Options" ID="sideLbl"></asp:label>
                  </div>
                  <select runat="server" class="custom-select" id="inputBuildingSelecter">                  
                  </select>
                </div>
            </div>

            <!-- User confirms selection & requests redirect to map module -->
            <div class="form-group ">
					<asp:Button type="button" Text="Go to buidling" class="btn btn-primary btn-lg btn-block login-button" id="goToBuildingButton" onclick="goToBuildingButton_Click" runat="server" />
			</div>
        </div>
    </div>
</asp:Content>
