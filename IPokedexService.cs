using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace pokedex
{
    [ServiceContract]
    internal interface IPokedexService
    {
        [OperationContract]
        int GetTotalPokemonCount();

        [OperationContract]
        int GetPokemonCountByType(string type);

        [OperationContract]
        double GetAveragePokemonLevel();

        [OperationContract]
        string GetRandomPokemonName();
    }
}
