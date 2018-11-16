<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminAddRoom.aspx.cs" Inherits="TableTap.UL.AdminAddRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Permits an administrator user to add a new room to a building in the database, including information such as room name and table number. 
          This data can be used in many other booking related instances in the project.
    -->

    <div class="container-fluid">
        <div class="jumbotron">
            <div class="row main">
				
				<div class="main-login main-center">
					<form class="form-horizontal" method="post" action="#">
                        <div class="panel-heading">
	                        <div class="panel-title text-center">
	               		    <h1 class="title">Add Room</h1>
	               		    <hr />
	               	        </div>
	                    </div> 
						
                        <!-- Selects a building from those already stored in the database -->
                        <div class="form-group">
					            <label for="name" class="cols-sm-2 control-label">Select Building:</label>
					            <div class="cols-sm-10">
						            <div class="input-group">
							            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            
                                        <!-- Pulls current building items from the database -->
							            <asp:DropDownList runat="server" ID="buildingDropdown" onselectedindexchanged="ddlbuildingDropDown_SelectedIndexChanged" AutoPostback="True" ></asp:DropDownList>
                                
						            </div>
					            </div>
			            </div>

                        <!-- User inputs a room name-->
						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Room Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inRoomName"  placeholder="Enter the building's name" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- User inputs a room label, later used for room identification -->
                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Room Label</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inRoomLabel"  placeholder="Enter the building's label" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- User inputs the maximum number of tables -->
                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Max Number of Tables</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="number" class="form-control" name="name" id="inTableQty"  placeholder="Enter number of rooms" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- User submits this information for processing into the database -->
						<div class="form-group ">
							<asp:Button type="button" Text="Add Room" class="btn btn-primary btn-lg btn-block login-button" id="addRoom" OnClick="addRoomButton_Click" runat="server" />
						</div>						
					</form>
				</div>
			</div>
        </div>
    </div>
</asp:Content>
