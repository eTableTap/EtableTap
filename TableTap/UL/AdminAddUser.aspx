<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminAddUser.aspx.cs" Inherits="TableTap.UL.AdminAddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Permits an administrator user to add a new user to the database, including information such as full-name, email and password. 
        This data can be used in many other user related interactions in the project.
     -->

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
						
                        <!-- Input the Users First Name -->
						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">User First Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<input type="text" class="form-control" name="name" id="inADFirstName"  placeholder="Enter user first name" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- Input the Users Last Name -->
                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">User Last Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<input type="text" class="form-control" name="name" id="inADLastName"  placeholder="Enter user last name" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- Input the users email -->
						<div class="form-group">
							<label for="email" class="cols-sm-2 control-label">Enter Email</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<input type="email" class="form-control" name="email" id="inADEmail"  placeholder="Enter the Email" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- Input the Users Password -->
						<div class="form-group">
							<label for="password" class="cols-sm-2 control-label">Password</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<input type="password" class="form-control" name="password" id="inADPassword"  placeholder="Enter the Password" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!-- Confirm the users password -->
						<div class="form-group">
							<label for="confirm" class="cols-sm-2 control-label">Confirm Password</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<input type="password" class="form-control" name="confirm" id="inADConfirmPassword"  placeholder="Confirm the Password" required="required" runat="server"/>
								</div>
							</div>
						</div>

                        <!--Validates the users entered passwords, and reports an error if the strings do not match-->
                        <asp:CompareValidator ID="cvPsw" runat="server"
                            ControlToValidate="inADConfirmPassword"
                            ControlToCompare="inADPassword" Display="Dynamic"
                            ErrorMessage="Email re-entry" ForeColor="Red">
                             Must match first password
                        </asp:CompareValidator><br />

                         <!-- Submits the information for processing into the database -->
						<div class="form-group ">
							<asp:Button type="button" Text="Submit" id="submitButton"  class="btn btn-primary btn-lg btn-block login-button" onclick="submitButton_Click" runat="server" />
						</div>						
					</form>
				</div>
			</div>
        </div>
    </div>
    <asp:Label ID="lblconfirmation" runat="server"></asp:Label>
</asp:Content>
