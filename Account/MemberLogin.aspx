<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberLogin.aspx.cs" Inherits="WebApplication1.Account.MemberLogin" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Member Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login as a Trainer Here!</h2>
            <h3>Description:</h3>
            Users will login using credentials they created at Registration to test features such as filtering, adding cards, and seeing card stats. <br/>
            Username: <br/>
            <asp:TextBox ID="userTxt" runat="server" Height="40px" Width="260px"></asp:TextBox> <br/>
            <asp:Label ID="userErrLbl" runat="server" Visible="false"></asp:Label> <br/>

            Password: <br/>
            <asp:TextBox ID="passTxt" runat="server" Height="40px" Width="260px" TextMode="Password"></asp:TextBox> <br/>
            <asp:Label ID="passErrLbl" runat="server" Visible="false"></asp:Label> <br />
            <asp:Button ID="loginButton" runat="server" Text="Login!" OnClick="loginButton_Click" /> 
            <asp:CheckBox ID="keepSignedInBox" runat="server" Text="Keep me signed in" /> <br/>
        </div>
        <div>
            New user? <a href="Register.aspx">Sign up here!</a> <br/>
            <asp:Button ID="homeButton" runat="server" Text="Home" OnClick="homeButton_Click" />
        </div>
    </form>
</body>
</html>
