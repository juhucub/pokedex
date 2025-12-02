<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedex._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
            <h1>Pokedex Web Application (Jacob Gardner- 50% Justin Guerrero - 50%)</h1>
            <p>
                This app lets users add Pokemon cards into an XML-based Pokedex
                and also demonstrates hashing, cookies, and session cookies state.
            </p>

             <h2>User Accounts (Signup &amp; Login)</h2>
            <asp:Label ID="lblAuthStatus" runat="server" />
            <h3>Signup</h3>
            Username: <asp:TextBox ID="txtSignupUsername" runat="server" />
            Password: <asp:TextBox ID="txtSignupPassword" runat="server" TextMode="Password" />
            <asp:Button ID="btnSignup" runat="server" Text="Create Account" OnClick="btnSignup_Click" />
            <br />
            <asp:Label ID="lblSignupStatus" runat="server" /><br />

            <h3>Login</h3>
            Username: <asp:TextBox ID="txtLoginUsername" runat="server" />
            Password: <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            <asp:Label ID="lblLoginStatus" runat="server" />

            <h3>Password Change</h3>
            Current Password: <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" />
            New Password: <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" />
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
            <br />
            <asp:Label ID="lblChangePasswordStatus" runat="server" /><br />


            <h2>TryIt: Hashing Function (DLL)</h2>
            <asp:TextBox ID="txtHashInput" runat="server" Width="300" />
            <asp:Button ID="btnHash" runat="server" Text="Hash String" OnClick="btnHash_Click" />
            <br />
            <asp:Label ID="lblHashResult" runat="server" />

            <hr />

            <h2>Add Pokemon Card</h2>
            Name: <asp:TextBox ID="txtName" runat="server" /><br />
            Type: <asp:TextBox ID="txtType" runat="server" /><br />
            Level: <asp:TextBox ID="txtLevel" runat="server" /><br />
            Description: <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Rows="3" Columns="40" /><br />
            <asp:Button ID="btnAddPokemon" runat="server" Text="Add Pokemon" OnClick="btnAddPokemon_Click" />
            <br /><br />
            <asp:GridView ID="gvPokemon" runat="server" AutoGenerateColumns="true" />

            <hr />

            <h2>User Profile (Cookie & Session)</h2>
            Preferred Trainer Name:
            <asp:TextBox ID="txtTrainerName" runat="server" />
            <asp:Button ID="btnSaveProfile" runat="server" Text="Save Profile" OnClick="btnSaveProfile_Click" />
            <br />
            <asp:Label ID="lblProfileInfo" runat="server" />

            <h2>Pokedex Stats (Web Service)</h2>
            <asp:Button ID="btnTotal" runat="server" Text="Get Total Pokemon"
                OnClick="btnTotal_Click" />
            <asp:Label ID="lblTotal" runat="server" /><br /><br />
            Type filter:
            <asp:TextBox ID="txtTypeFilter" runat="server" Width="120" />
            <asp:Button ID="btnCountByType" runat="server" Text="Get Count by Type"
                OnClick="btnCountByType_Click" />
            <asp:Label ID="lblCountByType" runat="server" /><br /><br />
            <asp:Button ID="btnAvgLevel" runat="server" Text="Get Average Level"
                OnClick="btnAvgLevel_Click" />
            <asp:Label ID="lblAvgLevel" runat="server" /><br /><br />
            <asp:Button ID="btnRandomPokemon" runat="server" Text="Get Random Pokemon"
                OnClick="btnRandomPokemon_Click" />
            <asp:Label ID="lblRandomPokemon" runat="server" />

        <h2>Application and Components Summary Table</h2>

<table border="1">
    <tr>
        <th>Provider name</th>
        <th>Page / Component type</th>
        <th>Component description</th>
        <th>Implementation</th>
    </tr>

    <tr>
        <td>Jacob Gardner</td>
        <td>ASPX page: Default.aspx</td>
        <td>
            The public Default Pokedex page.  
            Hosts TryIts for hashing, Pokemon storage, stats service and profile cookie/session demo
            No input parameters, it just displays all the other components
        </td>
        <td>
            Web Forms page implemented (Default.aspx and Default.aspx.cs)
            Calls HashSlinger, PokemonStorage and PokedexService dll methods
        </td>
    </tr>

    <tr>
        <td>Jacob Gardner</td>
        <td>DLL: PokemonSecurity.HashSlinger</td>
        <td>
            Hashing function.  
            Input: string
            Output: hashed string 
        </td>
        <td>
            Implemented in PokemonSecurity project (HashSlinger.cs). 
            Used on Default.aspx wit TryIt controls
        </td>
    </tr>

    <tr>
        <td>Jacob Gardner</td>
        <td>DLL: PokemonStorage / PokemonCard</td>
        <td>
            XML database management for Pokemon cards.  
            Inputs: Name, Type, Level, Description 
            Output: writes to App_Data/Pokemon.xml and displays all cards in GridView
        </td>
        <td>
            Implemented in PokemonSecurity project (PokemonStorage.cs, PokemonCard.cs)  
            Used in Default.aspx 
            TryIt: add a card and see it appear in the GridView
        </td>
    </tr>

    <tr>
        <td>Jacob Gardner</td>
        <td>SVC service: PokedexService.svc</td>
        <td>
            SVC stats service using Pokemon XML database
            Methods:  
            - int GetTotalPokemonCount()
            - int GetPokemonCountByType(string type)
            - double GetAveragePokemonLevel() 
            - string GetRandomPokemonName()
        </td>
        <td>
            Implemented in PokedexService.cs using PokemonStorage 
            Exposed as WCF service 
        </td>
    </tr>

    <tr>
        <td>Jacob Gardner</td>
        <td>Cookie / Session state</td>
        <td>
            Trainer profile and last-added Pokemon storage
            Inputs: trainer name  
            Outputs: 10 min cookie "TrainerProfile" and label that shows trainer + last Pokemon.
        </td>
        <td>
            Implemented in _Default.aspx.cs
            Uses HttpCookie and Session objects.  
            TryIt: enter trainer name, click Save Profile, then refresh page.
        </td>
    </tr>
</table>
        </div>

</asp:Content>
