using System;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;
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
    - Serves as back-end processing  for the login service
 */

namespace TableTap.UL
{
    public partial class Login : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Logs the user in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void loginButton_Click(object sender, EventArgs e)
        {
            //Clears lables from any previous login attempt
            lblUsername.Text = "";
            lblPassword.Text = "";

            if (IsValid)
            {
                UserModel loggedUser = new UserModel();
                loggedUser.Email = txbUsername.Value.ToLower();
                loggedUser.Password = txbPassword.Value;

                var usr = UserBL.ProcessLogin(loggedUser);
                loginButton.Text = usr.ToString();

                //5 for unknown user, 1 for admin 2 for user
                if (usr != 5)
                {
                    loggedUser = UserBL.getUserByEmailAndPassword(txbUsername.Value.ToLower(), txbPassword.Value);

                    Session["user"] = loggedUser;
                    Session["login"] = txbUsername.Value;

                    string url = "Home.aspx";

                    //If administrator is logged in
                    if (usr == 1)
                    {
                        Session["loggedUser"] = "admin";
                        url = "AdminHome.aspx";
                    }
                    //If standard user is logged in
                    if (usr == 2)
                    {
                        Session["loggedUser"] = "user";
                    }
                    //If failed to recognise user type, returns user to the page they were previously on
                    if (Session["LoginFallback"] != null) 
                    {
                        url = Session["LoginFallback"].ToString();
                        Session["LoginFallback"] = null;
                    }

                    Response.Redirect(url);
                }
                else
                {
                    //Incorrect details error
                    loginButton.Text = "Account or Password was incorrect";
                }                
            }
        }
    }
}