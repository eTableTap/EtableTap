using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Windows;
using System.IO;

namespace TableTap.UL
{
    public partial class PrintPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string URL = Session["QRURL"].ToString();
            Session["QRURL"] = null;

            string imgURL = Session["Login"].ToString();

            makeQR(URL);
        }

        public void makeQR(string URL)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();
            MemoryStream stream = new MemoryStream();
            Bitmap img = encoder.Encode(URL);



            System.Drawing.Image i = (System.Drawing.Image)img;

   

           
            

        }
    }
}