<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminPrintQR.aspx.cs" Inherits="TableTap.UL.AdminPrintQR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <div class="jumbotron">
            <h2> Beau's table list</h2>
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>

            <div class="form-group">
					<label for="name" class="cols-sm-2 control-label">Select Building:</label>
					<div class="cols-sm-10">
						<div class="input-group">
							<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            
							<asp:DropDownList runat="server" ID="buildingDropdown" onselectedindexchanged="ddlroomDropDown_SelectedIndexChanged" AutoPostback="True" ></asp:DropDownList>
                                
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
							                <asp:DropDownList runat="server" ID="roomDropdown" onselectedindexchanged="ddltableDropDown_SelectedIndexChanged" AutoPostback="True"></asp:DropDownList>
                                        </ContentTemplate>
                                    
                                        <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="buildingDropdown" EventName="SelectedIndexChanged" />  
                                        </Triggers>
                                    </asp:UpdatePanel>
						    </div>
					    </div>
			    </div>
            

            <div class="form-group">
					<label for="name" class="cols-sm-2 control-label">Select Table:</label>
					<div class="cols-sm-10">
						<div class="input-group">
							<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            <asp:UpdatePanel ID="upTableDdl" runat="server">
                                        <ContentTemplate>
							<asp:DropDownList runat="server" ID="tableDropdown" ></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="roomDropdown" EventName="SelectedIndexChanged" />  
                                        </Triggers>
                                 </asp:UpdatePanel>
						</div>
					</div>
			</div> 

        </div>
    </div>
</asp:Content>
