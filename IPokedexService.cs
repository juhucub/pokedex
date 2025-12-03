using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPokedexService" in both code and config file together.
    [ServiceContract]
    public interface IPokedexService
    {
        [OperationContract]
        int GetPokemonCountByType(string type);

        [OperationContract]
        double GetAveragePokemonLevel();

        [OperationContract]
        string GetRandomPokemonName();
    }
}
