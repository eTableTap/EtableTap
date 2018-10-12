<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Map.aspx.cs" Inherits="TableTap.UL.Map" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>  
#holder{    
height:200px;    
width:550px;
background-color:#F5F5F5;
border:1px solid #A4A4A4;
margin-left:10px;   
}
#place {
position:relative;
margin:7px;
}
#place a{
font-size:0.6em;
}
#place li
{
 list-style: none outside none;
 position: absolute;   
}    
#place li:hover
{
background-color:yellow;      
} 
#place .seat{
background-color:blue;
height:33px;
width:33px;
display:block;   
}
#place .selectedSeat
{ 
    background-color:green;

}
#place .selectingSeat
{ background-color:grey;

}
#place .row-3, #place .row-4{
margin-top:10px;
}
#seatDescription li{
verticle-align:middle;    
list-style: none outside none;
padding-left:35px;
height:35px;
float:left;
}
    .auto-style1 {
        width: 109px;
    }
</style>
    <script src="/Seats.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Detter er map side

    
    
    <div class="container-fluid">
        <div class="jumbotron">
            <h2> Beau's table list</h2>

            <div class="form-group">
					<label for="name" class="cols-sm-2 control-label">Select Building:</label>
					<div class="cols-sm-10">
						<div class="input-group">
							<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
							<asp:DropDownList runat="server" ID="buildingDropdown" ></asp:DropDownList>
						</div>
					</div>
			</div>

            <div class="form-group ">
					<asp:Button type="button" Text="Go to buidling" class="btn btn-primary btn-lg btn-block login-button" id="goToBuildingButton" onclick="goToBuildingButton_Click" runat="server" />
			</div>

        </div>
    </div>

</asp:Content>
