using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer;
using TableTap.Models;
using TableTap.DataAccessLayer; 
using TableTap.DataAccessLayer.Classes;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as back-end processing when an administrator edits a table in the database
 */

namespace TableTap.UL
{
    public partial class AdminEditTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if a user is an administrator, and only grants an administrator access to this page
            if ((string)Session["loggedUser"] != "admin")
            {
                Response.Redirect("Login.aspx");
            }
        }

        /// <summary>
        /// Searches the database for the relevant value as defined by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchButton_Click(Object sender, EventArgs e)
        {
            string tableID = inptable.Value;

            List<string> record = new List<string>();

            //Sets relevant values from user input
            record = TableDAL.LoadTable(tableID);
            lblTableID.Text = record[0];
            INroomID.Value = record[1];
            inpersonCapacity.Value = record[2];
            inCatagory.Value = record[3];
        }

        /// <summary>
        /// Deletes entry from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void deleteButton_Click(Object sender, EventArgs e)
        {
            TableDAL.deleteTable(lblTableID.Text);
            lblStatus.Text = "deleted";
        }

        /// <summary>
        /// Cancels any pending changes to be made to the room 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelButton_Click(Object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }

        /// <summary>
        /// Saves the changes made by the user and updates the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void saveButton_Click(object sender, EventArgs e)
        {
            string recordID = inptable.Value;
            string roomID = INroomID.Value;
            string capacity = inpersonCapacity.Value;
            string catagory = inCatagory.Value;

            List<string> record = new List<string>();

            //Sets relevant values from user input
            record.Add(recordID);
            record.Add(roomID);
            record.Add(capacity);
            record.Add(catagory);

            //Updates the values in the database for the relevant entry
            TableDAL.ModifyTable(record);

        }
    }
}