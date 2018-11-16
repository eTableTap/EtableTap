<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="AdminIncidence.aspx.cs" Inherits="TableTap.UL.AdminIncidence" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">
        
        <asp:GridView GridLines="None" ID="IncidentGrid" runat="server" AutoGenerateColumns="False" OnRowEditing="IncidentRowEditing" OnRowDeleting="IncidentRowDeleting" OnRowUpdating="IncidentRowUpdating"> 
                <Columns>
                    <asp:BoundField DataField="IncidentID" HeaderText="incidenceID" ReadOnly="true" />
                    <asp:BoundField DataField="incDate" HeaderText="incDate" ReadOnly="true" />
                    <asp:BoundField DataField="buildingID" HeaderText="buildingID" ReadOnly="true" />
                    <asp:BoundField DataField="roomID" HeaderText="roomID" ReadOnly="true" />
                    <asp:BoundField DataField="tableID" HeaderText="tableID" ReadOnly="true" />
                    <asp:BoundField DataField="userID" HeaderText="userID" ReadOnly="true" />
                    <asp:BoundField DataField="IncLevel" HeaderText="IncLevel" ReadOnly="true"/>
                    <asp:BoundField DataField="IncENDDate" HeaderText="IncENDDate" ReadOnly="true" />

                    

                    <asp:CommandField HeaderText="Mark resolved" ShowEditButton="true"/>
                    <asp:CommandField HeaderText="Delete incident" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        <asp:Label runat="server" ID="testLabel"></asp:Label>
</div>
</asp:Content>
