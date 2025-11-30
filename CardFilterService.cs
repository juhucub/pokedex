using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using WebApplication1.Model;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CardFilterService
    {
        [OperationContract]
        [WebGet(UriTemplate = "filter?level={level}&type={type}&name={name}", ResponseFormat = WebMessageFormat.Xml)]

        public List<Pokemon> Filter(string name, string type, string level)
        {
            // sanity checks
            if (name == null)
            {
                name = "";
            }

            if (type == null)
            {
                type = "";
            }

            if (level == null)
            {
                level = "";
            }

            name = name.ToLower().Trim(); // lowercase for easier comparison
            type = type.ToLower().Trim();
            level = level.Trim();

            bool levelFilter = !string.IsNullOrEmpty(level);
            int levelVal = 0;
            if (levelFilter && !int.TryParse(level, out levelVal)) // only filter if level is inputted + make sure it is an actual number
            {
                throw new FormatException("Please input an ONLY integers for level. (i.e. 1,2,3...)");
            }


            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Pokedex.xml"); // read from XML database
            System.Xml.XmlDocument card = new System.Xml.XmlDocument(); // the card itself
            card.Load(path);

            List<Pokemon> results = new List<Pokemon>();

            foreach (System.Xml.XmlNode node in card.SelectNodes("//Pokemon")) // cycle through XML
            {
                Pokemon pokemon = new Pokemon
                {
                    Id = int.Parse(node["Id"].InnerText),
                    Name = node["Name"].InnerText,
                    Type = node["Type"].InnerText,
                    Level = int.Parse(node["Level"].InnerText),
                    Description = node["Description"].InnerText
                };

                bool match = true; // tracking flag for matches

                if (name != "" && !pokemon.Name.ToLower().Contains(name)) // no name in search filter case
                {
                    match = false;
                }

                if (type != "" && !pokemon.Type.ToLower().Contains(type)) // no type in search filter case
                {
                    match = false;
                }

                if (levelFilter && pokemon.Level != levelVal) //no level in search filter case
                {
                    match = false;
                }

                if (match) // return results based on filter search
                {
                    results.Add(pokemon);
                }
            }
            return results;
        }
    }
}
