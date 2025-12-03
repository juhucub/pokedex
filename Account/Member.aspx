<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="WebApplication1.Account.Member" %>
<%@ Register TagPrefix="uc" TagName="CardCounter" Src="~/CardCounter.ascx" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Member Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Member Page</h1>
            <p>Welcome, <asp:LoginName ID="currentUser" runat="server" /> to the Trainer (Member) page! Here, users can test all the services we have implmented for the Pokedex service. Some tests we have here are adding cards, filering, getting counts, seeing our hash funcion etc. </p>

            <h3>TryIt: Add Pokemon Card</h3>
            Name: <asp:TextBox ID="txtName" runat="server" /><br />
            Type: <asp:TextBox ID="txtType" runat="server" /><br />
            Level: <asp:TextBox ID="txtLevel" runat="server" /><br />
            Description: <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Columns="40" /><br />
            <asp:Button ID="btnAddPokemon" runat="server" Text="Add Pokemon" OnClick="btnAddPokemon_Click" />
            <br /><br />
            <asp:GridView ID="gvPokemon" runat="server" AutoGenerateColumns="true" />

    <hr />
            <h3>TryIt: CardFilter Service (RESTful)</h3>
            <p><b>How To:</b> Input either a card's name, type, and/or level (input boxes in that respective order) to filter through collection. Please press 'Filter!' with nothing in the textboxes for a list of all cards.</p>
            Name: <asp:TextBox ID="nameInputTxt" runat="server" Width="168px" Height="51px"/>  
            Type: <asp:TextBox ID="typeInputTxt" runat="server" Width="168px" Height="51px"/>
            Level: <asp:TextBox ID="lvlInputTxt" runat="server" Width="168px" Height="51px"/>
            <asp:Button ID="filterButton" runat="server" Height="48px" Text="Filter!" Width="146px" OnClick="filterButton_Click" />
            <br />
            <asp:Label ID="resultLabel" runat="server" Text=" "></asp:Label>

    <hr />

            <h3>TryIt: Pokedex Stats (Web Service)</h3>
            <br />
            Type filter:
            <asp:TextBox ID="txtTypeFilter" runat="server" Width="120" />
            <asp:Button ID="btnCountByType" runat="server" Text="Get Count by Type" OnClick="btnCountByType_Click" />
            <asp:Label ID="lblCountByType" runat="server" /><br /><br />
            <asp:Button ID="btnAvgLevel" runat="server" Text="Get Average Level" OnClick="btnAvgLevel_Click" />
            <asp:Label ID="lblAvgLevel" runat="server" /><br /><br />
            <asp:Button ID="btnRandomPokemon" runat="server" Text="Get Random Pokemon" OnClick="btnRandomPokemon_Click" />
            <asp:Label ID="lblRandomPokemon" runat="server" />

    <hr />

            <h3>TryIt: Collection Counter (User Control)</h3>
            <p><b>How To:</b> Press the 'Count!' button and the number of cards should return (based on Pokedex.xml)</p>
            <uc:CardCounter ID="cardCounter" runat="server" />


    <hr />

            <h3>TryIt: Visit Counter (Global.asax)</h3>
            <p><b>How To:</b> When you first hit 'See visits,' only 1 increment will happen. Open an incognito tab while the app runs + paste URL and the count should increment when you check again.</p>
            <asp:Button ID="VisitCounterButton" runat="server" Text="See visits" OnClick="visitCounterButton_Click" Height="41px" Width="214px" /> <br />
            <asp:Label ID="visitCounterLabel" runat="server" Text=" "></asp:Label> <br />
            <asp:Label ID="appStartLabel" runat="server" Text=" "></asp:Label>
    <hr/>
            <h3>TryIt: Hashing Function (DLL)</h3>
            <asp:TextBox ID="txtHashInput" runat="server" Width="300" />
            <asp:Button ID="btnHash" runat="server" Text="Hash String" OnClick="btnHash_Click" />
            <br />
            <asp:Label ID="lblHashResult" runat="server" />

        </div>
        <div>
            <asp:Button ID="homeButton" runat="server" Text="Home" OnClick="homeButton_Click" /><br />
            <asp:Button ID="signOutButton" runat="server" Text="Sign Out" OnClick="signOutButton_Click" />
        </div>
    </form>
</body>
</html>
