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
            try
            {
            string URL = Session["QRURL"].ToString();
            string filename = Session["filename"].ToString();


            string imgURL = Session["Login"].ToString();

            string path = ("~/Resources/Images/QR/") + filename + ".png";
            lblURL.Text = URL;
                
            Image1.ImageUrl = path;
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
        }

        

    }
}