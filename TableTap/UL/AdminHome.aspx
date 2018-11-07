<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="TableTap.UL.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron" style="text-align: center">
            <div class="row main">
				
				<div class="main-login main-center">
					<form class="form-horizontal" method="post" action="#"  >
                        <div class="panel-heading">
	                        <div class="panel-title text-center">
	               		    <h1 class="title">Admin Control</h1>
	               		    <hr />
	               	        </div>
	                    </div> 
						
						

						<div class="form-group " style="text-align: center" >
							<asp:Button type="button" Text="Edit Buildings" class="btn btn-primary btn-lg btn-block login-button" OnClick="EditBuildingButton_Click" id="buildingButton" runat="server" />
                            <asp:Button type="button" Text="Add Buildings" class="btn btn-primary btn-lg btn-block login-button" id="AddBuildingButton" runat="server" OnClick="AddBuildingButton_Click" />
                            <asp:Button type="button" Text="Edit Rooms" class="btn btn-primary btn-lg btn-block login-button" id="roomButton" runat="server" OnClick="roomButton_Click" />
                            <asp:Button type="button" Text="Add Room" class="btn btn-primary btn-lg btn-block login-button" id="btnaddRoom" runat="server" OnClick="btnaddRoom_Click"/>
                            <asp:Button type="button" Text="Edit Tables" class="btn btn-primary btn-lg btn-block login-button" id="tableButton" runat="server" OnClick="tableButton_Click" />
                            <asp:Button type="button" Text="Edit Tables" class="btn btn-primary btn-lg btn-block login-button" id="AddTableButton" runat="server" OnClick="AddTableButton_Click"/>
                            <asp:Button type="button" Text="Edit User" class="btn btn-primary btn-lg btn-block login-button" id="userButton" runat="server" OnClick="userButton_Click"/>
                            <asp:Button type="button" Text="Add User" class="btn btn-primary btn-lg btn-block login-button" id="addUserButton" runat="server" OnClick="addUserButton_Click" />
                            <asp:Button type="button" Text="Scheduled Tasks Start up" class="btn btn-primary btn-lg btn-block login-button" id="scheduledButton" runat="server" OnClick="scheduledButton_Click" />
                            <asp:Button type="button" Text="Add Notification" class="btn btn-primary btn-lg btn-block login-button" id="AddNotificationButton" runat="server" OnClick="AddNotificationButton_Click" />
                            <asp:Button type="button" Text="Manage Notifications" class="btn btn-primary btn-lg btn-block login-button" id="ManageNotificationsButton" runat="server" OnClick="ManageNotificationsButton_Click" />
                            <asp:Button type="button" Text="Print QR Codes" class="btn btn-primary btn-lg btn-block login-button" id="qrButton" runat="server" OnClick="printQRButton_Click"  />
						</div>
						
					</form>
				</div>
			</div>


        </div>
    </div>
</asp:Content>
