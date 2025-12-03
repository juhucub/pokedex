<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>
<%@ Register TagPrefix="uc" TagName="ImageVerify" Src="~/Account/ucImage.ascx"%>

<!DOCTYPE html>

<head runat="server">
    <title>Member Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register as a new Trainer Here!</h2>
            Username: <br/>
            <asp:TextBox ID="userTxt" runat="server" Height="40px" Width="260px"></asp:TextBox> <br/>
            <asp:Label ID="userErrLbl" runat="server" Visible="false"></asp:Label> <br/>

            Password: <br/>
            <asp:TextBox ID="passTxt" runat="server" Height="40px" Width="260px"></asp:TextBox> <br/>

            Confirm Password: <br />
            <asp:TextBox ID="confirmPassTxt" runat="server" Height="40px" Width="260px"></asp:TextBox> <br/>
            <asp:Label ID="passErrLbl" runat="server" Visible="false"></asp:Label> <br/>

            <uc:ImageVerify ID="VerifyControl" runat="server"></uc:ImageVerify> <br/>
            Please enter the text above to verify you are human: <br/>
            <asp:TextBox ID="verifyTxt" runat="server" Height="40px" Width="260px"></asp:TextBox> <br />
            <asp:Label ID="verifyErrLbl" runat="server" Visible="false"></asp:Label> <br/>

            <asp:Button ID="registerButton" runat="server" Text="Register!" OnClick="registerButton_Click" style="margin:15px;"/> <br />
            <asp:Button ID="homeButton" runat="server" Text="Home" OnClick="homeButton_Click" style="margin:15px;"/>
        </div>
    </form>
</body>
</html>
