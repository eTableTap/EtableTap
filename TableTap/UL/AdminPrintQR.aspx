<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminPrintQR.aspx.cs" Inherits="TableTap.UL.AdminPrintQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <!-- INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Included as an example of extensibility; permits an administrator user to manage all values regarding an incident in the system
    -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="jumbotron">
            <h2> Print QR</h2>
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <!-- User selects building, as pulled from the database -->
            <div class="form-group">
				<label for="name" class="cols-sm-2 control-label">Select Building:</label>
				<div class="cols-sm-10">
					<div class="input-group">
						<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            
						<asp:DropDownList runat="server" ID="buildingDropdown" onselectedindexchanged="ddlbuildingDropDown_SelectedIndexChanged" AutoPostback="True" ></asp:DropDownList>
                                
					</div>
				</div>
		    </div>
            
            <!-- User selects a room as pulled from the database -->
            <div class="form-group">
					<label for="name" class="cols-sm-2 control-label">Select Room:</label>
					<div class="cols-sm-10">
						<div class="input-group">
							<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>                                
                                <asp:UpdatePanel ID="upRoomDdl" runat="server">
                                    <ContentTemplate>
							            <asp:DropDownList runat="server" ID="roomDropdown" onselectedindexchanged="ddlroomDropDown_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                    </ContentTemplate>                                    
                                    <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="buildingDropdown" EventName="SelectedIndexChanged" />  
                                    </Triggers>
                                </asp:UpdatePanel>
						</div>
				 </div>
			</div>
            
            <!-- User selects a table, as pulled from the database -->
            <div class="form-group">
					<label for="name" class="cols-sm-2 control-label">Select Table:</label>
					<div class="cols-sm-10">
						<div class="input-group">
							<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            <asp:UpdatePanel ID="upTableDdl" runat="server">
                                        <ContentTemplate>
							<asp:DropDownList runat="server" ID="tableDropdown" Autopostback="true" ></asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="roomDropdown" EventName="SelectedIndexChanged" />  
                                </Triggers>
                            </asp:UpdatePanel>
						</div>
					</div>
			</div> 

            <!-- User confirms their choices, as by hitting the 'generate QR code' button -->
            <div class="form-group ">
				<asp:Button type="button" Text="Generate QR Code" class="btn btn-primary btn-lg btn-block login-button" id="generateButton" onclick="generateButton_Click" runat="server" />
			</div>
        </div>
    </div>
</asp:Content>
