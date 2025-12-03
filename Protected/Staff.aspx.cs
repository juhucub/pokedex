using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using PokedexSecurity;

namespace WebApplication1.Protected
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object val = Application["totalLogins"];
                totalLoginLbl.Text = "Total logins: " + val.ToString();
            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/App_Data/Staff.xml");
            var userStore = new UserStore(path);

            string message;
            bool success = userStore.CreateUser(userTxt.Text, passTxt.Text, out message);

            userErrLbl.Text = message;
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void signOutButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Server.Transfer("~/Default.aspx");
        }
    }
}