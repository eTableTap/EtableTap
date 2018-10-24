<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="TableTap.UL.Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron">
            
            <asp:Label runat="server" id="lblHeading" text="Heading"></asp:Label>
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
            

            <div class="form-group ">
					
                
                        <asp:DropDownList runat="server" ID="hourDropdown" onselectedindexchanged="hourDropdown_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:UpdatePanel ID="upBookingInfo" runat="server">
                                        <ContentTemplate>
							                <asp:Button type="button" ID="btnBook" Text="Book Table" onclick="btnBook_Click" OnClientClick="return CheckDouble();" runat="server" />
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="lblStatus" class="cols-sm-2 control-label" text="will update"></asp:Label>
                                                <asp:Button type="button" ID="btnDirections" Text="Get Directions" onclick="btnDirections_Click" visible="false" runat="server" />
                                                
					
			                                </div>
                                        </ContentTemplate>
                                    
                                        <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="hourDropdown" EventName="SelectedIndexChanged" />  
                                        </Triggers>
                   </asp:UpdatePanel>
                        
                    
			</div>
            <div id="bitToAddGroupMembers">
                <asp:Label ID="lblOptional1" runat="server" Text="Optional:"></asp:Label>
                <Input id="InputEmail1" runat="server" type="email"/>
                <br />
                <asp:Label ID="lblOptional2" runat="server" Text="Optional:"></asp:Label>
                <Input id="InputEmail2" runat="server" type="email"/>
                <br />
                <asp:Label ID="lblOptional3" runat="server" Text="Optional:"></asp:Label>
                <Input id="InputEmail3" runat="server" type="email"/>
                <br />
                <asp:Label ID="lblOptional4" runat="server" Text="Optional:"></asp:Label>
                <Input id="InputEmail4" runat="server" type="email"/>
                <br />
                <asp:Label ID="lblOptional5" runat="server" Text="Optional:"></asp:Label>
                <Input id="InputEmail5" runat="server" type="email"/>
                <br />
            </div>
                
        </div>
    </div>
</asp:Content>
