<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TableTap.UL.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
                <div class="col-sm-6" style="background-color:seagreen">
                     <asp:hyperlink ID="hlLogin" runat="server" href="Login.aspx">
                                <asp:Image ID="imgLogin" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>
                     </asp:hyperlink>
                </div>
                <div class="col-sm-6" style="background-color:darkseagreen">
                    <asp:hyperlink ID="hlMap" runat="server" href="Map.aspx">
                        <asp:Image ID="imgMap" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>
                    </asp:hyperlink>
               </div>
        </div> 
        <div class="row">
            <div class="col-sm-4" style="background-color:cornflowerblue">
                 <asp:hyperlink ID="hlScan" runat="server" href="Scan.aspx">
                         <asp:Image ID="imgScan" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>
                 </asp:hyperlink>
            </div>
            <div class="col-sm-4" style="background-color:dodgerblue">
                 <asp:hyperlink ID="hlAccount" runat="server" href="Account.aspx">
                         <asp:Image ID="imgAccount" runat="server" imageurl="~/Resources/Images/Spiteful_Spirit.jpg" CssClass="HomeImages"/>
                 </asp:hyperlink>
            </div>
            <div class="col-sm-4" style="background-color:lightskyblue">
                
            </div>
        </div>
            
    </div>
</asp:Content>
