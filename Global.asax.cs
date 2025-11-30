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


namespace WebApplication1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            // counter for number of site visits + date/time
            Application["totalVisits"] = 0;
            Application["startTime"] = DateTime.Now.ToString();
           
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["totalVisits"] = (int)Application["totalVisits"] + 1; // increment count per visit
            Application.UnLock(); 
        }

        
    }
}