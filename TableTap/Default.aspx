<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TableTap.UL.TesterHeaderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="test1" runat="server" Text="Hayden Testing Page" OnClick="test1_Click" />
    <asp:Button ID="test2" runat="server" Text="Beau test page" OnClick="test2_Click" />
    <asp:Button ID="test3" runat="server" Text="admin home page" OnClick="test3_Click" />
    <asp:Button ID="test4" runat="server" Text="testQR" OnClick="test4_Click" />
    <asp:Button ID="test5" runat="server" Text="Registration page" OnClick="test5_Click" />
    <asp:Button ID="Button1" runat="server" Text="Directions Module" OnClick="Button1_Click" />
    <asp:Button ID="btntestnotify" runat="server" OnClick="btntestnotify_Click" Text="Test notify" />
    <asp:Button ID="btnBackgroundworker" runat="server" Text="start email notify ( DO NOT PUSH WILL SPAM HAYDEN SO BAD)" BackColor="Red" BorderColor="#003300" BorderStyle="Solid" BorderWidth="5px" Font-Bold="True" Font-Names="Arial Black" OnClick="btnBackgroundworker_Click" />
    <asp:Button ID="Button3" runat="server" Text="Test google login" OnClick="Button3_Click" />

    <div>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Test background worker" Width="96px" />
    </div>

    

        <asp:button ID="Buttontry" runat="server" onclick="buttontry_OnClick" Text="tryit"></asp:button>

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



