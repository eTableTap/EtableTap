<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="404Page.aspx.cs" Inherits="TableTap._404Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container">
        <div class="jumbotron">
            <div style="margin-left: auto; margin-right: auto; text-align: center;">
                <div class="panel-heading">
	                   <div class="panel-title text-center">
	               		    <h1 class="title">Uh Oh!!! </h1>
	               		    <br />
	               	  </div>
	            </div> 

                <table style="width:100%">
                        <tr>
                            <th class="auto-style2">
                                <asp:Label ID="Label2" runat="server" Text="We don't seem to have that page. But! I drew you a flower!" Font-Bold="True" Font-Size="Large"></asp:Label>
                            </th>


                        </tr>

                       <tr>
                           <th class="auto-style2">
                               <asp:Image ID="imgLogin" runat="server" imageurl="~/Resources/Images/SorryFlower.png" Height ="30%"/>
                           </th>
                       </tr>
                       <tr>
                           <th class="auto-style2">
                                <asp:Label ID="Label1" runat="server" Text="Now that you’ve forgiven us; Use this button to get back on track" Font-Bold="True" Font-Size="Large"></asp:Label>
                           </th>
                       </tr>
                       <tr>
                           <th class="auto-style2">
                                <asp:Button type="button" Text="Go back to home" class="btn btn-primary btn-lg btn-block login-button" id="Button1" runat="server" />
                           </th>
                       </tr>
                    </table>

                </div>
            
            </div>
            </div>


</asp:Content>
