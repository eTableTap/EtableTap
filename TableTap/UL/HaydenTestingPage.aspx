﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HaydenTestingPage.aspx.cs" Inherits="TableTap.UL.HaydenTestingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>test</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
            +--+
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <a href="https://www.google.com/maps/dir/?api=1&destination=Pike+Place+Market+Seattle+WA&travelmode=bicycling">Find Us IOS</a>

        <a href="google.navigation:q=San+Francisco">Navigation to San Francisco</a>  
         <p>
            <input type="email" class="form-control" name="email" id="inEmail"  placeholder="Enter your Email" runat="server"/>

            <input type="tel" class="form-control" id="inPhone" name="inPhone" placeholder="0427669341" title="Please enter a mobile number" pattern="[0-9]{10}" required="required" runat="server" />
      https://www.google.com/maps/dir/?api=1&parameters
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        </p>
        <div>

        </div>
    </form>
</body>
</html>
