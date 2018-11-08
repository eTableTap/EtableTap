using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableTap.UL
{

    public partial class Home : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            /*if (!Request.Browser.IsMobileDevice)
            {
                this.MasterPageFile = "~/UL/Site.Master";
            }*/
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["user"] == null)
            {
                
            }
            else
            {
                loginArea.Visible = false;
            }
        }
    }


}

