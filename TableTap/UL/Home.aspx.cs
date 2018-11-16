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
    - Facilitates functionality from the homepage 
 */

namespace TableTap.UL
{

    public partial class Home : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            //No content required here
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["user"] == null)
            {
                //Do nothing
            }
            else
            {
                //Make the option to login available
                loginArea.Visible = false;
            }
        }
    }
}

