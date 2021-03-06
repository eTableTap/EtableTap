﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="GoogleLogin.aspx.cs" Inherits="TableTap.UL.GoogleLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content> 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Acquires user details and then facilitates login to the Google account service
     -->
        <div class="container">
        <div class="jumbotron">
            <div class="row main">				
				<div class="main-login main-center mx-auto">                    
                        <div class="panel-heading">
	                        <div class="panel-title text-center">
	               		    <h1 class="title">Register</h1>
	               		    <hr />
	               	        </div>
	                    </div> 

                    <!-- Acquire a users email address -->
                    	<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Email</label>
							<div class="cols-sm-10">
								<div class="input-group">
                                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
								</div>
							</div>
						</div>	
                        
                        <!-- Acquire a users first name -->
						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Your First Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inFirstName"  placeholder="Enter your first name" required="required" runat="server"/>
								</div>
							</div>
						</div>

                    
                        <!-- Acquire a users last name -->
                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Your Last Name</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
									<input type="text" class="form-control" name="name" id="inLastName"  placeholder="Enter your last name" required="required" runat="server"/>
								</div>
							</div>
						</div>
                    
                      <!-- Acquire a users mobile phone number -->
                      <div class="form-group">
						<label for="phone" class="cols-sm-2 control-label">Mobile Phone</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
									<input type="number" class="form-control" name="Phone" id="inPhone"  placeholder="Enter your phone" required="required" runat="server"/>
								</div>
							</div>
						</div>

                    
                        <!-- Acquire a users password -->
                    	<div class="form-group">
							<label for="password" class="cols-sm-2 control-label">Password</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
									<input type="password" class="form-control" name="password" id="inPassword"  placeholder="Enter your Password" required="required" runat="server"/>
								</div>
							</div>
						</div>

                    
                        <!-- Confirm a users password -->
						<div class="form-group">
							<label for="confirm" class="cols-sm-2 control-label">Confirm Password</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
									<input type="password" class="form-control" name="confirm" id="inConfirmPassword"  placeholder="Confirm your Password" required="required" runat="server"/>
								</div>
							</div>
						</div>

                    <!-- Matching passwords must be recieved from the password boxes, otherwise na error is displayed -->
                      <asp:CompareValidator ID="cvPsw" runat="server"
                            ControlToValidate="inConfirmPassword"
                            ControlToCompare="inPassword" Display="Dynamic"
                            ErrorMessage="Password re-entry" ForeColor="Red">
                             Must match first password
                        </asp:CompareValidator><br />

                    
                        <!-- Register the user -->
                    	<div class="form-group ">
							<asp:Button type="button" Text="Register" class="btn btn-primary btn-lg btn-block login-button" id="registerButton" onclick="registerButton_Click" runat="server" />
						</div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>


    


