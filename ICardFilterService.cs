using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PokedexSecurity;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICardFilterService" in both code and config file together.
    [ServiceContract]
    public interface ICardFilterService
    {
        [OperationContract]
        [WebGet(UriTemplate = "filter?level={level}&type={type}&name={name}", ResponseFormat = WebMessageFormat.Xml)]
        List<Pokemon> Filter(string level, string type, string name);
    }
}
