<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TableTap.UL.Room" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Serves as a second page for booking, permits a user to select a room as part of the booking process
     -->
    <div class="container">
        <div class="jumbotron">            
            <div class="row">
                <div class="mx-auto">
                    <asp:Label ID="lblRoomHeading" runat="server" Text="Table list" CssClass="h1"></asp:Label><br />
                </div>
            </div>
            <asp:Label ID="lblSelectGuide" runat="server" Text="Current table statuses:" CssClass="h3"></asp:Label><br />
            <asp:Label ID="lblSelectHelp" runat="server" Text="Click table to book it" class="cols-sm-2 control-label"></asp:Label>
            <div id="divTableImages" runat="server"></div>
            
            <!-- User selects room from list -->
            <div class="form-group">
                <asp:Label runat="server" ID="lblAboveDropdown" class="cols-sm-2 control-label" text="Select Table:"></asp:Label>
			    <div class="cols-sm-10">
				    <div class="input-group">
					    <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
					    <asp:DropDownList runat="server" ID="tableDropdown" ></asp:DropDownList>
				    </div>
			    </div>
			</div>

            <!-- User selects a room and the next phase of the booking process occurs -->
            <div class="form-group ">
				<asp:Button type="button" Text="Go to table" class="btn btn-primary btn-lg btn-block login-button" id="goToTableButton" onclick="goToTableButton_Click" runat="server" />
			</div>
        </div>
    </div>
</asp:Content>
