using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PokemonSecurity;
namespace pokedex
{
    public partial class _Default : Page
    {
        private string PokemonXmlPath => Server.MapPath("~/App_Data/Pokemon.xml");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadPokemonGrid();
                LoadProfileFromCookie();
            }
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
            
            var newCard = new PokemonCard
            {
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Level = level,
                Description = txtDesc.Text.Trim()
            };
            var storage = new PokemonStorage(PokemonXmlPath);
            storage.SavePokemonCard(newCard);

            //Store last added pokemon in a session cookie
            Session["LastPokemonName"] = newCard.Name;

            LoadPokemonGrid();

            // Now refresh the profile label too
            var trainerName = Session["TrainerName"] as string ?? "Guest";
            UpdateProfileLabel(trainerName);

        }

         private void LoadPokemonGrid()
        {
            var storage = new PokemonStorage(PokemonXmlPath);
            gvPokemon.DataSource = storage.LoadAllPokemonCards();
            gvPokemon.DataBind();
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

        private void UpdateProfileLabel(string trainerName)
        {
           string lastPokemon = Session["LastPokemonName"] as string;
            lblProfileInfo.Text = $"Welcome, Trainer {trainerName}!" +
                    (lastPokemon != null ? 
                    $"Last pokemon added this session: {lastPokemon}"
                    : "You have not added any pokemon this session.");
        }

        protected void btnTotal_Click(object sender, EventArgs e)
        {
            var client = new PokedexService();

            int total = client.GetTotalPokemonCount();
            lblTotal.Text = $"Total Pokemon in Pokedex: {total}";
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
                        :$"Random Pokemon: {name}";
        }
    }
}