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

namespace TableTap.UL
{
    public partial class GoogleLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            

            loginWorker();

           




            
        }



        private void loginWorker()
        {

        string token = GoogleUser();


        JavaScriptSerializer decoder = new JavaScriptSerializer();
        GoogleEmail googleUser = decoder.Deserialize<GoogleEmail>(token);

        if (googleUser != null)
        {
            string email = lblEmail.Text = googleUser.data.email;

            UserModel user = UserBL.passUserSearch(email);


                if (user != null)
                {


                    Session["user"] = user;
                    Session["login"] = user.Email;




                    string url = "AdminHome.aspx"; ;

                    if (user.AdminPermission == 1)
                    {
                        Session["loggedUser"] = "admin";

                        url = "AdminHome.aspx";
                    }
                    if (user.AdminPermission == 2)
                    {

                        Session["loggedUser"] = "user";
                    }

                    Response.Redirect(url);

                }
            }


        }

        private string GoogleUser()
        {
            try
            {
                string url = "https://www.googleapis.com/userinfo/email?alt=json";

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






        protected void registerButton_Click(object sender, EventArgs e)
        {



            

            if (Page.IsValid)
            {



                UserModel newUser = new UserModel();

                newUser.Email = lblEmail.Text;
                newUser.Password = inConfirmPassword.Value;
                newUser.FirstName = inFirstName.Value;
                newUser.LastName = inLastName.Value;
                newUser.AdminPermission = 0;
                newUser.phoneNum = inPhone.Value;

                UserBL.ProcessAddNewUser(newUser);

                NotifyBL.startAccountNotification(newUser.Email, inPhone.Value, inFirstName.Value, inLastName.Value);

                Response.Redirect("Home.aspx");


            }
        }

    }
}