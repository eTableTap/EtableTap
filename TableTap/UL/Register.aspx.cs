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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



/// <summary>
/// This contains email duplicate checking which has been disabled to to a bug, will return too when I have time - HAYDEN
/// would be good if a new pair of eyes looked at this
/// if the Initiate(fEmail) is disrupted in anyway there are major Jquery errors.
/// </summary>
        protected void registerButton_Click(Object sender, EventArgs e)
        {
            string fEmail = inEmail.Value.ToLower();

            // calls external method returns bool true if email already in database
            bool exists = BusinessLayer.UserBL.emailDuplicateCheck(fEmail);

            if(exists == false)
            {

                Initiate(fEmail);

                    


            }
            else
            {
                 lblStatus.Text = "Email already registered, please use our login page";

            }



        }

        protected void Initiate(string fEmail)
        {


          if (Page.IsValid)
          {



                UserModel newUser = new UserModel();

                newUser.Email = fEmail;
                newUser.Password = inPassword.Value;
                newUser.FirstName = inFirstName.Value;
                newUser.LastName = inLastName.Value;
                newUser.AdminPermission = 0;
                newUser.phoneNum = inPhone.Value;

                BusinessLayer.UserBL.ProcessAddNewUser(newUser);


                NotifyBL.startAccountNotification(fEmail, inPhone.Value, inFirstName.Value, inLastName.Value);


                Response.Redirect("Home.aspx");


          }                                                   

        }










    }
}