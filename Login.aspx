<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokedex.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Member Login</h1>
    <p>Enter your member credentials created through the registration form. Passwords are validated using the HashSlinger DLL against App_Data/Member.xml.</p>
    <div class="card p-3" style="max-width: 480px;">
        <div class="mb-2">
            <asp:Label runat="server" AssociatedControlID="txtUsername" Text="Username" />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="135px" />
        </div>
        <div class="mb-2">
            <asp:Label runat="server" AssociatedControlID="txtPassword" Text="Password" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Width="135px" />
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" Width="58px" />
        <asp:Label ID="lblStatus" runat="server" CssClass="mt-2 d-block" />
    </div>
    <p class="mt-3">New here? Visit the <a runat="server" href="~/Member">Member page</a> to sign-up.</p>
</asp:Content>