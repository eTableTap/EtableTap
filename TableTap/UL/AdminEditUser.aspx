<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminEditUser.aspx.cs" Inherits="TableTap.UL.AdminEditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- INFT 3970 - IT Major Project - Implementation
        Hayden Bartlett – C3185636
        Beau Maund – C3163068

        Source File Purpose:
        - Permits an administrator user to add a edit an existing table in the database, and permits searching of existing entries. 
        This data can be used in many other administrator related interactions in the project.
     -->

                    <input type="email" class="form-control" name="username" id="txbUsername" runat="server"  placeholder="Enter email"/>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
			        <asp:Button type="button" Text="Search" class="btn btn-primary btn-lg btn-block login-button" id="searchButton" onclick="searchButton_Click" runat="server" />

                    <asp:Label ID="lblLUserID" runat="server" Text="UserID"></asp:Label>
                    <asp:Label ID="lblUserID" runat="server" Text="UserID"></asp:Label>

                    <!-- Gather the users email from user input -->
                    <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>    
                    <input type="email" class="form-control" name="username" id="Email"  runat="server"  placeholder="Enter email"/>

                    <!-- Gather the users password from user input -->
                    <asp:Label ID="lbl" runat="server" Text="Password"></asp:Label>
                    <input type="text" class="form-control" name="password" id="inPassword"  placeholder="Password"  runat="server"/>

                    <!-- Gather the users firstname from user input -->
                    <asp:Label ID="Label2" runat="server" Text="Firstname"></asp:Label>
                    <input type="text" class="form-control" name="name" id="inFirstName"  placeholder="Firstname" runat="server"/>

                    <!-- Gather the users lastname from user input -->
                    <asp:Label ID="Label3" runat="server" Text="Surname"></asp:Label>
                    <input type="text"  class="form-control" name="name" id="inLastName"  placeholder="Surname" runat="server"/>

                    <!-- Gather the users required access priviledge from user input -->
                    <asp:Label ID="Label4" runat="server" Text="Administration privilege"></asp:Label>
                    <asp:CheckBox ID="chkAdmin" runat="server" />       

                    <br />
        
                    <!-- User options to Save, Delete or Cancel the Entry / Modification of User to the database -->
                    <asp:Button type="button" Text="Save" class="btn btn-primary btn-lg btn-block login-button" id="saveButton" onclick="saveButton_Click" runat="server" />           
                    <asp:Label ID="lblSaveStatus" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    <asp:Button type="button" Text="Delete" class="btn btn-primary btn-lg btn-block login-button" ID="deleteButton2" onclick="deleteButton_Click" runat="server" />
                    <asp:Button type="button" Text="Cancel" class="btn btn-primary btn-lg btn-block login-button" ID="cancelButton" onclick="cancelButton_Click" runat="server" />                     
                </div>
            </div>
        </div>
    </div>
</asp:Content>
