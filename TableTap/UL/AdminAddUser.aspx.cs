using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;

namespace TableTap.UL
{
    public partial class AdminAddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("Login.aspx");
            }
        }


        
        protected void submitButton_Click(object sender, EventArgs e)
        {
            /// <summary>
            ///  CREATED BY HAYDEN BASED ON REGISTER PAGE
            ///  SEE REGISTER PAGE FOR MORE DETAILS
            /// </summary>
            if (Page.IsValid)
            {

                UserModel newUser = new UserModel();

                newUser.Email = inADEmail.Value;
                newUser.Password = inADPassword.Value;
                newUser.FirstName = inADFirstName.Value;
                newUser.LastName = inADLastName.Value;
                newUser.AdminPermission = 0;

                BusinessLayer.UserBL.ProcessAddNewUser(newUser);


                // placeholder for future feature
                string phone = "nope";


                NotifyBL.startAccountNotification(inADEmail.Value, phone, inADFirstName.Value, inADLastName.Value);


                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                Response.Redirect("AdminError.aspx");
            }


        }
    }
}