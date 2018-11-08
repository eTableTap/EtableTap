<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="TableTap.UL.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


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

            <div class="form-group">
                <div class="input-group mb-3">
                  <div class="input-group-prepend">
                    <asp:label class="input-group-text" for="inputGroupSelect01" runat="server" Text="Options" ID="sideLbl"></asp:label>
                  </div>
                  <select runat="server" class="custom-select" id="inputBuildingSelecter">
                  
                  </select>
                </div>
            </div>
            <div class="form-group ">
					<asp:Button type="button" Text="Go to buidling" class="btn btn-primary btn-lg btn-block login-button" id="goToBuildingButton" onclick="goToBuildingButton_Click" runat="server" />
			</div>

        </div>
    </div>

</asp:Content>
