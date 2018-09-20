<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminAddUser.aspx.cs" Inherits="TableTap.UL.AdminAddUser" %>
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
	               		    <h1 class="title">Add a User</h1>
	               		    <hr />
	               	        </div>
	                    </div> 
						
						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">User First Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inADFirstName"  placeholder="Enter user first name" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">User Last Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inADLastName"  placeholder="Enter user last name" required="required" runat="server"/>
								</div>
							</div>
						</div>

						<div class="form-group">
							<label for="email" class="cols-sm-2 control-label">Enter Email</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
									<input type="email" class="form-control" name="email" id="inADEmail"  placeholder="Enter the Email" required="required" runat="server"/>
								</div>
							</div>
						</div>

						<div class="form-group">
							<label for="password" class="cols-sm-2 control-label">Password</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
									<input type="password" class="form-control" name="password" id="inADPassword"  placeholder="Enter the Password" required="required" runat="server"/>
								</div>
							</div>
						</div>

						<div class="form-group">
							<label for="confirm" class="cols-sm-2 control-label">Confirm Password</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
									<input type="password" class="form-control" name="confirm" id="inADConfirmPassword"  placeholder="Confirm the Password" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- matching passwords validator-->
                        <asp:CompareValidator ID="cvPsw" runat="server"
                            ControlToValidate="inADConfirmPassword"
                            ControlToCompare="inADPassword" Display="Dynamic"
                            ErrorMessage="Email re-entry" ForeColor="Red">
                             Must match first password
                        </asp:CompareValidator><br />

						<div class="form-group ">
							<asp:Button type="button" Text="Submit" class="btn btn-primary btn-lg btn-block login-button" id="submitButton" onclick="submitButton_Click" runat="server" />
						</div>
						
					</form>
				</div>
			</div>


        </div>
    </div>
    <asp:Label ID="lblconfirmation" runat="server"></asp:Label>
</asp:Content>
