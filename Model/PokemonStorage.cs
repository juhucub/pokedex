using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml;

namespace WebApplication1.Model
{
    public class PokemonStorage
    {
        private string GetPath() // read pokemon.xml file
        {
            return Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Pokedex.xml");
        }

        public List<Pokemon> LoadCards() // list out cards for reading
        {
            List<Pokemon> cards = new List<Pokemon>();
            string path = GetPath();
            try
            {
                if (!File.Exists(path)) // sanity check
                {
                    return cards;
                }

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fs);
                fs.Close();

                foreach (XmlNode node in xmlDocument.SelectNodes("//Pokemon")) // go through the file to list the pokemon 
                {
                    Pokemon p = new Pokemon
                    {
                        Id = int.TryParse(node["Id"]?.InnerText, out int id) ? id : 0,
                        Name = node["Name"]?.InnerText,
                        Type = node["Type"]?.InnerText,
                        Level = int.TryParse(node["Level"]?.InnerText, out int lvl) ? lvl : 0,
                        Description = node["Description"]?.InnerText
                    };

                    cards.Add(p);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return cards;
        }

        private void SaveCards(List<Pokemon> cards) // saving card XML
        {
            string path = GetPath();
            XmlTextWriter writer = null;
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                writer = new XmlTextWriter(fs, System.Text.Encoding.Unicode)
                {
                    Formatting = Formatting.Indented
                };
                writer.WriteStartDocument();
                writer.WriteStartElement("Pokedex");
                foreach (Pokemon p in cards)
                {
                    writer.WriteStartElement("Pokemon");
                    writer.WriteElementString("Id", p.Id.ToString());
                    writer.WriteElementString("Name", p.Name);
                    writer.WriteElementString("Type", p.Type);
                    writer.WriteElementString("Level", p.Level.ToString());
                    writer.WriteElementString("Description", p.Description);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            finally
            {
                writer?.Close();
            }
        }

        public void AddCard(Pokemon p)
        {
            List<Pokemon> cards = LoadCards();
            cards.Add(p);
            SaveCards(cards);
        }

    }
}