using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableTap.UL
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* session will make differt options show up on the nav bar ---- need to add admin
            if ((string)Session["loggedUser"] == "user")
            {
                loginNav.Visible = false;
                logoutNav.Visible = true; 
                accountNav.Visible = true; 
            }
            else
            {
                loginNav.Visible = true;
                logoutNav.Visible = false;
                accountNav.Visible = false;
            }
            */
        }
    }
}