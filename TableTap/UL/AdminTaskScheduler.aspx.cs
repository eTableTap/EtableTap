using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BackGroundWorker.Classes;

namespace TableTap.UL
{
    public partial class AdminTaskScheduler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            EmailQueuing.startEmailNotificationSystem();
        }
    }
}