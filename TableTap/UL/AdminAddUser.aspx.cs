using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as back-end processing when an administrator user adds a user to the database
 */

namespace TableTap.UL
{
    public partial class AdminAddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if a user is an administrator, and only grants an administrator access to this page
            if ((string)Session["loggedUser"] != "admin")
            {
                Response.Redirect("Login.aspx");
            }
        }
        
        protected void submitButton_Click(object sender, EventArgs e)
        {
            //Uses ASP.NET function IsValid() to test user input and the current error state before proceeding
            if (Page.IsValid)
            {
                UserModel newUser = new UserModel();

                //Sets relevant values from user input
                newUser.Email = inADEmail.Value;
                newUser.Password = inADPassword.Value;
                newUser.FirstName = inADFirstName.Value;
                newUser.LastName = inADLastName.Value;
                newUser.AdminPermission = 0;

                //Adds a new building to the database
                UserBL.ProcessAddNewUser(newUser);

                //Placeholder data for later project exensibility
                string phone = "tempPhoneNumber";
                NotifyBL.startAccountNotification(inADEmail.Value, phone, inADFirstName.Value, inADLastName.Value);

                //Redirects the user to the administrator home panel after processing is completed
                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                //Redirects the user to the administrator home panel after processing is completed
                Response.Redirect("AdminError.aspx");
            }


        }
    }
}