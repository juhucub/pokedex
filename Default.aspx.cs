using PokedexSecurity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        private string GetRole()
        {
            return Session["role"] as string;
        }

        protected void memberRegisterButton_Click(object sender, EventArgs e)
        {
            string role = GetRole();
            if (!User.Identity.IsAuthenticated || string.IsNullOrEmpty(role))
            {
                Response.Redirect("~/Account/Register.aspx");
                return;
            }
            if (role == "member")
            {
                Response.Redirect("~/Account/Member.aspx");
            }
            else
            {
                roleErrLbl.Text = "You are logged in as a Staff member and cannot access this!";
                roleErrLbl.Visible = true;
            }
        }

        protected void staffPageButton_Click(object sender, EventArgs e)
        {
            string role = GetRole();
            if (!User.Identity.IsAuthenticated || string.IsNullOrEmpty(role))
            {
                Response.Redirect("~/Login.aspx");
                return;
            }
            if (role == "staff")
            {
                Response.Redirect("~/Protected/Staff.aspx");
            }
            else
            {
                roleErrLbl.Text = "You are logged in as a Member and cannot access this!";
                roleErrLbl.Visible = true;
            }
        }

        protected void memberLoginButton_Click(object sender, EventArgs e)
        {
            string role = GetRole();
            if (!User.Identity.IsAuthenticated || string.IsNullOrEmpty(role))
            {
                Response.Redirect("~/Account/MemberLogin.aspx");
                return;
            }
            if (role == "member")
            {
                roleErrLbl.Text = "You are already logged in as a member and cannot access this!";
                roleErrLbl.Visible = true; ;
            }
            else
            {
                roleErrLbl.Text = "You are logged in as a Staff member and cannot access this!";
                roleErrLbl.Visible = true;
            }
        }

        protected void staffLoginButton_Click(object sender, EventArgs e)
        {
            string role = GetRole();
            if (!User.Identity.IsAuthenticated || string.IsNullOrEmpty(role))
            {
                Response.Redirect("~/Login.aspx");
                return;
            }
            if (role == "staff")
            {
                roleErrLbl.Text = "You are already logged in as a Staff member and cannot access this!";
                roleErrLbl.Visible = true;
            }
            else
            {
                roleErrLbl.Text = "You are logged in as a Member and cannot access this!";
                roleErrLbl.Visible = true;
            }
        }

        protected void memberPageBtn_Click(object sender, EventArgs e)
        {
            string role = GetRole();
            if (!User.Identity.IsAuthenticated || string.IsNullOrEmpty(role))
            {
                Response.Redirect("~/Account/MemberLogin.aspx");
                return;
            }
            if (role == "member")
            {
                Response.Redirect("~/Account/Member.aspx");
            }
            else
            {
                roleErrLbl.Text = "You are logged in as a Staff member and cannot access this!";
                roleErrLbl.Visible = true;
            }
        }
    }
}