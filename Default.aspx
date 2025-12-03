<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<%@ Register Src="~/CardCounter.ascx" TagPrefix="uc" TagName="CardCounter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h1>Pokedex Web Application (Jacob Gardner - 50% Justin Guerrero - 50%)</h1>
        <p>
            This app lets users add Pokemon cards into an XML-based Pokedex
            and also demonstrates hashing, cookies, session state, card filtering, and collection tracking.
        </p>
        <div>
            <h2>Welcome!</h2>
            <asp:Button ID="memberRegisterButton" runat="server" Text="Member Registration" Width="299px" style="margin:15px;" OnClick="memberRegisterButton_Click"/> <asp:Button ID="staffPageButton" runat="server" Text="Staff Page" Width ="299px" style="margin:15px;" OnClick="staffPageButton_Click"/><br/>
            <asp:Button ID="memberLoginButton" runat="server" Text="Member Login" Width ="299px" style="margin:15px;" OnClick="memberLoginButton_Click"/> <asp:Button ID="staffLoginButton" runat="server" Text="Staff Login" Width ="299px" style="margin:15px;" OnClick="staffLoginButton_Click"/> <br/>
            <asp:Button ID="memberPageBtn" runat="server" Text="Member Page" style="margin:15px;" Width ="299px" OnClick="memberPageBtn_Click"/> <br />
            <asp:Label ID="roleErrLbl" runat="server" Visible="false" ></asp:Label>
    
        </div>
        <h2>Application and Components Summary Table</h2>
        <table border="1" style="width:100%; border-collapse: collapse;">
            <tr style="background-color: lightgrey">
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
                    Hosts the Applications and Components Summary Table + Member/Staff Login, Member Registration, and Staff Page buttons
                    No input, simply redirects and acts as a dictionary
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
            <tr>
                <td>Justin Guerrero</td>
                <td>RESTful Service: CardFilterService</td>
                <td>
                    A filter search that returns a list of cards based on input of name, level, or type.
                    Inputs: name (string), type (string), level (int) - all optional
                    Output: list of matching Pokemon cards
                </td>
                <td>
                    Reworked WordFilter service from Assignment3 to filter cards from Pokedex.xml file in App_Data.
                    Uses Web API routing: /api/CardFilter with query parameters.
                    TryIt can be found on the Member Page as a Member feature.
                </td>
            </tr>

            <tr>
                <td>Justin Guerrero</td>
                <td>Global.asax w/ event handler</td>
                <td>
                    Global.asax file with Application_Start handler to seed TA login credentials Seeds TA credentials in Staff.xml if they do not exist already. It also intializes a variable used to keep count of how many times an admin has signed in. Output: a total number of logins from an admin.</td>
                <td>
                    C# code in Global.asax 
                    initializes Application["VisitCount"] counter where it is updated per login in the Login.aspx.cs file .TryIt: Login as an admin and the count within the admin page should update accordingly.</td>
            </tr>

            <tr>
                <td>Justin Guerrero</td>
                <td>User Control/RESTful Service: ucImage.ascx/ImageVerifierService.svc</td>
                <td>
                    A helper/user control that requires new trainers (members) to do an image captcha to register.
                    Input: N/A
                    Output: An image with 6 random chars
                </td>
                <td>
                    Web user control code in ucImage.ascx
                    Image verifier service in ImageVerifierService.svc (followed textbook)
                    Displays an image with 6 random characters similar to the textbook
                    TryIt can be found in Member Registration
                </td>
            </tr>
            <tr>
                <td>Justin Guerrero</td>
                <td>FormsAuthentication: Login, Register, Staff, Member, MemberLogin pages </td>
                <td>The pages used for both staff/member logins, respective staff/member pages, member registration, as well as the code-behind. Logic behind saving these things into XML was done by Jacob Gardner.</td>
                <td>Implementation of all the .aspx pages mentioned above as well as the code-behind for button pushes, updates, redirects, and using Jacob's code to properly store the provided info.</td>
            </tr>
        </table>

        <hr />

        

    </div>

</asp:Content>