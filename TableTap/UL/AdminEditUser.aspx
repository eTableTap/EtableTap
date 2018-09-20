<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminEditUser.aspx.cs" Inherits="TableTap.UL.AdminEditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                            <input type="email" class="form-control" name="username" id="txbUsername" runat="server"  placeholder="Enter email"/>
                            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
							<asp:Button type="button" Text="Search" class="btn btn-primary btn-lg btn-block login-button" id="searchButton" onclick="searchButton_Click" runat="server" />



<!-- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  DISPLAY/EDIT TABlE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! --->                            

                    

                                <asp:Label ID="lblLUserID" runat="server" Text="UserID"></asp:Label>

                                <asp:Label ID="lblUserID" runat="server" Text="UserID"></asp:Label>

                                   <asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>


                                    <input type="email" class="form-control" name="username" id="Email"  runat="server"  placeholder="Enter email"/>

                         <asp:Label ID="lbl" runat="server" Text="Password"></asp:Label>

                         <input type="text" class="form-control" name="password" id="inPassword"  placeholder="Password"  runat="server"/>

                           <asp:Label ID="Label2" runat="server" Text="Firstname"></asp:Label>

                           <input type="text" class="form-control" name="name" id="inFirstName"  placeholder="Firstname" runat="server"/>

                         <asp:Label ID="Label3" runat="server" Text="Surname"></asp:Label>

                           <input type="text"  class="form-control" name="name" id="inLastName"  placeholder="Surname" runat="server"/>

                         <asp:Label ID="Label4" runat="server" Text="Administration privilege"></asp:Label>

                         <asp:CheckBox ID="chkAdmin" runat="server" />       




                        <br />

                        <asp:Button type="button" Text="Save" class="btn btn-primary btn-lg btn-block login-button" id="saveButton" onclick="saveButton_Click" runat="server" />
           
                        <asp:Label ID="lblSaveStatus" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>


                    <asp:Button type="button" Text="Delete" class="btn btn-primary btn-lg btn-block login-button" ID="deleteButton2" onclick="deleteButton_Click" runat="server" />
                    <asp:Button type="button" Text="Cancel" class="btn btn-primary btn-lg btn-block login-button" ID="cancelButton" onclick="cancelButton_Click" runat="server" />
                     
                    </div>
                 </div>
            </div>
        </div>

</asp:Content>
