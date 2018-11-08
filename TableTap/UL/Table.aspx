<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="TableTap.UL.Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="jumbotron">
            
            
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <script type="text/javascript"> <!--From https://stackoverflow.com/questions/25200152/prevent-double-clicking-asp-net-button-->
               var submit = 0;
                function CheckDouble()
                {
                    if (++submit > 1)
                    {
                     alert('This sometimes takes a few seconds - please be patient.');
                     return false;
                    }
                }
             </script>
            <div class="row">
					<div class="col mx-auto">
                        <asp:Label runat="server" Text="Table ID:"></asp:Label><br />
                        <asp:Label runat="server" Text="Category"></asp:Label><br />
                        <asp:Label runat="server" Text="Seating Capacity:"></asp:Label><br />
                    </div>
                    <div class="col mx-auto">
                        <asp:Label ID="lblgetID" runat="server" Text="getID"></asp:Label><br />
                        <asp:Label ID="lblgetCategory" runat="server" Text="getCategory"></asp:Label><br />
                        <asp:Label ID="lblgetSeatingCapacity" runat="server" Text="getSeatingCapacity"></asp:Label><br />
                    </div>
            </div>
            <br />
            <br />
            <div class="row">
                    <div class="col mx-auto">
                        <asp:Button ID="btnBookToday" Text="Book table for today" runat="server" class="btn btn-primary btn-md btn-block login-button" onclick="btnBookNowSection_Click"/><br />
                    </div>
                    <div class="col mx-auto">
                        <asp:Button ID="Button1" Text="Book table for future" runat="server" class="btn btn-success btn-md btn-block login-button" onclick="btnCalanderSection_Click"/><br />
                    </div>
                    <div class="col mx-auto">
                        <asp:Button ID="Button2" Text="Check In" runat="server" class="btn btn-primary btn-md btn-block login-button" onclick="btnCheckinSection_Click" /><br />
                    </div>
            </div>
            </div>
            <div class="jumbotron" runat="server" id="BookNowSection" visible="false">
            <div class="row">
					<div class="mx-auto">
                        <asp:Label runat="server" id="lblHeading" text="Heading"></asp:Label>
                        <asp:DropDownList runat="server" ID="hourDropdown" onselectedindexchanged="hourDropdown_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:UpdatePanel ID="upBookingInfo" runat="server">
                                        <ContentTemplate>
							                
                                            <div class="form-group">
                                                <!--<asp:Label runat="server" ID="lblStatus" class="cols-sm-2 control-label" text="will update"></asp:Label>-->
                                                <asp:Button type="button" ID="btnDirections" Text="Get Directions" onclick="btnDirections_Click" visible="false" runat="server" />
                                                
					
			                                </div>
                                        </ContentTemplate>
                                    
                                        <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="hourDropdown" EventName="SelectedIndexChanged" />  
                                        </Triggers>
                   </asp:UpdatePanel>
                        
                </div>    
			</div>
            <div  class="row" >
                <div id="bitToAddGroupMembers" class="mx-auto" runat="server">
                <asp:Label ID="lblInviteHelp" runat="server" Text="You can invite group members or friends by entering their emails below:" class="cols-sm-2 control-label" visible ="false"></asp:Label>
                <br />
                <asp:Label ID="lblOptional1" runat="server" Text="Optional Email:" visible ="false"></asp:Label>
                <Input id="InputEmail1" runat="server" type="email" visible ="false"/>
                <br />
                <asp:Label ID="lblOptional2" runat="server" Text="Optional Email:" visible ="false"></asp:Label>
                <Input id="InputEmail2" runat="server" type="email" visible ="false"/>
                <br />
                <asp:Label ID="lblOptional3" runat="server" Text="Optional Email:" visible="false"></asp:Label>
                <Input id="InputEmail3" runat="server" type="email" visible ="false"/>
                <br />
                <asp:Label ID="lblOptional4" runat="server" Text="Optional Email:" visible ="false"></asp:Label>
                <Input id="InputEmail4" runat="server" type="email" visible ="false"/>
                <br />
                <asp:Label ID="lblOptional5" runat="server" Text="Optional Email:" visible ="false"></asp:Label>
                <Input id="InputEmail5" runat="server" type="email" visible ="false"/>
                <br />
                </div>
            </div>
            <br />
                <div class="row">
                        <div class="col mx-auto">
                        </div>
                        <div class="col mx-auto">
                             <asp:Button type="button" ID="btnBook" Text="Book Table" onclick="btnBook_Click" OnClientClick="return CheckDouble();" runat="server" class="btn btn-danger btn-lg btn-block login-button" />
                        </div>  
                        <div class="col mx-auto">
                        </div>
                </div>
           
        </div>
         <div class="jumbotron" runat="server" id="CalanderSection" visible="false">
             <div class="form-group">
             <div class="row">
                 <div class="col">
                    
                    <asp:Label runat="server" ID="lblCalCheck" class="cols-sm-2 control-label" text="Select A Date:"></asp:Label>
                     <br />
                     <asp:Label runat="server" ID="lblHourHelper" class="cols-sm-2 control-label" text="Select An Hour:" Visible="false"></asp:Label>
                     <br />
                     <asp:DropDownList runat="server" ID="CalHourDropDown" onselectedindexchanged="calHourDropdown_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
							                
                                                <div class="form-group">

			                                    </div>
                                            </ContentTemplate>
                                    
                                            <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="CalHourDropDown" EventName="SelectedIndexChanged" />  
                                            </Triggers>
                       </asp:UpdatePanel>
                 </div>
                 <div class="col-10">
                    <asp:Calendar runat="server" ID="Cal" OnSelectionChanged="MyCalendar_SelectionChanged" Width="100%"/>
                </div>


            </div>
           </div>
             
            <div  class="row" >
                <div id="Div1" class="mx-auto" runat="server">
                <asp:Label ID="lblCalInviteHelp" runat="server" Text="You can invite group members or friends by entering their emails below:" class="cols-sm-2 control-label" visible ="false"></asp:Label>
                <br />
                <asp:Label ID="lblCalOptional1" runat="server" Text="Optional Email:" visible ="false"></asp:Label>
                <Input id="InputCalEmail1" runat="server" type="email" visible ="false"/>
                <br />
                <asp:Label ID="lblCalOptional2" runat="server" Text="Optional Email:" visible ="false"></asp:Label>
                <Input id="InputCalEmail2" runat="server" type="email" visible ="false"/>
                <br />
                <asp:Label ID="lblCalOptional3" runat="server" Text="Optional Email:" visible="false"></asp:Label>
                <Input id="InputCalEmail3" runat="server" type="email" visible ="false"/>
                <br />
                <asp:Label ID="lblCalOptional4" runat="server" Text="Optional Email:" visible ="false"></asp:Label>
                <Input id="InputCalEmail4" runat="server" type="email" visible ="false"/>
                <br />
                <asp:Label ID="lblCalOptional5" runat="server" Text="Optional Email:" visible ="false"></asp:Label>
                <Input id="InputCalEmail5" runat="server" type="email" visible ="false"/>
                <br />
                </div>
            </div>       
                    
                 
            <br />
            <div class="row">
                        <div class="col mx-auto">
                        </div>
                        <div class="col mx-auto">
                            <asp:Button type="button" ID="btnBookCalander" Text="Book Table" onclick="btnBookCalander_Click" OnClientClick="return CheckDouble();" runat="server" class="btn btn-danger btn-lg btn-block login-button"/>
                        </div>  
                        <div class="col mx-auto">
                        </div>
            </div>
        </div>
       <div class="jumbotron" runat="server" id="CheckinSection" visible="false">
           <div class="row">
                        <div class="col mx-auto">
                        </div>
                        <div class="col mx-auto">
                            <asp:Label ID="lblCheckinResult" runat="server" Text="Should update"></asp:Label>
                        </div>  
                        <div class="col mx-auto">
                        </div>
        </div>
     </div>
</asp:Content>
