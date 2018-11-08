<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminTaskScheduler.aspx.cs" Inherits="TableTap.UL.AdminTaskScheduler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron" style="text-align: center">
            <div class="row main">
				
				<div class="main-login main-center">
					<form class="form-horizontal" method="post" action="#"  >
                        <div class="panel-heading">
	                        <div class="panel-title text-center">
	               		    <h1 class="title">Admin Auto Panel</h1>
	               		    <hr />
	               	        </div>
	                    </div> 
						
						

						<div class="form-group " style="text-align: center" >
                            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
						</div>
						
					</form>
				</div>
			</div>


        </div>
    </div>
</asp:Content>