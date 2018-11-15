using Hangfire;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer;
using TableTap.Models;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using TableTap.BackGroundWorker.Classes;
//// ---------------------------------------------------------------------------- \\\\\

    
    
    
/// <summary>
/// This page is a feature testing page, it automatically redirects you
///  the user layer when deployed to the server
/// </summary>



namespace TableTap.UL
{
    public partial class TesterHeaderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// Response.Redirect("/UL/Home.aspx");
        }
    }
}