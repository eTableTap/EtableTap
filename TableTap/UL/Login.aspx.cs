using System;
using TableTap.BusinessLayer;
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






        }


    }
}