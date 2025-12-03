using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Text;
using System.IO;
using System.Drawing;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ImageVerifierService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ImageVerifierService.svc or ImageVerifierService.svc.cs at the Solution Explorer and start debugging.
    // Referred to textbook for creating image verifier service
    // Created my own Random string generator 
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ImageVerifierService : IImageVerifierService
    {
        public string GetVerifierString()
        {
            int len = 6; // default length of captcha string
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ23456789?!@$";
            Random rand = new Random();
            string result = "";
            for (int i = 0; i < len; i++)
            {
                result += chars[rand.Next(chars.Length)];
            }

            return result;

        }

        public Stream GetImage(string text)
        {
            if (string.IsNullOrEmpty(text)) // sanity check
            {
                text = "lol it didn't work";
            }
            text = text.ToUpper().Trim(); // make input all caps for simplicity
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            int mapWidth = (int)(text.Length * 25);
            Bitmap bMap = new Bitmap(mapWidth, 40);
            Graphics graph = Graphics.FromImage(bMap);
            graph.Clear(Color.Azure);
            graph.DrawRectangle(new Pen(Color.LightBlue, 0), 0, 0, bMap.Width - 1, bMap.Height - 1);
            Random rand = new Random();
            Pen badPen = new Pen(Color.LightGreen, 0);
            for (int i = 0; i < 100; i++) // random noise pattern
            {
                int x = rand.Next(1, bMap.Width - 1);
                int y = rand.Next(1, bMap.Height - 1);
                graph.DrawRectangle(badPen, x, y, 4, 3);
                graph.DrawEllipse(badPen, x, y, 2, 3);
            }
            char[] charString = text.ToCharArray();
            Font font = new Font("Boopee", 18, FontStyle.Bold);
            Color[] clr = { Color.Black, Color.Red, Color.DarkViolet, Color.Green, Color.DarkOrange, Color.Brown, Color.DarkGoldenrod, Color.Plum };
            for (int i = 0; i < text.Length; i++)
            {
                int d = rand.Next(20, 25);
                int p = rand.Next(1, 15);
                int c = rand.Next(0, 7);
                string str = Convert.ToString(charString[i]);
                Brush b = new System.Drawing.SolidBrush(clr[c]);
                graph.DrawString(str, font, b, 1 + i * d, p);
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0; 
            graph.Dispose();
            bMap.Dispose();
            return ms;
        }
    }
}
