<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminAddRoom.aspx.cs" Inherits="TableTap.UL.AdminAddRoom" %>
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
	               		    <h1 class="title">Add Room</h1>
	               		    <hr />
	               	        </div>
	                    </div> 
						
                        <div class="form-group">
					            <label for="name" class="cols-sm-2 control-label">Select Building:</label>
					            <div class="cols-sm-10">
						            <div class="input-group">
							            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            
							            <asp:DropDownList runat="server" ID="buildingDropdown" onselectedindexchanged="ddlbuildingDropDown_SelectedIndexChanged" AutoPostback="True" ></asp:DropDownList>
                                
						            </div>
					            </div>
			            </div>

						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Room Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inRoomName"  placeholder="Enter the building's name" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Room Label</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inRoomLabel"  placeholder="Enter the building's label" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Max Number of Tables</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="number" class="form-control" name="name" id="inTableQty"  placeholder="Enter number of rooms" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        
						<!--Need and image uploader-->


						<div class="form-group ">
							<asp:Button type="button" Text="Add Room" class="btn btn-primary btn-lg btn-block login-button" id="addRoom" OnClick="addRoomButton_Click" runat="server" />
						</div>
						
					</form>
				</div>
			</div>


        </div>
    </div>
</asp:Content>
