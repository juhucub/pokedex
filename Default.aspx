<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<%@ Register Src="~/CardCounter.ascx" TagPrefix="uc" TagName="CardCounter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Pokemon Card Collection Tracker</h1>
            <p class="lead">Track/Manage your Pokemon card collection! You may search for cards using the Pokemon's names, levels, or types.</p>
        </section>

        <div class="row">
            <section class="col-md-12" aria-labelledby="librariesTitle">
                
            <section class="col-md-12" aria-labelledby="gettingStartedTitle">
                <h2><b>Service Directory</b></h2>

                <h3> <b>CardFilter Service: </b></h3>
                <asp:Label ID="serviceLabel1" runat="server" Text="<b>Provider:</b> Justin Guerrero<br />
                    <b>Component Type:</b> RESTful Service<br />
                    <b>Description: </b> A filter search that return a list of cards based off an input of name, level, or type. <br />
                    <b>Resources: </b> Reworked my WordFilter service from Assignment3 to filter cards from an XML file/database. Used for better organization/search<br />"></asp:Label>
                    <asp:Label ID="serviceInputLabels" runat="server" Text="<b>How To: </b> Input either a card's name, type, and/or level (input boxes in that respective order) to filter through collecion. Please look in ~/App_Data/Pokedex.xml for example cards."></asp:Label> <br />
                    <b>TryIt: </b> 
                <asp:TextBox ID="nameInputTxt" runat="server" Width="168px" Height="51px"></asp:TextBox>  
                <asp:TextBox ID="typeInputTxt" runat="server" Width="168px" Height="51px"></asp:TextBox>
                <asp:TextBox ID="lvlInputTxt" runat="server" Width="168px" Height="51px"></asp:TextBox>
                <asp:Button ID="filterButton" runat="server" Height="48px" Text="Filter!" Width="146px" BackColor="White" BorderColor="White" OnClick="filterButton_Click" />
                <br />
                <asp:Label ID="resultLabel" runat="server" Text=" "></asp:Label>

                    
            
            </section>
                <h3><b>Global.asax w/ Event Handler:</b></h3>
                <asp:Label ID="service2Label" runat="server" Text="<b>Provider: </b> Justin Guerrero <br />
                    <b>Component Type: </b> Global.asax w/ event handler <br />
                    <b>Description: </b> A global.asax file that has an event handler for counting the number of site visits <br />
                    <b>Resources: </b> C# code in the global.asax that handles incrementing a counter for visits
                    <b>How To: </b> When you first hit 'See visits,' only 1 increment will happen. Open an incognito tab while the app runs + paste URL and the count should increment when you check again."></asp:Label> <br />
                <asp:Label ID="visitTryItLabel" runat="server" Text="<b>TryIt:</b>"></asp:Label>
                <asp:Button ID="visitCounterButton" runat="server" Text="See visits" OnClick="visitCounterButton_Click" Height="41px" Width="214px" /> <br />
                <asp:Label ID="visitCounterLabel" runat="server" Text=" "></asp:Label> <br />
                <asp:Label ID="appStartLabel" runat="server" Text=" "></asp:Label>

            </section>
            <section class="col-md-12" aria-labelledby="hostingTitle">
                
                <h3><b>User Control:</b></h3>
                <asp:Label ID="serviceLabel3" runat="server" Text="<b>Provider: </b> Justin Guerrero <br />
                    <b>Component Type: </b> User Control<br />
                    <b>Description: </b> A way for user's the see how many cards they currently have in their collection <br />
                    <b>Resources: </b> C# code in CardCounter.ascx. <br />
                    <b>How To: </b> Press the 'Count!' button and the number of cards should return (3)">
                </asp:Label> <br />
                <b>TryIt: </b>
                <uc:CardCounter ID="cardCounter" runat="server" />
            </section>
        </div>
    </main>

</asp:Content>
