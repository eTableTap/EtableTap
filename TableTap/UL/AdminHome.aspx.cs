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
    - Serves as a the back-end for the administrator landing page / 'admin panel', and provides validation and functionality to
        features such as edit / add / remove - users / tables / rooms / buildings
 */

namespace TableTap.UL
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if a user is an administrator, and only grants an administrator access to this page
            if (Session["user"] == null)
            {
                string url = Request.Url.AbsoluteUri;
                Session["LoginFallback"] = url;
                Response.Redirect("Login.aspx");
            }
            if ((string)Session["loggedUser"] != "admin") 
            {
                Response.Redirect("home.aspx");
            }

        }

        /// <summary>
        /// Included to indicate the potential extension of features for the project.
        /// Would otherwise redirect to Edit Buildings page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EditBuildingButton_Click(Object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Redirects to Add User page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addUserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddUser.aspx");
        }

        /// <summary>
        /// Redirects to Edit User page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void userButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminEditUser.aspx");
        }

        /// <summary>
        /// Redirects to Edit Table page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tableButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminEditTable.aspx");
        }

        /// <summary>
        /// Redirects to Print QR page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void printQRButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPrintQR.aspx");
        }

        /// <summary>
        /// Redirects to Add Building page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddBuildingButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddBuilding.aspx");
        }

        /// <summary>
        /// Included to indicate the potential extension of features for the project.
        /// Would otherwise redirect to a Room page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void roomButton_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Redirects to Add Room page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnaddRoom_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddRoom.aspx");
        }

        /// <summary>
        /// Redirects to add Table page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddTableButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddTable.aspx");
        }

        /// <summary>
        /// Redirects to Tasks Scheduler page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void scheduledButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminTaskScheduler.aspx");
        }

        /// <summary>
        /// Redirects to Incidence page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void incidentButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminIncidence.aspx");
        }

        /// <summary>
        /// Included to indicate the potential extension of features for the project.
        /// Would otherwise redirect to the Add Notification page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddNotificationButton_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Included to indicate the potential extension of features for the project.
        /// Would otherwise redirect to the Manage Notifications page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ManageNotificationsButton_Click(object sender, EventArgs e)
        {
        }
    }
}