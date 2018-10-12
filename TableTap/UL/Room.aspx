<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TableTap.UL.Room" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron">
            
            <asp:Label ID="lblHeading" runat="server" Text="Table list" CssClass="h1"></asp:Label>
            <div id="divTableImages" runat="server"></div>
            <div class="form-group">
                    <asp:Label runat="server" ID="lblAboveDropdown" class="cols-sm-2 control-label" text="Select Table:"></asp:Label>
					<div class="cols-sm-10">
						<div class="input-group">
							<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
							<asp:DropDownList runat="server" ID="tableDropdown" ></asp:DropDownList>
						</div>
					</div>
			</div>

            <div class="form-group ">
					<asp:Button type="button" Text="Go to table" class="btn btn-primary btn-lg btn-block login-button" id="goToTableButton" onclick="goToTableButton_Click" runat="server" />
			</div>

        </div>
    </div>
</asp:Content>
