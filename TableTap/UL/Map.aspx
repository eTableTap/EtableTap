<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="TableTap.UL.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script src="/Seats.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Detter er map side

    
    
    <div class="container-fluid">
        <div class="jumbotron">
            <h2>Select Building:</h2>

            <div class="form-group">
					<label for="name" class="cols-sm-2 control-label">Select Building:</label>
					<div class="cols-sm-10">
						<div class="input-group">
							<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
							<asp:DropDownList runat="server" ID="buildingDropdown" ></asp:DropDownList>
						</div>
					</div>
			</div>

            <div class="form-group ">
					<asp:Button type="button" Text="Go to buidling" class="btn btn-primary btn-lg btn-block login-button" id="goToBuildingButton" onclick="goToBuildingButton_Click" runat="server" />
			</div>

        </div>
    </div>

</asp:Content>
