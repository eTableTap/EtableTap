using System;
using TableTap.BusinessLayer.Classes;
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

                    if (usr == 1)
                    {
                        Session["loggedUser"] = "admin";
                        url = "AdminHome.aspx";
                    }
                    if (usr == 2)
                    {

                        Session["loggedUser"] = "user";
                    }



                    if (Session["LoginFallback"] != null) //returns user to the page they were previously on
                    {
                        url = Session["LoginFallback"].ToString();
                        Session["LoginFallback"] = null;
                    }

                    Response.Redirect(url);
                }
                else
                {
                    loginButton.Text = "Account or Password was incorrect";
                }
                
            }






        }


    }
}