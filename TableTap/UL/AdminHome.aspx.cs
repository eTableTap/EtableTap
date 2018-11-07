using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TableTap.UL
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                string url = Request.Url.AbsoluteUri;
                Session["LoginFallback"] = url;
                Response.Redirect("Login.aspx");
            }

            if (Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("home.aspx");
            }

        }

        protected void EditBuildingButton_Click(Object sender, EventArgs e)
        {

        }

        protected void addUserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddUser.aspx");
        }

        protected void userButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminEditUser.aspx");
        }

        protected void tableButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminEditTable.aspx");
        }

        protected void printQRButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPrintQR.aspx");
        }

        protected void AddBuildingButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddBuilding.aspx");
        }

        protected void roomButton_Click(object sender, EventArgs e)
        {

        }

        protected void btnaddRoom_Click(object sender, EventArgs e)
        {

        }

        protected void AddTableButton_Click(object sender, EventArgs e)
        {

        }

        protected void scheduledButton_Click(object sender, EventArgs e)
        {

        }

        protected void AddNotificationButton_Click(object sender, EventArgs e)
        {

        }

        protected void ManageNotificationsButton_Click(object sender, EventArgs e)
        {

        }
    }
}