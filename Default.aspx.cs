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

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}