using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;



namespace TableTap.UL
{
    public partial class QRtest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


        }

        protected void QRButton_Click(object sender, EventArgs e)
        {
            //You need MessagingToolkit.QRCode installed on your NuGet packages
            //Uses MessagingToolkit.QRCode.Codec;
            //     MessagingToolkit.QRCode.Codec.Data;


            QRCodeEncoder encoder = new QRCodeEncoder();

            string sInput;
            sInput = TextBox1.Text;
            Bitmap img = encoder.Encode(sInput);

            Response.ContentType = "image/png";
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);

            //Change to your own location if you want to store a copy-- not needed
  ///          img.Save("C:\\Users\\kepst\\Desktop\\LastQRCodeCreated.png", ImageFormat.Png);
            QRImage.ImageUrl = "LastQRCodeCreated.png";
        }
    }

}