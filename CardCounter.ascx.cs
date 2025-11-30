using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls.Resolvers;

namespace WebApplication1
{
    public partial class CardCounter : System.Web.UI.UserControl
    {
        protected string CurrentView { get; private set; }

        protected string AlternateView { get; private set; }

        protected string SwitchUrl { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // load pokedex.xml file
            string path = Server.MapPath("~/App_Data/Pokedex.xml");
            System.Xml.XmlDocument card = new System.Xml.XmlDocument();
            card.Load(path);

            // count total cards
            int count = card.SelectNodes("//Pokemon").Count;
            totalCardsLbl.Text = count.ToString();
            lastUpdatedLbl.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm");
        }
    }
}