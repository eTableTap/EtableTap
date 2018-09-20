<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminEditTable.aspx.cs" Inherits="TableTap.UL.AdminEditTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                                <input type="text" class="form-control" name="tableID" id="inptable" runat="server"  placeholder="Enter tableID"/>
                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
							<asp:Button type="button" Text="Search" class="btn btn-primary btn-lg btn-block login-button" id="searchButton" onclick="searchButton_Click" runat="server" />



<!-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  DISPLAY/EDIT TABlE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! --->                            

                    

                                <asp:Label ID="lblLableTableID" runat="server" Text="TableID"></asp:Label>

                                <asp:Label ID="lblTableID" runat="server" Text="TableID"></asp:Label>

                                   <asp:Label ID="Label1" runat="server" Text="roomID"></asp:Label>


                                    <input type="text" class="form-control" name="INProomID" id="INroomID"  runat="server"  placeholder="Enter RoomID"/>

                         <asp:Label ID="lblPersonCapacity" runat="server" Text="personCapacity"></asp:Label>

                         <input type="text" class="form-control" name="inpersonCapacity" id="inpersonCapacity"  placeholder="Set Capacity"  runat="server"/>

                           <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>

                           <input type="text" class="form-control" name="name" id="inCatagory"  placeholder="Catagory" runat="server"/>


                        <br />

                        <asp:Button type="button" Text="Save" class="btn btn-primary btn-lg btn-block login-button" id="saveButton" onclick="saveButton_Click" runat="server" />
           
                        <asp:Label ID="lblSaveStatus" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>


                    <asp:Button type="button" Text="Delete" class="btn btn-primary btn-lg btn-block login-button" ID="deleteButton2" onclick="deleteButton_Click" runat="server" />
                    <asp:Button type="button" Text="Cancel" class="btn btn-primary btn-lg btn-block login-button" ID="cancelButton" onclick="cancelButton_Click" runat="server" />
</asp:Content>
