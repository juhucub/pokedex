using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using PokedexSecurity;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        string path;

        protected void Page_Load(object sender, EventArgs e)
        {
            path = Server.MapPath("~/App_Data/Staff.xml");
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string username = userTxt.Text;
            string password = passTxt.Text;
            UserStore store = new UserStore(path);
            UserAccount account;
            string message;

            if (store.ValidateUser(username, password, out account, out message))
            {
                bool persist = keepSignedInBox.Checked;
                FormsAuthentication.SetAuthCookie(account.Username, persist);
                Session["role"] = "staff";
                Session["username"] = account.Username;
                Application.Lock();
                Application["totalLogins"] = ((int)Application["totalLogins"] + 1);
                Application.UnLock();
                Response.Redirect("~/Protected/Staff.aspx");
            }
            else
            {
                if (message == "User not found.")
                {
                    userErrLbl.Text = "Staff user does not exist. Please make sure your credentials are correct or have a current admin create your profile.";
   
                }
                else
                {
                    passErrLbl.Text = message;
                }
            }
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}