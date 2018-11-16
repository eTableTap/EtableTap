using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as back-end processing when an administrator user adds a building to the database
 */

namespace TableTap.UL
{
    public partial class AdminAddBuilding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if a user is an administrator, and only grants an administrator access to this page
            if ((String)Session["loggedUser"] != "admin") 
            {
                Response.Redirect("Login.aspx"); //If a user is not an administrator, it redirects to the login page for further processing
            }
        }

        //Takes the event information from the button click in the user interaction layer and processes insertion into the database
        protected void addBuildingButton_Click(Object sender, EventArgs e)
        {
            //Users ASP.NET function IsValid() to test user input and the current error state before proceeding
            if (Page.IsValid)
            {          
                BuildingModel newBuilding = new BuildingModel(); //Creates a new BuildingModel instance

                //Sets relevant values from user input
                newBuilding.BuildingName = inBuildingName.Value; 
                newBuilding.BuildingLabel = inBuildingLabel.Value;
                newBuilding.RoomQty = Convert.ToInt32(inRoomQty.Value);

                //Adds a new building to the database
                BuildingBL.ProcessAddNewBuilding(newBuilding);
                
                //Redirects the user to the administrator home panel after processing is completed
                Response.Redirect("AdminHome.aspx");
            }
        }
    }
}