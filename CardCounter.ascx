<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CardCounter.ascx.cs" Inherits="WebApplication1.CardCounter" %>
<div class="card-counter">
    <h3>My Collection</h3>
    <p>Total Cards: 
        <asp:Label ID="totalCardsLbl" runat="server" Text="0"></asp:Label>
    </p>
    <p>Last Updated: 
        <asp:Label ID="lastUpdatedLbl" runat="server" Text=" "></asp:Label>
    </p>
    <asp:Button ID="Button1" runat="server" Text="Count!" OnClick="Button1_Click" />
</div>
