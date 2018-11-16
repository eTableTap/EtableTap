<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminTaskScheduler.aspx.cs" Inherits="TableTap.UL.AdminTaskScheduler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Included as an example of extensibility; permits an administrator user to schedule tasks in the system
    -->
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

                        <!-- Commences any automatic tasks scheduled to be performed -->
						<div class="form-group " style="text-align: center" >
                            <asp:Label ID="Lblinfo" runat="server" Text="Run only from server"></asp:Label>
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Start Automated Tasks" class="btn btn-primary btn-lg btn-block login-button" OnClick="Button1_Click" />
						</div>						
					</form>
				</div>
			</div>
        </div>
    </div>
</asp:Content>