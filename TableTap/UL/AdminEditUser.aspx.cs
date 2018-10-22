using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer;
using TableTap.Models;
using TableTap.DataAccessLayer; //REMOVE



namespace TableTap.UL
{
    public partial class AdminEditUser : System.Web.UI.Page
    {

        //List<string> record = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void searchButton_Click(Object sender, EventArgs e)
        {
            UserModel record= new UserModel();

            if (txbUsername.Value == null)
            {
                lblStatus.Text = "Please enter a valid Email";
            }
            else
            {


                record = UserBL.passUserSearch(txbUsername.Value);

                if(record == null)
                {
                    lblStatus.Text = "User not found, please try again";
                }
                else
                {
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

        protected void saveButton_Click(Object sender, EventArgs e)
        {
            List<string> record = new List<string>();

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
            UserBL.PassInModifyString(record); //REMOVE

            if (success == false)
            {
                lblSaveStatus.Text = "Save failed";
            }
            else
            {
                lblSaveStatus.Text = "Saved";
            }

        }

        protected void deleteButton_Click(Object sender, EventArgs e)
        {
            UserModel deleteUser = new UserModel();

            deleteUser.UserID = (Int32.Parse(lblUserID.Text));
            UserBL.userDelete(deleteUser.UserID);
            Response.Redirect("AdminHome.aspx");
            // bool success = 
            /*
            if (success == false)
            {
                lblSaveStatus.Text = "Failed";
            }
            else
            {
                lblSaveStatus.Text = "Deleted";
                Response.Redirect("AdminEditUser.aspx");
            }
            */
        }

        protected void cancelButton_Click(Object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

    }
}