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
            string filename = Session["filename"].ToString();


            string imgURL = Session["Login"].ToString();

            string path = ("~/Resources/Images/QR/") + filename + ".png";
            Label1.Text = path;
                
            Image1.ImageUrl = path;

        }

        

    }
}