<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<%@ Register Src="~/CardCounter.ascx" TagPrefix="uc" TagName="CardCounter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Pokedex Web Application (Jacob Gardner - 50% Justin Guerrero - 50%)</h1>
        <p>
            This app lets users add Pokemon cards into an XML-based Pokedex
            and also demonstrates hashing, cookies, session state, card filtering, and collection tracking.
        </p>

        <!-- Application and Components Summary Table -->
        <h2>Application and Components Summary Table</h2>
        <table border="1" style="width:100%; border-collapse: collapse;">
            <tr style="background-color: #f2f2f2;">
                <th>Provider name</th>
                <th>Page / Component type</th>
                <th>Component description</th>
                <th>Implementation</th>
            </tr>

            <!-- Jacob's Components -->
            <tr>
                <td>Jacob Gardner</td>
                <td>ASPX page: Default.aspx</td>
                <td>
                    The public Default Pokedex page.  
                    Hosts TryIts for hashing, Pokemon storage, stats service and profile cookie/session demo.
                    No input parameters, it just displays all the other components.
                </td>
                <td>
                    Web Forms page implemented (Default.aspx and Default.aspx.cs).
                    Calls HashSlinger, PokemonStorage and PokedexService dll methods.
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
                    Used on Default.aspx with TryIt controls below.
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
                    Implemented in PokemonSecurity project (PokemonStorage.cs, PokemonCard.cs).  
                    Used in Default.aspx. 
                    TryIt: add a card and see it appear in the GridView.
                </td>
            </tr>

            <tr>
                <td>Jacob Gardner</td>
                <td>SVC service: PokedexService.svc</td>
                <td>
                    SVC stats service using Pokemon XML database.
                    Methods:  
                    - int GetTotalPokemonCount()
                    - int GetPokemonCountByType(string type)
                    - double GetAveragePokemonLevel() 
                    - string GetRandomPokemonName()
                </td>
                <td>
                    Implemented in PokedexService.cs using PokemonStorage. 
                    Exposed as WCF service.
                </td>
            </tr>

            <tr>
                <td>Jacob Gardner</td>
                <td>Cookie / Session state</td>
                <td>
                    Trainer profile and last-added Pokemon storage.
                    Inputs: trainer name  
                    Outputs: 10 min cookie "TrainerProfile" and label that shows trainer + last Pokemon.
                </td>
                <td>
                    Implemented in _Default.aspx.cs.
                    Uses HttpCookie and Session objects.  
                    TryIt: enter trainer name, click Save Profile, then refresh page.
                </td>
            </tr>

            <!-- Justin's Components -->
            <tr>
                <td>Justin Guerrero</td>
                <td>RESTful Service: CardFilterController</td>
                <td>
                    A filter search that returns a list of cards based on input of name, level, or type.
                    Inputs: name (string), type (string), level (int) - all optional
                    Output: JSON array of matching Pokemon cards
                </td>
                <td>
                    Reworked WordFilter service from Assignment3 to filter cards from Pokedex.xml file in App_Data.
                    Uses Web API routing: /api/CardFilter with query parameters.
                    TryIt below uses input boxes for name, type, and level filtering.
                </td>
            </tr>

            <tr>
                <td>Justin Guerrero</td>
                <td>Global.asax w/ event handler</td>
                <td>
                    Global.asax file with Application_Start and Application_Error event handlers.
                    Tracks site visits and logs errors to App_Data/errors.txt with timestamps and stack traces.
                    Output: Visit count displayed via button click
                </td>
                <td>
                    C# code in Global.asax handles incrementing Application["VisitCount"] counter.
                    Error logging writes to both file and Visual Studio Output window.
                    TryIt: Open incognito tab while app runs to see visit count increment.
                </td>
            </tr>

            <tr>
                <td>Justin Guerrero</td>
                <td>User Control: CardCounter.ascx</td>
                <td>
                    Displays total number of cards in collection and last updated time.
                    No inputs required.
                    Output: Card count (reads from Pokedex.xml) and timestamp
                </td>
                <td>
                    C# code in CardCounter.ascx.cs reads Pokedex.xml from App_Data.
                    Displays count when user clicks "Count!" button.
                    TryIt below shows current collection size.
                </td>
            </tr>
        </table>

        <hr />

        <!-- Jacob's TryIt Sections -->
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

        <hr />

        <h2>Pokedex Stats (Web Service)</h2>
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

        <!-- Justin's TryIt Sections -->
        <h2>TryIt: CardFilter Service (RESTful)</h2>
        <p><b>How To:</b> Input either a card's name, type, and/or level (input boxes in that respective order) to filter through collection. 
           Please look in ~/App_Data/Pokedex.xml for example cards.</p>
        Name: <asp:TextBox ID="nameInputTxt" runat="server" Width="168px" Height="51px"/>  
        Type: <asp:TextBox ID="typeInputTxt" runat="server" Width="168px" Height="51px"/>
        Level: <asp:TextBox ID="lvlInputTxt" runat="server" Width="168px" Height="51px"/>
        <asp:Button ID="FilterButton" runat="server" Height="48px" Text="Filter!" Width="146px" OnClick="filterButton_Click" />
        <br />
        <asp:Label ID="resultLabel" runat="server" Text=" "></asp:Label>

        <hr />

        <h2>TryIt: Visit Counter (Global.asax)</h2>
        <p><b>How To:</b> When you first hit 'See visits,' only 1 increment will happen. Open an incognito tab while the app runs + paste URL and the count should increment when you check again.</p>
        <asp:Button ID="VisitCounterButton" runat="server" Text="See visits" OnClick="visitCounterButton_Click" Height="41px" Width="214px" /> <br />
        <asp:Label ID="visitCounterLabel" runat="server" Text=" "></asp:Label> <br />
        <asp:Label ID="appStartLabel" runat="server" Text=" "></asp:Label>

        <hr />

        <h2>TryIt: Collection Counter (User Control)</h2>
        <p><b>How To:</b> Press the 'Count!' button and the number of cards should return (based on Pokedex.xml)</p>
        <uc:CardCounter ID="cardCounter" runat="server" />

    </div>

</asp:Content>