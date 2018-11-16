<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminAddTable.aspx.cs" Inherits="TableTap.UL.AdminAddTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Permits an administrator user to add a new table to a room in a building in the database, including information such as table category and table seating capacity. 
          This data can be used in many other booking related instances in the project.
    -->

    <div class="container-fluid">
        <div class="jumbotron">
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="row main">
				
				<div class="main-login main-center">
					<form class="form-horizontal" method="post" action="#">
                        <div class="panel-heading">
	                        <div class="panel-title text-center">
	               		    <h1 class="title">Add Table</h1>
	               		    <hr />
	               	        </div>
	                    </div> 
						
                        <!-- Select the building for the new table to be added to -->
                        <div class="form-group">
					            <label for="name" class="cols-sm-2 control-label">Select Building:</label>
					            <div class="cols-sm-10">
						            <div class="input-group">
							            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            
                                        <!-- Dynamically pulls the current buildings stored in the database, for viewing in a dropdown -->
							            <asp:DropDownList runat="server" ID="buildingDropdown" onselectedindexchanged="ddlbuildingDropDown_SelectedIndexChanged" AutoPostback="True" ></asp:DropDownList>
                                
						            </div>
					            </div>
			            </div>

                        <!-- User to input the room the table is to be placed in -->
                        <div class="form-group">
					    <label for="name" class="cols-sm-2 control-label">Select Room:</label>
					    <div class="cols-sm-10">
						    <div class="input-group">
							    <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                
                                    <!-- Dynamically pulls the current rooms stored in the building, for viewing in a dropdown -->
                                    <asp:UpdatePanel ID="upRoomDdl" runat="server">
                                        <ContentTemplate>
							                <asp:DropDownList runat="server" ID="roomDropdown" AutoPostBack="true" ></asp:DropDownList>
                                        </ContentTemplate>
                                    
                                        <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="buildingDropdown" EventName="SelectedIndexChanged" />  
                                        </Triggers>
                                    </asp:UpdatePanel>
						        </div>
					        </div>
			            </div>

                        <!-- User to select a category for the table -->
                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Table Catagory</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inTableCatagory"  placeholder="Enter the tables's catagory" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- User to input the number of seats the table can hold -->
                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Number of Seats</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="number" class="form-control" name="name" id="inTableCapacity"  placeholder="Enter number of seats" required="required" runat="server"/>
								</div>
							</div>
						</div>                  

                         <!-- User submits this information for processing into the database -->
						<div class="form-group ">
							<asp:Button type="button" Text="Add Table" class="btn btn-primary btn-lg btn-block login-button" id="addButton" OnClick="addTableButton_Click" runat="server" />
						</div>						
					</form>
				</div>
			</div>
        </div>
    </div>
</asp:Content>
