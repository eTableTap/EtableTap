using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;
using Hangfire;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Registers a user
 */

namespace TableTap.UL
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nothing to perform here
        }
        
        /// <summary>
        /// Registers the user with input details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void registerButton_Click(Object sender, EventArgs e)
        {
            string fEmail = inEmail.Value.ToLower();

            //Returns bool true if email already in database
            if(UserBL.emailDuplicateCheck(fEmail))
            {
                lblStatus.Text = "Email already registered, please use our login page";
            }
            else
            {    
                Initiate(fEmail);
            }
        }

        /// <summary>
        /// Starts registration process
        /// </summary>
        /// <param name="fEmail"></param>
        protected void Initiate(string fEmail)
        {
          if (Page.IsValid)
          {
                UserModel newUser = new UserModel();

                //Stores details as supplied by user
                newUser.Email = fEmail.ToLower();
                newUser.Password = inPassword.Value;
                newUser.FirstName = inFirstName.Value;
                newUser.LastName = inLastName.Value;
                newUser.AdminPermission = 0;
                newUser.phoneNum = inPhone.Value;

                //Adds new user to database
                UserBL.ProcessAddNewUser(newUser);

                NotifyBL.startAccountNotification(fEmail, inPhone.Value, inFirstName.Value, inLastName.Value);

                Response.Redirect("Home.aspx");
          }    
        }
    }
}