<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminAddTable.aspx.cs" Inherits="TableTap.UL.AdminAddTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
					    <label for="name" class="cols-sm-2 control-label">Select Room:</label>
					    <div class="cols-sm-10">
						    <div class="input-group">
							    <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                
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

                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Table Catagory</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inTableCatagory"  placeholder="Enter the tables's catagory" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Number of Seats</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="number" class="form-control" name="name" id="inTableCapacity"  placeholder="Enter number of seats" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        
						<!--Need and image uploader-->


						<div class="form-group ">
							<asp:Button type="button" Text="Add Table" class="btn btn-primary btn-lg btn-block login-button" id="addButton" OnClick="addTableButton_Click" runat="server" />
						</div>
						
					</form>
				</div>
			</div>


        </div>
    </div>
</asp:Content>
