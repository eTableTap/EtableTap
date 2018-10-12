<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Building.aspx.cs" Inherits="TableTap.UL.Building" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron">
            
            <asp:Label ID="lblHeading" runat="server" Text="Room list" CssClass="h1"></asp:Label>

            <div class="form-group">
                    <asp:Label runat="server" ID="lblAboveDropdown" class="cols-sm-2 control-label" text="Select Room:"></asp:Label>
					<div class="cols-sm-10">
						<div class="input-group">
							<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
							<asp:DropDownList runat="server" ID="roomDropdown" ></asp:DropDownList>
						</div>
					</div>
			</div>

            <div class="form-group ">
					<asp:Button type="button" Text="Go to room" class="btn btn-primary btn-lg btn-block login-button" id="goToRoomingButton" onclick="goToRoomButton_Click" runat="server" />
			</div>

        </div>
    </div>
</asp:Content>
