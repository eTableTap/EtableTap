using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;
using TableTap.DataAccessLayer.Classes; //REMOVE

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as back-end processing when an administrator edits a user in the database
 */

namespace TableTap.UL
{
    public partial class AdminEditUser : System.Web.UI.Page    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if a user is an administrator, and only grants an administrator access to this page
            if ((string)Session["loggedUser"] != "admin")
            {
                Response.Redirect("Login.aspx");
            }
        }
        
        /// <summary>
        /// Searches the database for a user, searching by email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchButton_Click(Object sender, EventArgs e)
        {
            UserModel record= new UserModel();

            //If no email is enetered, display an error on the user interface
            if (txbUsername.Value == null) 
            {
                lblStatus.Text = "Please enter a valid Email";
            }
            else
            {
                //Search the database for a user with a matching email 
                record = UserBL.passUserSearch(txbUsername.Value);

                //If no results are found, display an error on the user interface
                if(record == null)
                {
                    lblStatus.Text = "User not found, please try again";
                }
                else
                {
                    //Update display on user interface to reflect record with user values from the database
                    lblUserID.Text = record.UserID.ToString();
                    Email.Value = record.Email;
                    inPassword.Value = record.Password;
                    inFirstName.Value = record.FirstName;
                    inLastName.Value = record.LastName;
                   
                    if(record.AdminPermission == 1)
                    {
                        chkAdmin.Checked = true;
                    }
                    else
                    {
                        chkAdmin.Checked = false;
                    }

                }
            }
        }

        /// <summary>
        /// Save changes to the user record and push to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void saveButton_Click(Object sender, EventArgs e)
        {
            List<string> record = new List<string>();

            //Sets relevant values from user input
            record.Add(lblUserID.Text);
            record.Add(Email.Value);
            record.Add(inPassword.Value);
            record.Add(inFirstName.Value);
            record.Add(inLastName.Value);

            if(chkAdmin.Checked == true)
            {
                record.Add("True");
            }
            else
            {
                record.Add("False");
            }

            bool success = true;

            UserBL.PassInModifyString(record); 

            //Update message to user on display layer, depending on validation outcomes
            if (success == false)
            {
                lblSaveStatus.Text = "Save failed";
            }
            else
            {
                lblSaveStatus.Text = "Saved";
            }

        }

        /// <summary>
        /// Deletes the user record from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void deleteButton_Click(Object sender, EventArgs e)
        {
            UserModel deleteUser = new UserModel();
            
            deleteUser.UserID = (Int32.Parse(lblUserID.Text));

            //Deletes a user from the database
            UserBL.userDelete(deleteUser.UserID);

            //Redirects to the administrator home panel
            Response.Redirect("AdminHome.aspx");
        }

        /// <summary>
        /// Cancels actions pending on user entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelButton_Click(Object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

    }
}