using PokedexSecurity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Schema;


namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e) // global event handler that will seed the TA login credentials should they be missing
        {
            string path = Server.MapPath("~/App_Data/Staff.xml");
            var store = new UserStore(path);
            string message;
            UserAccount taAccount = store.GetUser("TA");
            if (taAccount == null)
            {
                store.CreateUser("TA", "Cse445!", out message);
            }

            Application["totalLogins"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            
        }

        
    }
}