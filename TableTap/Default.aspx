<%@ Page Title="Testing Page" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TableTap.UL.TesterHeaderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    </div>

    

        <asp:button ID="Buttontry" runat="server" onclick="buttontry_OnClick" Text="tryit"></asp:button>

    <asp:Label ID="lbltimetest" runat="server" Text="Label"></asp:Label>

<p id="demo">
    <asp:Label ID="lblsttatus" runat="server" Text="Label"></asp:Label>
</p>

<script type="text/javascript" >
var x = document.getElementById("demo");

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else { 
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    x.innerHTML = "Latitude: " + position.coords.latitude + 
        "<br>Longitude: " + position.coords.longitude;

   
}
</script>


    </asp:Content>



