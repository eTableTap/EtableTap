using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using TableTap.BusinessLayer.Classes;
using System.Drawing;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Text.RegularExpressions;
using System.IO;

namespace TableTap.UL
{
    public partial class Scan : System.Web.UI.Page
    {
        string DBConn;

        protected void Page_Load(object sender, EventArgs e)
        {
            DBConn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            if (!this.IsPostBack)
            {
                if (Request.InputStream.Length > 0)
                {
                    using (StreamReader reader = new StreamReader(Request.InputStream))
                    {
                        string hexString = Server.UrlEncode(reader.ReadToEnd());
                        string imageName = DateTime.Now.ToString("dd-MM-yy hh-mm-ss");
                        string imagePath = string.Format(("~/Images/{0}.png"), imageName);
                        File.WriteAllBytes(Server.MapPath(imagePath), ConvertHexToBytes(hexString));
                        Session["CapturedImage"] = ResolveUrl(imagePath);
                    }
                }
            }
        }

        //when reserve button clicked, (temporarily) displays the qrcodes string (doesn't yet) activate EditAvailability() function
        protected void btnReserve_Click(object sender, EventArgs e)
        {

            //decode("C:\\Users\\kepst\\Source\\Repos\\TableTap\\TableTap\\Images\\test10.png");
            //decode doesn't work properly so is commented out. Photo recognition doesn't work properly

            //var tableManager = new TableManager();
            //tableManager.EditAvailability("mvne439j0d");
        }

        void decode(string image)
        {
            Bitmap qrcode = new Bitmap(image); //make a QRCode via the QRTest page. You might have to change directory to get save file to work

            QRCodeDecoder dec = new QRCodeDecoder();
            textBox2.Text = (dec.Decode(new QRCodeBitmapImage(qrcode)));
        }


        private static byte[] ConvertHexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        [WebMethod(EnableSession = true)]
        public static string GetCapturedImage()
        {
            if(HttpContext.Current.Session["CapturedImage"] == null)
            {
                //do nothing
                return "blah blah blah";
            }
            else
            {
                string url = HttpContext.Current.Session["CapturedImage"].ToString();
                return url;
            }
        }
    }
}