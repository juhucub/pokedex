using System;
using System.IO;
using System.Linq;
using System.Web.Security;
using System.Xml.Linq;

using PokemonSecurity;

namespace pokedex
{
    public partial class Login : System.Web.UI.Page
    {
        private string MemberXmlPath => Server.MapPath("~/App_Data/Member.xml");

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblStatus.CssClass = "mt-2 d-block text-danger";
            lblStatus.Text = string.Empty;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblStatus.Text = "Username and password are required.";
                return;
            }

            if (!File.Exists(MemberXmlPath))
            {
                lblStatus.Text = "No Trainer profile found. Register first.";
                return;
            }

            //load the xml doc into an XDocument
            var doc = XDocument.Load(MemberXmlPath);
            //Hash the password w/ DLL class function
            string hashed = HashSlinger.SlingHash(password);

            //Find the first <Member> element with matching username and password hash
            var match = doc.Root.Elements("Member")
                .FirstOrDefault(m =>
                string.Equals((string)m.Element("UserName"), username, StringComparison.OrdinalIgnoreCase)
             && string.Equals((string)m.Element("PasswordHash"), hashed, StringComparison.Ordinal));

            if (match != null)
            {
                FormsAuthentication.RedirectFromLoginPage(username, false);
            }
            else
            {
                lblStatus.Text = "Invalid username or password.";
            }
        }
    }
}