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
            if (Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void EditBuildingButton_Click(Object sender, EventArgs e)
        {
            Response.Redirect("AdminAddBuilding.aspx");
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
    }
}