using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;
using System.Security.Cryptography;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as back-end processing when an administrator edits a user in the database
 */

namespace TableTap.UL
{
    public partial class GoogleLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Commences google login
            loginWorker(); 
        }

        /// <summary>
        /// Uses Google token service and validates the users details, providing a successful login if details are correct
        /// </summary>
        private void loginWorker()
        {
            string token = GoogleUser();

            JavaScriptSerializer decoder = new JavaScriptSerializer();
            GoogleEmail googleUser = decoder.Deserialize<GoogleEmail>(token);

            //If the data input is not empty, proceed
            if (googleUser != null)
            {
                string email = lblEmail.Text = googleUser.data.email.ToLower(); //Convert tot lower case
                UserModel user = UserBL.passUserSearch(email); //Acquire the user from the email address from the database
                
                //If the user found is not null, proceed
                if (user != null)
                {
                    Session["user"] = user;
                    Session["login"] = user.Email;

                    string url = "AdminHome.aspx";

                    //Checks if a user is an administrator or standard user, and amends the next valid page to suit
                    if (user.AdminPermission == 1)
                    {
                        Session["loggedUser"] = "admin";
                        url = "AdminHome.aspx";
                    }
                    if (user.AdminPermission == 0)
                    {
                        Session["loggedUser"] = "user";
                    }

                    Response.Redirect(url);
                }
            }
        }

        /// <summary>
        /// From supplied details, attempt to parse as a Google User
        /// </summary>
        /// <returns></returns>
        private string GoogleUser()
        {
            try
            {
                string url = "https://www.googleapis.com/userinfo/email?alt=json";

                //Google specific methods for reading valuees into a Google user
                WebClient wc = new WebClient();
                wc.Headers.Add("Authorization", "OAuth " + Request.QueryString["accessToken"]);
                Stream data = wc.OpenRead(url);
                StreamReader reader = new StreamReader(data);
                string returnedJson = reader.ReadToEnd();
                data.Close();
                reader.Close();

                return returnedJson;
            }
            catch
            {
                return null;

            }
        }

        /// <summary>
        /// Registers the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void registerButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UserModel newUser = new UserModel();

                //Sets relevant values from input data
                newUser.Email = lblEmail.Text;
                newUser.Password = inConfirmPassword.Value;
                newUser.FirstName = inFirstName.Value;
                newUser.LastName = inLastName.Value;
                newUser.AdminPermission = 0;
                newUser.phoneNum = inPhone.Value;

                UserBL.ProcessAddNewUser(newUser); //Adds new user
                NotifyBL.startAccountNotification(newUser.Email, inPhone.Value, inFirstName.Value, inLastName.Value);
                Response.Redirect("Home.aspx"); //Redirects the user back home
            }
        }

    }
}