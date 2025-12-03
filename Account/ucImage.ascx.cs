using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        private const string SessionKey = "ImageText";

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                GenerateNewImage();
            }
        }

        protected void newImgButton_Click(object sender, EventArgs e)
        {
            GenerateNewImage();
        }

        private void GenerateNewImage()
        {
            ImageVerifierService svc = new ImageVerifierService();
            string text = svc.GetVerifierString();
            Session[SessionKey] = text;
            ImageVerify.ImageUrl = ResolveUrl("~/ImageVerifierService.svc/image?text=" + Server.UrlEncode(text) + "&t=" + DateTime.Now.Ticks); 
        }

        public bool IsValid(string input)
        {
            string expected = Session[SessionKey] as string;
            if (String.IsNullOrEmpty(expected))
            {
                return false;
            }
            return expected.Equals(input, StringComparison.OrdinalIgnoreCase);
        }
    }
}