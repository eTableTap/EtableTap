using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as back-end processing  for the login service
 */

namespace TableTap.UL
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Deletes all session data, effectively removing any user logged in
            Session.Contents.RemoveAll();
            //Redirects home after logout process complete
            Response.Redirect("Home.aspx");
        }
    }
}