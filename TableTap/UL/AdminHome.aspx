<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="TableTap.UL.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Permits an administrator user to add a edit an existing table in the database, and permits searching of existing entries. 
        This data can be used in many other administrator related interactions in the project.
     -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron" style="text-align: center">
				<div class="main-login main-center">
					<form class="form-horizontal" method="post" action="#"  >
                        <div class="panel-heading">
	                        <div class="panel-title text-center">
	               		    <h1 class="title" >Admin Control</h1>
	               		    <br />
	               	        </div>
	                    </div> 				

                    <!-- Permits User to add a building to the database -->
                    <div class="row">
                        <div class="col mx-auto">
                            <asp:Button type="button" Text="Add Buildings" class="btn btn-primary btn-lg btn-block login-button" id="AddBuildingButton" runat="server" OnClick="AddBuildingButton_Click" />
                            <br />
                            </div>
                            
                        <!-- Placed for later extensibility, permits User to edit a building to the database -->
                            <div class="col mx-auto">
                                <asp:Button type="button" Text="Print QR Codes" class="btn btn-primary btn-lg btn-block login-button" id="qrButton" runat="server" OnClick="printQRButton_Click"  />
                            <!--<asp:Button type="button" Text="Edit Buildings" class="btn btn-primary btn-lg btn-block login-button" OnClick="EditBuildingButton_Click" id="buildingButton" runat="server" />-->
                                <br />
                            </div>  
                    </div>

                    <!-- Permits User to add a room to the database -->
					<div class="row">
                        <div class="col mx-auto">
                            <asp:Button type="button" Text="Add Room" class="btn btn-primary btn-lg btn-block login-button" id="btnaddRoom" runat="server" OnClick="btnaddRoom_Click"/>
                            <br />
                        </div>

                        <!-- Placed for later extensibility, permits User to edit a room to the database -->
                        <div class="col mx-auto">
                            <!--<asp:Button type="button" Text="Edit Rooms" class="btn btn-primary btn-lg btn-block login-button" id="roomButton" runat="server" OnClick="roomButton_Click" />-->
                            <br />
                        </div>  
                    </div>

                    <!-- Permits User to add a table to the database -->
                    <div class="row">
                        <div class="col mx-auto">
                            <asp:Button type="button" Text="Add Tables" class="btn btn-primary btn-lg btn-block login-button" id="AddTableButton" runat="server" OnClick="AddTableButton_Click"/>
                            <br />
                        </div>

                        <!-- Placed for later extensibility, permits User to edit a table to the database -->
                        <div class="col mx-auto">
                            <asp:Button type="button" Text="Edit Tables" class="btn btn-primary btn-lg btn-block login-button" id="tableButton" runat="server" OnClick="tableButton_Click" />
                            <br />
                        </div>  
                    </div>

                    <!-- Permits User to add a user to the database -->
                    <div class="row">
                        <div class="col mx-auto">
                            <asp:Button type="button" Text="Add User" class="btn btn-primary btn-lg btn-block login-button" id="addUserButton" runat="server" OnClick="addUserButton_Click" />
                            <br />
                        </div>

                        <!-- Placed for later extensibility, permits User to edit a user to the database -->
                        <div class="col mx-auto">
                            <asp:Button type="button" Text="Edit User" class="btn btn-primary btn-lg btn-block login-button" id="userButton" runat="server" OnClick="userButton_Click"/>
                            <br />
                        </div>  
                    </div>

                    <!-- Placed for later extensibility, permits an administator to add events associated with objects in the system, for example book a table-->
                    <div class="row">
                        <div class="col mx-auto">
                            <asp:Button type="button" Text="Manage Incidents" class="btn btn-primary btn-lg btn-block login-button" id="incButton" runat="server" OnClick="incidentButton_Click"  />
                            <!--<asp:Button type="button" Text="Add Notification" class="btn btn-primary btn-lg btn-block login-button" id="AddNotificationButton" runat="server" OnClick="AddNotificationButton_Click" />-->
                            <br />
                        </div>

                        <!-- Permits User to view scheduled tasks pulled from the database -->
                        <div class="col mx-auto">
                            <asp:Button type="button" Text="Scheduled Tasks Start up" class="btn btn-primary btn-lg btn-block login-button" id="scheduledButton" runat="server" OnClick="scheduledButton_Click" />
                            <br />
                        </div>  
                    </div>
     
                    <!-- Placed for later extensibility, permits an administator to manage events associated with objects in the system, for example book a table-->
                    <div class="row">
                        <div class="col mx-auto">
                            <!--<asp:Button type="button" Text="Manage Notifications" class="btn btn-primary btn-lg btn-block login-button" id="ManageNotificationsButton" runat="server" OnClick="ManageNotificationsButton_Click" />-->
                            <br />
                        </div>
                        <div class="col mx-auto">                                
                            <br />
                        </div>  
                    </div>
                    <div class="row">
                        <div class="col mx-auto">                                
                            <br />
                        </div>
                        <div class="col mx-auto">                                
                        </div>  
                    </div>
					<div class="form-group " style="text-align: center"  >
					</div>						
				</form>
			</div>
		</div>        
    </div>
</asp:Content>
