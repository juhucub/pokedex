<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Member Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Staff Login</h1>
            <h3>Description:</h3>
            Admins will login using credentials that are preset per the assignment instructions OR the credentials they have added after intial signin. New admins can only added through the Staff page.<br/>
            Username: <br/>
            <asp:TextBox ID="userTxt" runat="server" Height="40px" Width="260px"></asp:TextBox> <br/>
            <asp:Label ID="userErrLbl" runat="server" Visible="false"></asp:Label> <br/>

            Password: <br/>
            <asp:TextBox ID="passTxt" runat="server" Height="40px" Width="260px" TextMode="Password"></asp:TextBox> <br/>
            <asp:Label ID="passErrLbl" runat="server" Visible="false"></asp:Label> <br />
            <asp:Button ID="loginButton" runat="server" Text="Login!" OnClick="loginButton_Click" style="margin:15px;"/> 
            <asp:CheckBox ID="keepSignedInBox" runat="server" Text="Keep me signed in" style="margin:15px;"/> <br/>
        </div>
        <div>
            <asp:Button ID="homeButton" runat="server" Text="Home" OnClick="homeButton_Click" style="margin:15px;"/>
        </div>
    </form>
</body>
</html>
