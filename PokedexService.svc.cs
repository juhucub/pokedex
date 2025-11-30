using PokemonSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace pokedex
{
    public class PokedexService : IPokedexService
    {
        private PokemonStorage getStorage()
        {
            string xmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Pokemon.xml");
            return new PokemonStorage(xmlPath);
        }

        public int GetTotalPokemonCount()
        {
            var storage = getStorage();
            return storage.LoadAllPokemonCards().Count;
        }

        public int GetPokemonCountByType(string type)
        {
            var storage = getStorage();
            return storage.LoadAllPokemonCards()
                          .Count(p => p.Type != null &&
                          string.Equals(p.Type, type, StringComparison.OrdinalIgnoreCase));
        }

        public double GetAveragePokemonLevel()
        {
            var storage = getStorage();
            var allCards = storage.LoadAllPokemonCards();
            if (allCards.Count == 0)
                return 0.0;
            return allCards.Average(p => p.Level);
        }

        public string GetRandomPokemonName()
        {
            var storage = getStorage();
            var allCards = storage.LoadAllPokemonCards();
            if (allCards.Count == 0)
                return string.Empty;
            var random = new Random();
            int index = random.Next(allCards.Count);
            return allCards[index].Name;
        }
    }
}