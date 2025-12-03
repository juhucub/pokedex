using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using PokedexSecurity;

namespace WebApplication1.Account
{
    public partial class MemberLogin : System.Web.UI.Page
    {
        string xmlPath;

        protected void Page_Load(object sender, EventArgs e)
        {
            xmlPath = Server.MapPath("~/App_Data/Member.xml");
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string username = userTxt.Text.Trim();
            string password = passTxt.Text;
            UserStore store = new UserStore(xmlPath);

            UserAccount account;
            string message;
            if (store.ValidateUser(username, password, out account, out message))
            {
                bool persist = keepSignedInBox.Checked;
                FormsAuthentication.SetAuthCookie(account.Username, persist);
                Session["role"] = "member";
                Session["username"] = account.Username;

                Response.Redirect("~/Account/Member.aspx");
            }
            else
            {
                if (message == "User not found.")
                {
                    userErrLbl.Text = "User not found. Please register by clicking the link below. Admins must login using the preset login provided in the assignment guidelines.";
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