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
            //Session will make differt options show up on the nav bar
            if ((string)Session["loggedUser"] == "user")
            {
                //Standard user identifier
                loginNavigate.Visible = false;
                adminNavigate.Visible = false;
                logoutNavigate.Visible = true;
                accountNavigate.Visible = true;
                lblNavText.Text = Session["login"].ToString();
            }
            else if ((string)Session["loggedUser"] == "admin")
            {
                //Administrator user identifier
                loginNavigate.Visible = false;
                adminNavigate.Visible = true;
                logoutNavigate.Visible = true;
                accountNavigate.Visible = true;
                lblNavText.Text = Session["login"].ToString();
            }
            else
            {
                //Non-identifiable type
                loginNavigate.Visible = true;
                logoutNavigate.Visible = false;
                accountNavigate.Visible = false;
                adminNavigate.Visible = false;
            }
            
        }
    }
}