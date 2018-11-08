<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TableTap.UL.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" style="text-align:center">

    <!---- Google login ---->
     <script type="text/javascript">
       (function () {
           var po = document.createElement('script');
           po.type = 'text/javascript'; po.async = true;
           po.src = 'https://plus.google.com/js/client:plusone.js';
           var s = document.getElementsByTagName('script')[0];
           s.parentNode.insertBefore(po, s);
       })();
     </script>
    <!--- END Google login --->

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class="form-horizontal" method="post" action="#">
    <div class="container-fluid" >
        <div class="jumbotron" >
             <div class="row main" >
				
				<div class="main-login main-center">

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
							<asp:Button type="button" Text="Login" class="btn btn-primary btn-lg btn-block login-button" id="loginButton" onclick="loginButton_Click" runat="server" />
						</div>

                        <div id="googleSignin" style="text-align:center" >
                            <button class="g-signin" style="text-align:Center"
                            data-scope="https://www.googleapis.com/auth/plus.login  https://www.googleapis.com/auth/userinfo.email "
                            data-requestvisibleactions="http://schemas.google.com/AddActivity"
                            data-clientid="95633628411-ieit1lmkbmrsorf62osrevkmffi4uk87.apps.googleusercontent.com"
                            data-accesstype="online"
                            data-callback="Callback"
                            data-theme="dark"
                            data-cookiepolicy="single_host_origin">
                            </button>
                            
                       </div>

                        <div class="login-register">
				            <asp:Label ID="lblinfo" runat="server" Text="Don't have an account?  "></asp:Label>
				            <asp:HyperLink runat="server" href="Register.aspx">Register</asp:HyperLink>
				        </div>

					
				</div>
			</div>


        </div>
    </div>

    <!----- GOOGLE LOGIN SCRIPT ---------->

    <script type="text/javascript">
        function Callback(authResult)
        {

            if (authResult['access_token'])
            {

                // Signin is successful
                window.location.href = '/UL/GoogleLogin.aspx?accessToken=' + authResult['access_token'];
            }
            else
            {
                window.location.href = '/UL/Login.aspx'; // do not place anything here as it is too annoying to code for no benefit
            }
        }
     </script>




</asp:Content>
