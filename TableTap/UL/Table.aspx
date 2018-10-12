<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="TableTap.UL.Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron">
            
            <asp:Label runat="server" id="lblHeading" text="Heading"></asp:Label>
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>
            

            

            <div class="form-group ">
					
                
                        <asp:DropDownList runat="server" ID="hourDropdown" onselectedindexchanged="hourDropdown_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:UpdatePanel ID="upBookingInfo" runat="server">
                                        <ContentTemplate>
							                <asp:Button type="button" ID="btnBook" Text="Book Table" onclick="btnBook_Click" runat="server" />
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="lblStatus" class="cols-sm-2 control-label" text="will update"></asp:Label>
                                                
                                                
					
			                                </div>
                                        </ContentTemplate>
                                    
                                        <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="hourDropdown" EventName="SelectedIndexChanged" />  
                                        </Triggers>
                                    </asp:UpdatePanel>
                        
                    
			</div>

        </div>
    </div>
</asp:Content>
