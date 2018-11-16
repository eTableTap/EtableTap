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
    - Serves as back-end processing when an administrator user adds a room to a building in the database
 */

namespace TableTap.UL
{
    public partial class AdminAddRoom : System.Web.UI.Page
    {
        //Creates a new instance of a list of building models
        List<BuildingModel> buildings = new List<BuildingModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if a user is an administrator, and only grants an administrator access to this page
            if ((string)Session["loggedUser"] != "admin") 
            {
                Response.Redirect("Login.aspx"); //If a user is not an administrator, it redirects to the login page for further processing
            }

            //Pulls all saved buildings from the database
            buildings = BuildingBL.fillBuildingsList();

            //Uses the ASP control IsPostBack to determine if a user actioned button click has occurred
            if (!IsPostBack) 
            {
                buildingDropdown.DataSource = buildings; //Fills the dropdown with values pulled from database
                buildingDropdown.DataValueField = "BuildingID";
                buildingDropdown.DataTextField = "BuildingName";
                buildingDropdown.DataBind(); //Binds the buildingID & buildingName to the data to be shown in the dropdown

                ddlbuildingDropDown_SelectedIndexChanged(sender, e); //Reflects these actions on the user display layer

            }
        }

        /// <summary>
        /// Adds a room to the database from user entered data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addRoomButton_Click(Object sender, EventArgs e)
        {
            //Uses ASP.NET function IsValid() to test user input and the current error state before proceeding
            if (Page.IsValid)
            {
                BuildingModel bm = new BuildingModel(); //New buiding instance

                //Finds the single matching building to the user's selection
                bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault();

                int id = bm.BuildingID;

                RoomModel newRoom = new RoomModel(); //New room instance

                //Sets the room values from user data
                newRoom.BuildingID = id;
                newRoom.RoomName = inRoomName.Value;
                newRoom.RoomLabel = inRoomLabel.Value;
                newRoom.TableQty = Convert.ToInt32(inTableQty.Value);

                //Adds a new room to the database
                RoomBL.ProcessAddNewRoom(newRoom);
                
                //Redirects the admin to the Admin HomePage after processing
                Response.Redirect("AdminHome.aspx");
            }
        }

        /// <summary>
        /// Updates dropdown menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlbuildingDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildingModel bm = new BuildingModel();

            //Selects single selected building
            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault();
            int id = bm.BuildingID;
        }
    }
}