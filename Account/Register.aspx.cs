using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PokedexSecurity;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            if (!string.Equals(passTxt.Text, confirmPassTxt.Text)) // password match check
            {
                passErrLbl.Text = "Error: passwords do not match.";
                passErrLbl.Visible = true;
                return;
            }
            passErrLbl.Visible = false;

            if (!VerifyControl.IsValid(verifyTxt.Text)) // image verifier check
            {
                verifyErrLbl.Text = "Error: input does not match, please try again.";
                verifyErrLbl.Visible = true;
                return;
            }
            verifyErrLbl.Visible = false;

            string path = Server.MapPath("~/App_Data/Member.xml");
            UserStore storage = new UserStore(path);
            string message;
            bool success = storage.CreateUser(userTxt.Text, passTxt.Text, out message); // add new user

            if (!success) // if failed, return reason
            {
                userErrLbl.Text = message;
                userErrLbl.Visible = true;
                return;
            }
            userErrLbl.Visible = false;

            Response.Redirect("~/Account/MemberLogin.aspx"); // redirect to login once account is created.
        }

        protected void homeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}