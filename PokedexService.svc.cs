using PokedexSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using PokedexSecurity;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PokedexService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PokedexService.svc or PokedexService.svc.cs at the Solution Explorer and start debugging.
    public class PokedexService : IPokedexService
    {
        private PokemonStorage GetStorage()
        {
            string xmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Pokemon.xml");
            return new PokemonStorage(xmlPath);
        }

        public int GetPokemonCountByType(string type)
        {
            var storage = GetStorage();
            return storage.LoadAllPokemonCards()
                          .Count(p => p.Type != null &&
                          string.Equals(p.Type, type, StringComparison.OrdinalIgnoreCase));
        }

        public double GetAveragePokemonLevel()
        {
            var storage = GetStorage();
            var allCards = storage.LoadAllPokemonCards();
            if (allCards.Count == 0)
                return 0.0;
            return allCards.Average(p => p.Level);
        }

        public string GetRandomPokemonName()
        {
            var storage = GetStorage();
            var allCards = storage.LoadAllPokemonCards();
            if (allCards.Count == 0)
                return string.Empty;
            var random = new Random();
            int index = random.Next(allCards.Count);
            return allCards[index].Name;
        }
    }
}
