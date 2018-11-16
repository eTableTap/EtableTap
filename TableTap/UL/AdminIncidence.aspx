<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminIncidence.aspx.cs" Inherits="TableTap.UL.AdminIncidence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Included as an example of extensibility; permits an administrator user to manage all values regarding an incident in the system
    -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="container-fluid">        
        <asp:GridView GridLines="None" ID="IncidentGrid" runat="server" AutoGenerateColumns="False" OnRowEditing="IncidentRowEditing" OnRowDeleting="IncidentRowDeleting" OnRowUpdating="IncidentRowUpdating"> 
                <Columns>
                    <!-- Values relevant to an incident -->
                    <asp:BoundField DataField="IncidentID" HeaderText="incidenceID" ReadOnly="true" />
                    <asp:BoundField DataField="incDate" HeaderText="incDate" ReadOnly="true" />
                    <asp:BoundField DataField="buildingID" HeaderText="buildingID" ReadOnly="true" />
                    <asp:BoundField DataField="roomID" HeaderText="roomID" ReadOnly="true" />
                    <asp:BoundField DataField="tableID" HeaderText="tableID" ReadOnly="true" />
                    <asp:BoundField DataField="userID" HeaderText="userID" ReadOnly="true" />
                    <asp:BoundField DataField="IncLevel" HeaderText="IncLevel" ReadOnly="true"/>
                    <asp:BoundField DataField="IncENDDate" HeaderText="IncENDDate" ReadOnly="true" />

                    <!-- Possible User output messages -->
                    <asp:CommandField HeaderText="Mark resolved" ShowEditButton="true"/>
                    <asp:CommandField HeaderText="Delete incident" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        <asp:Label runat="server" ID="testLabel"></asp:Label>
    </div>
</asp:Content>
