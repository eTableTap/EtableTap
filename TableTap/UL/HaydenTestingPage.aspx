<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HaydenTestingPage.aspx.cs" Inherits="TableTap.UL.HaydenTestingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
            
        </div>
         <p>
            <input type="email" class="form-control" name="email" id="inEmail"  placeholder="Enter your Email" runat="server"/>
            <input type="text" class="form-control" name="phone" id="phonenum"  placeholder="Enter your phonenumber" runat="server"/>
      
            <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
        </p>
    </form>
</body>
</html>
