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

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Facilitates the viewing / access of the QR code
 */

namespace TableTap.UL
{
    public partial class PrintPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Attempts to display the QR code, else display error
            try
            {
                string URL = Session["QRURL"].ToString();
                string filename = Session["filename"].ToString();

                string imgURL = Session["Login"].ToString();

                //Generates path of the QR code
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