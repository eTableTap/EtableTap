<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminAddBuilding.aspx.cs" Inherits="TableTap.UL.AdminAddBuilding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
						
						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Building Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inBuildingName"  placeholder="Enter the building's name" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Building Label</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inBuildingLabel"  placeholder="Enter the building's label" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Number of Rooms</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="number" class="form-control" name="name" id="inRoomQty"  placeholder="Enter number of rooms" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        
						<!--Need and image uploader-->


						<div class="form-group ">
							<asp:Button type="button" Text="Add Building" class="btn btn-primary btn-lg btn-block login-button" id="addButton" OnClick="addBuildingButton_Click" runat="server" />
						</div>
						
					</form>
				</div>
			</div>


        </div>
    </div>
</asp:Content>
