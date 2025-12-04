using PokedexSecurity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPokemonGrid();
            }
        }

        private void LoadPokemonGrid()
        {
            string xmlPath = Server.MapPath("~/App_Data/Pokedex.xml");
            var storage = new PokemonStorage(xmlPath);
            gvPokemon.DataSource = storage.LoadAllPokemonCards();
            gvPokemon.DataBind();
        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            string input = txtHashInput.Text;
            string hashed = HashSlinger.SlingHash(input);
            lblHashResult.Text = Server.HtmlEncode(hashed);
        }

        protected void btnRandomPokemon_Click(object sender, EventArgs e)
        {
            var client = new PokedexService();
            string name = client.GetRandomPokemonName();
            lblRandomPokemon.Text = string.IsNullOrEmpty(name) ?
                        "No Pokemon in Pokedex."
                        : $"Random Pokemon: {name}";
        }

        protected void btnAvgLevel_Click(object sender, EventArgs e)
        {
            var client = new PokedexService();
            double avgLevel = client.GetAveragePokemonLevel();
            lblAvgLevel.Text = $"Average Pokemon Level: {avgLevel:F2}";
        }

        protected void btnCountByType_Click(object sender, EventArgs e)
        {
            var client = new PokedexService();
            string type = txtTypeFilter.Text.Trim();
            int count = client.GetPokemonCountByType(type);
            lblCountByType.Text = $"Total Pokemon of type '{type}': {count}";
        }

        protected void filterButton_Click(object sender, EventArgs e)
        {
            string name = nameInputTxt.Text.Trim();
            string type = typeInputTxt.Text.Trim();
            string level = lvlInputTxt.Text.Trim();

            if (!string.IsNullOrEmpty(level))
            {
                int i;
                if (!int.TryParse(level, out i))
                {
                    resultLabel.Text = "Please input ONLY integers for level search filter.";
                    return;
                }
            }

            // create into URL for REST call
            try
            {
                string url = "http://webstrar22.fulton.asu.edu/page0/CardFilterService.svc/filter" + "?name=" + Server.UrlEncode(name) + "&type=" + Server.UrlEncode(type) + "&level=" + Server.UrlEncode(level);

                // service call
                WebClient client = new WebClient();
                string xml = client.DownloadString(url);

                // make XML file into dataset for easier sorting
                DataSet cards = new DataSet();
                StringReader reader = new StringReader(xml);
                try
                {
                    cards.ReadXml(reader);
                }
                finally
                {
                    reader.Dispose();
                }

                // no cards check
                if (cards.Tables.Count == 0 || cards.Tables[0].Rows.Count == 0)
                {
                    resultLabel.Text = "You have no cards matching your filter criteria.";
                    return;
                }

                // clean format building
                StringBuilder results = new StringBuilder();
                DataTable table = cards.Tables[0];
                foreach (DataRow r in table.Rows)
                {
                    results.Append("<b>Name:</b> " + r["Name"] + "<br/>");
                    results.Append("<b>Type:</b> " + r["Type"] + "<br/>");
                    results.Append("<b>Level:</b> " + r["Level"] + "<br/>");
                    results.Append("<b>Description:</b> " + r["Description"] + "<br/>");
                }

                resultLabel.Text = results.ToString();
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void btnAddPokemon_Click(object sender, EventArgs e)
        {
            string xmlPath = Server.MapPath("~/App_Data/Pokedex.xml");

            if (string.IsNullOrWhiteSpace(txtName.Text))
                return;

            //If no level selected, start at 1
            int level = 1;
            int.TryParse(txtLevel.Text, out level);
            var storage = new PokemonStorage(xmlPath);
            var existingCards = storage.LoadAllPokemonCards();
            int nextId = existingCards.Any() ? existingCards.Max(p => p.Id) + 1 : 1;

            var newCard = new Pokemon
            {
                Id = nextId,
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Level = level,
                Description = txtDesc.Text.Trim()
            };

            storage.SavePokemonCard(newCard);

            LoadPokemonGrid();
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void signOutButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Server.Transfer("~/Default.aspx");
        }

        protected void resetPassBtn_Click(object sender, EventArgs e)
        {
            UserStore store = new UserStore(Server.MapPath("~/App_Data/Member.xml"));
            string username = User.Identity.Name;
            string currentPass = currentPassTxt.Text;
            string newPass = newPassTxt.Text;
            string confirmPass = confirmPassTxt.Text;

            if (newPass != confirmPass)
            {
                passChangeErrLbl.Text = "New passwords do not match. Try again.";
                passChangeErrLbl.Visible = true;
                return;
            }

            UserAccount account;
            string message;
            if (!store.ValidateUser(username, currentPass, out account, out message)) 
            {
                passChangeErrLbl.Text = message;
                return;
            }
            if (store.ChangePassword(username,currentPass, newPass, out message)) 
            {
                passChangeErrLbl.Text = message;
            }
            else
            {
                passChangeErrLbl.Text = message;
            }
         
        }
    }
}