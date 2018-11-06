<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Googlelogin.aspx.cs" Inherits="TableTap.GoogleAPI.Googlelogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



   <script type="text/javascript">
       (function () {
           var po = document.createElement('script');
           po.type = 'text/javascript'; po.async = true;
           po.src = 'https://plus.google.com/js/client:plusone.js';
           var s = document.getElementsByTagName('script')[0];
           s.parentNode.insertBefore(po, s);
       })();
    </script>




        <div id="gConnect">
            <button class="g-signin"
                data-scope="https://www.googleapis.com/auth/plus.login  https://www.googleapis.com/auth/userinfo.email "
                data-requestvisibleactions="http://schemas.google.com/AddActivity"
                data-clientid="95633628411-ieit1lmkbmrsorf62osrevkmffi4uk87.apps.googleusercontent.com"
                data-accesstype="online"
                data-callback="onSignInCallback"
                data-theme="dark"
                data-cookiepolicy="single_host_origin">
            </button>
        </div>



        <script type="text/javascript">
        /**
        * Calls the helper method that handles the authentication flow.
        *
        * @param {Object} authResult An Object which contains the access token and
        *   other authentication information.
        */
        function onSignInCallback(authResult) {
            if (authResult['access_token']) {
                // The user is signed in
                var loc = '/GoogleAPI/return.aspx?accessToken=' + authResult['access_token'];
                window.location.href = loc;
            } else if (authResult['error']) {
                // There was an error, which means the user is not signed in.
                // As an example, you can troubleshoot by writing to the console:
                alert('There was an error: ' + authResult['error']);
            }
            //console.log('authResult', authResult);
        }
        </script>


</asp:Content>
