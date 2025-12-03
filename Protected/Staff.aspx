<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="WebApplication1.Protected.Staff" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Staff Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Staff Page</h1>
            <p>Welcome, <asp:LoginName ID="currentUser" runat="server" /> to the Admin (Staff) page! Users who have these credentials are able to add other admins. To test this, please logout and sign back in with your new credentials.</p>
            <asp:Label ID="totalLoginLbl" runat="server"></asp:Label> <br/>
            Username: <br/>
            <asp:TextBox ID="userTxt" runat="server" Height="30px" Width="170px"></asp:TextBox> <br/>
            <asp:Label ID="userErrLbl" runat="server" Visible="false"></asp:Label> <br/>

            Password: <br/>
            <asp:TextBox ID="passTxt" runat="server" Height="30px" Width="170px"></asp:TextBox> <br/>
           <asp:Button ID="registerButton" runat="server" Text="Register!" OnClick="registerButton_Click" /> <br/>
        </div>
        <div>
            <br />
            <asp:Button ID="homeButton" runat="server" Text="Home" OnClick="homeButton_Click" /> <br />
            <asp:Button ID="signOutButton" runat="server" Text="Sign Out" OnClick="signOutButton_Click" />
        </div>
    </form>
</body>
</html>
