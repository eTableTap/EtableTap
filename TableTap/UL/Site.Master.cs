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
            // session will make differt options show up on the nav bar ---- need to add admin
            if ((string)Session["loggedUser"] == "user")
            {
                loginNavigate.Visible = false;
                logoutNavigate.Visible = true;
                accountNavigate.Visible = true;
                lblNavText.Text = Session["login"].ToString();
            }
            else
            {
                loginNavigate.Visible = true;
                logoutNavigate.Visible = false;
                accountNavigate.Visible = false;
            }
            
        }
    }
}