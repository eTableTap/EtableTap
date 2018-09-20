<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Scan.aspx.cs" Inherits="TableTap.UL.Scan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script src='<%=ResolveUrl("~/BusinessLayer/JavaScript/jquery.webcam.js") %>' type="text/javascript"></script>
<script type="text/javascript">
var pageUrl = '<%=ResolveUrl("~/UL/scan.aspx") %>';
$(function () {
    jQuery("#webcam").webcam({
        width: 320,
        height: 240,
        mode: "save",
        swffile: '<%=ResolveUrl("~/BusinessLayer/JavaScript/jscam.swf") %>',
        debug: function (type, status) {
            $('#camStatus').append(type + ": " + status + '<br /><br />');
        },
        onSave: function (data) {
            $.ajax({
                type: "POST",
                url: pageUrl + "/GetCapturedImage",
                data: '',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    $("[id*=imgCapture]").css("visibility", "visible");
                    $("[id*=imgCapture]").attr("src", r.d);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        },
        onCapture: function () {
            webcam.save(pageUrl);
        }
    });
});
function Capture() {
    webcam.capture();
    return false;
}
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron">
            <h1>Scanning button will go here, it opens your camera to scan</h1>
            
            
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
            <u>Live Camera</u>
        </td>
        <td>
        </td>
        <td align="center">
            <u>Captured Picture</u>
        </td>
    </tr>
    <tr>
        <td>
            <div id="webcam">
            </div>
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            <asp:Image ID="imgCapture" runat="server" Style="visibility: hidden; width: 320px;
                height: 240px" />
        </td>
    </tr>
</table>
<br />
<asp:Button ID="btnCapture" Text="Capture" runat="server" OnClientClick="return Capture();" />
<br />
<span id="camStatus"></span>


            <asp:Button id="btnReserve" Text="Reserve Table" OnClick="btnReserve_Click" runat="server" />
            <asp:TextBox ID="textBox2" runat="server" />
        </div>

    </div>
</asp:Content>
