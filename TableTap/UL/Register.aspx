<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TableTap.UL.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Assists in registering a user into the system
     -->

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="container">
        <div class="jumbotron">
            <div class="row main">				
	            <div class="main-login main-center mx-auto">
		            <div ></div>
                        <div class="panel-heading">
	                        <div class="panel-title text-center">
	                        <h1 class="title">Register</h1>
	                        <hr />
	                        </div>
	                    </div> 
						
                        <!-- Takes users first name -->
			            <div class="form-group">
				            <label for="name" class="cols-sm-2 control-label">Your First Name</label>
				            <div class="cols-sm-10">
					            <div class="input-group">
						            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
						            <input type="text" class="form-control" name="name" id="inFirstName"  placeholder="Enter your first name" required="required" runat="server"/>
					            </div>
				            </div>
			            </div>

                        <!-- Takes users last name -->
                        <div class="form-group">
				            <label for="name" class="cols-sm-2 control-label">Your Last Name</label>
				            <div class="cols-sm-10">
					            <div class="input-group">
						            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
						            <input type="text" class="form-control" name="name" id="inLastName"  placeholder="Enter your last name" required="required" runat="server"/>
					            </div>
				            </div>
			            </div>

                        <!-- Takes users email -->
			            <div class="form-group">
				            <label for="email" class="cols-sm-2 control-label">Your Email</label>
				            <div class="cols-sm-10">
					            <div class="input-group">
						            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
						            <input type="email" class="form-control" name="email" id="inEmail"  placeholder="Enter your Email" required="required" runat="server"/>
					            </div>
				            </div>
			            </div>

                        <!-- Takes users mobile phone -->
                        <div class="form-group">
			            <label for="phone" class="cols-sm-2 control-label">Mobile Phone</label>
				            <div class="cols-sm-10">
					            <div class="input-group">
						            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
						            <input type="number" class="form-control" name="Phone" id="inPhone"  placeholder="Enter your phone" required="required" runat="server"/>
					            </div>
				            </div>
			            </div>

                        <!-- Takes users password -->
			            <div class="form-group">
				            <label for="password" class="cols-sm-2 control-label">Password</label>
				            <div class="cols-sm-10">
					            <div class="input-group">
						            <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
						            <input type="password" class="form-control" name="password" id="inPassword"  placeholder="Enter your Password" required="required" runat="server"/>
					            </div>
				            </div>
			            </div>

                        <!-- Confirms users password -->
			            <div class="form-group">
				            <label for="confirm" class="cols-sm-2 control-label">Confirm Password</label>
				            <div class="cols-sm-10">
					            <div class="input-group">
						            <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
						            <input type="password" class="form-control" name="confirm" id="inConfirmPassword"  placeholder="Confirm your Password" required="required" runat="server"/>
					            </div>
				            </div>
			            </div>

                        <!-- Throws error if there are not matching passwords as sent through this validator -->
                        <asp:CompareValidator ID="cvPsw" runat="server"
                            ControlToValidate="inConfirmPassword"
                            ControlToCompare="inPassword" Display="Dynamic"
                            ErrorMessage="Password re-entry" ForeColor="Red">
                                Must match first password
                        </asp:CompareValidator><br />

                        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>

                        <!-- Submits users values -->
			            <div class="form-group ">
				            <asp:Button type="button" Text="Register" class="btn btn-primary btn-lg btn-block login-button" id="registerButton" onclick="registerButton_Click" runat="server" />
			        </div>						
				</div>
			</div>
        </div>
    </div>
</asp:Content>
