<%@ Page Title="" Language="C#" MasterPageFile="~/UL/Site.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="TableTap.UL.Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="jumbotron">
            <h2>Table list</h2>

            <div class="form-group">
                    <asp:Label runat="server" ID="lblStatus" class="cols-sm-2 control-label" text="will update"></asp:Label>
					
			</div>

            <asp:ListBox runat="server" ID="listboxTest"></asp:ListBox>

            <div class="form-group ">
					<asp:Button type="button" ID="btnBook" Text="Book Table" class="btn btn-primary btn-lg btn-block login-button" runat="server" />
                    <asp:DropDownList runat="server" ID="hourDropdown" ></asp:DropDownList>
			</div>

        </div>
    </div>
</asp:Content>
