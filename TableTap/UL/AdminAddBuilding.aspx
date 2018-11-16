<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminAddBuilding.aspx.cs" Inherits="TableTap.UL.AdminAddBuilding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- INFT 3970 - IT Major Project - Implementation
         Hayden Bartlett – C3185636
         Beau Maund – C3163068

         Source File Purpose:
         - Permits an administrator user to add a new building to the database, including information such as title and capacity. 
           This data can be used in many other booking related instances in the project.
    -->

    <div class="container-fluid">
        <div class="jumbotron">
            <div class="row main">
				
				<div class="main-login main-center">
					<form class="form-horizontal" method="post" action="#">
                        <div class="panel-heading">
	                        <div class="panel-title text-center">
	               		    <h1 class="title">Add Building</h1>
	               		    <hr />
	               	        </div>
	                    </div> 
						
                        <!-- User to insert the building's name -->
						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Building Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inBuildingName"  placeholder="Enter the building's name" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- User to insert the building's label to be used as an identifier -->
                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Building Label</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inBuildingLabel"  placeholder="Enter the building's label" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- User to insert the building's room capacity -->
                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Number of Rooms</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="number" class="form-control" name="name" id="inRoomQty"  placeholder="Enter number of rooms" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- Submits the information for processing into the database -->
						<div class="form-group ">
							<asp:Button type="button" Text="Add Building" class="btn btn-primary btn-lg btn-block login-button" id="addButton" OnClick="addBuildingButton_Click" runat="server" />
						</div>						
					</form>
				</div>
			</div>
        </div>
    </div>
</asp:Content>
