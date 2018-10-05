﻿using System;
using TableTap.BusinessLayer;
using TableTap.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TableTap.UL
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void loginButton_Click(object sender, EventArgs e)
        {
            // cleares lables from any previous login attempt
            lblUsername.Text = "";
            lblPassword.Text = "";

            /*
            string password = txbPassword.Value;
            string username = txbUsername.Value;
            int status = UserBL.loginScripting(username, password);
            if(status == 1)
            {

                // 1 = login success
                // this section was used during testing, it has been left incase further tests are needed
                
                    
            }
            else if(status == 2)
            {
                // 2 = password failure
                lblPassword.Text = "Password Incorrect";
            }
            else
            {
                lblUsername.Text = "Email not found";
            }
            */
            if (IsValid)
            {
                UserModel loggedUser = new UserModel();
                loggedUser.Email = txbUsername.Value;
                loggedUser.Password = txbPassword.Value;

                var usr = UserBL.ProcessLogin(loggedUser);
                loginButton.Text = usr.ToString();
                //5 for unknown user, 1 for admin 2 for user
                if (usr != 5)
                {
                    loggedUser = UserBL.getUserByEmailAndPassword(txbUsername.Value, txbPassword.Value);
                    
                

                    Session["user"] = loggedUser;
                    Session["login"] = txbUsername.Value;

                    if (usr == 1)
                    {
                        Session["loggedUser"] = "admin";
                    }
                    if (usr == 2)
                    {

                        Session["loggedUser"] = "user";
                    }

                    Response.Redirect("Home.aspx");
                }
                else
                {
                    loginButton.Text = "Account or Password was incorrect";
                }
                
            }






        }


    }
}