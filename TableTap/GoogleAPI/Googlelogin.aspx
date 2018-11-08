<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Googlelogin.aspx.cs" Inherits="TableTap.GoogleAPI.Googlelogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    


      <script type="text/javascript">
       (function () {
           var po = document.createElement('script');
           po.type = 'text/javascript'; po.async = true;
           po.src = 'https://plus.google.com/js/client:plusone.js';
           var s = document.getElementsByTagName('script')[0];
           s.parentNode.insertBefore(po, s);
       })();
     </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



 



        <div id="googleSignin">
            <button class="g-signin"
                data-scope="https://www.googleapis.com/auth/plus.login  https://www.googleapis.com/auth/userinfo.email "
                data-requestvisibleactions="http://schemas.google.com/AddActivity"
                data-clientid="95633628411-ieit1lmkbmrsorf62osrevkmffi4uk87.apps.googleusercontent.com"
                data-accesstype="online"
                data-callback="Callback"
                data-theme="dark"
                data-cookiepolicy="single_host_origin">
            </button>
        </div>



       <script type="text/javascript">
        function Callback(authResult) {
            if (authResult['access_token']) {
                // Signin is successful
                window.location.href = '/GoogleAPI/return.aspx?accessToken=' + authResult['access_token'];
            } else
            {

            }
        }
        </script>


</asp:Content>
