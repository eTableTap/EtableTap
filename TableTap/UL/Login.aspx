<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TableTap.UL.Login" %>
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
	               		    <h1 class="title">Login</h1>
	               		    <hr />
	               	        </div>
	                    </div> 
						

						<div class="form-group">
							Email address
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
									<input type="email" class="form-control" name="username" id="txbUsername" required="required" runat="server"  placeholder="Enter your email"/>
								    <asp:Label ID="lblUsername" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
								</div>
							</div>
						</div>

						<div class="form-group">
							<label for="password" class="cols-sm-2 control-label">Password</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
									<input type="password" class="form-control" name="password" id="txbPassword" required="required" runat="server" placeholder="Enter your Password"/>
								    <asp:Label ID="lblPassword" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
								</div>
							</div>
						</div>


						<div class="form-group ">
							<asp:Button type="button" Text="Login" class="btn btn-primary btn-lg btn-block login-button" id="registerButton" onclick="loginButton_Click" runat="server" />
						</div>

                        <div class="login-register">
				            <asp:Label ID="lblinfo" runat="server" Text="Don't have an account?  "></asp:Label>
				            <asp:HyperLink runat="server" href="Register.aspx">Register</asp:HyperLink>
				        </div>

					</form>
				</div>
			</div>


        </div>
    </div>
</asp:Content>
