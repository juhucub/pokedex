using PokedexSecurity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Model;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPokemonGrid();
                LoadProfileFromCookie();
            }
        }
        private void LoadProfileFromCookie()
        {
            string trainerName = null;

            var cookie = Request.Cookies["TrainerProfile"];
            if (cookie != null)
            {
                trainerName = cookie["TrainerName"];
            }
            if (!string.IsNullOrEmpty(trainerName))
            {
                txtTrainerName.Text = trainerName;
                Session["TrainerName"] = trainerName;
                UpdateProfileLabel(trainerName);
            }
        }

        private void LoadPokemonGrid()
        {
            var storage = new PokemonStorage();
            gvPokemon.DataSource = storage.LoadCards();
            gvPokemon.DataBind();
        }

        private void UpdateProfileLabel(string trainerName)
        {
            string lastPokemon = Session["LastPokemonName"] as string;
            lblProfileInfo.Text = $"Welcome, Trainer {trainerName}!" +
                    (lastPokemon != null ?
                    $"Last pokemon added this session: {lastPokemon}"
                    : "You have not added any pokemon this session.");
        }

        protected void filterButton_Click(object sender, EventArgs e) // event of clicking on filter button
        {
            // take input from user
            string name = nameInputTxt.Text.Trim(); 
            string type = typeInputTxt.Text.Trim();
            string level = lvlInputTxt.Text.Trim();

            // create into URL for REST call
            try
            {
                string baseURL = "https://localhost:44304/CardFilterService.svc/filter"; 
                string url = baseURL + "?level=" + Server.UrlEncode(level) + "&type=" + Server.UrlEncode(type) + "&name=" + Server.UrlEncode(name);

                // service call
                WebClient client = new WebClient();
                string xml = client.DownloadString(url);

                // make XML file into dataset for easier sorting
                DataSet cards = new DataSet();
                StringReader reader = new StringReader(xml);
                cards.ReadXml(reader);

                // no cards check
                if (cards.Tables.Count == 0 || cards.Tables[0].Rows.Count == 0)
                {
                    resultLabel.Text = "You have no cards matching your filter criteria.";
                    return;
                }

                // clean format building
                StringBuilder results = new StringBuilder();
                DataTable table = cards.Tables[0];
                foreach(DataRow r in table.Rows)
                {
                    results.Append("<b>Name:</b> " + r["Name"] + "<br/>");
                    results.Append("<b>Type:</b> " + r["Type"] + "<br/>");
                    results.Append("<b>Level:</b> " + r["Level"] + "<br/>");
                    results.Append("<b>Description:</b> " + r["Description"] + "<br/>");
                }
                
                resultLabel.Text = results.ToString();
            }
            catch (FormatException)
            {
                resultLabel.Text = "Please input ONLY integers for level search filter.";
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        protected void visitCounterButton_Click(object sender, EventArgs e)
        {
            // populate label w/ info
            visitCounterLabel.Text = "Total visitors: " + Application["totalVisits"];
            appStartLabel.Text = "Application started at: " + Application["startTime"];
        }

        protected void btnHash_Click(object sender, EventArgs e)
        {
            string input = txtHashInput.Text;
            string hashed = HashSlinger.SlingHash(input);
            lblHashResult.Text = Server.HtmlEncode(hashed);
        }

        protected void btnAddPokemon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                return;

            //If no level selected, start at 1
            int level = 1;
            int.TryParse(txtLevel.Text, out level);
            var storage = new PokemonStorage();
            var existingCards = storage.LoadCards();
            int nextId = existingCards.Any() ? existingCards.Max(p => p.Id) + 1 : 1;

            var newCard = new Pokemon
            {
                Id = nextId,
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Level = level,
                Description = txtDesc.Text.Trim()
            };
            
            storage.AddCard(newCard);

            //Store last added pokemon in a session cookie
            Session["LastPokemonName"] = newCard.Name;

            LoadPokemonGrid();

            // Now refresh the profile label too
            var trainerName = Session["TrainerName"] as string ?? "Guest";
            UpdateProfileLabel(trainerName);
        }

        protected void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string trainerName = txtTrainerName.Text.Trim();
            if (string.IsNullOrEmpty(trainerName))
                return;

            //Save in session cookie
            Session["TrainerName"] = trainerName;

            //Save cookie for 10 minutes
            var cookie = new HttpCookie("TrainerProfile");
            cookie["TrainerName"] = trainerName;
            cookie.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Add(cookie);

            UpdateProfileLabel(trainerName);

            //Lock Submit button for trainer names once you join
            txtTrainerName.ReadOnly = true;
            btnSaveProfile.Enabled = false;
            lblProfileInfo.Text += "(trainer name locked for this session)";
        }

        protected void btnCountByType_Click(object sender, EventArgs e)
        {
            var client = new PokedexService();
            string type = txtTypeFilter.Text.Trim();
            int count = client.GetPokemonCountByType(type);
            lblCountByType.Text = $"Total Pokemon of type '{type}': {count}";
        }

        protected void btnAvgLevel_Click(object sender, EventArgs e)
        {
            var client = new PokedexService();
            double avgLevel = client.GetAveragePokemonLevel();
            lblAvgLevel.Text = $"Average Pokemon Level: {avgLevel:F2}";
        }

        protected void btnRandomPokemon_Click(object sender, EventArgs e)
        {
            var client = new PokedexService();
            string name = client.GetRandomPokemonName();
            lblRandomPokemon.Text = string.IsNullOrEmpty(name) ?
                        "No Pokemon in Pokedex."
                        : $"Random Pokemon: {name}";
        }
    }
}