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
    public partial class AdminAddTable : System.Web.UI.Page
    {
        List<BuildingModel> buildings = new List<BuildingModel>();
        List<RoomModel> rooms = new List<RoomModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if a user is an administrator, and only grants an administrator access to this page
            if ((string)Session["loggedUser"] != "admin")
            {
                Response.Redirect("home.aspx");
            }

            //Pulls all saved buildings from the database
            buildings = BuildingBL.fillBuildingsList();

            //Uses the ASP control IsPostBack to determine if a post-back or user actioned button click has been performed
            if (!IsPostBack) 
            {
                buildingDropdown.DataSource = buildings; //Fills the dropdown with all the buildings pulled from the database
                buildingDropdown.DataValueField = "BuildingID"; 
                buildingDropdown.DataTextField = "BuildingName";
                buildingDropdown.DataBind(); //Binds the ID / Name in the dropdown for user selection

                ddlbuildingDropDown_SelectedIndexChanged(sender, e); //Forces actions to reflect on user visual layer
                
            }
        }

        /// <summary>
        /// Adds a table to the database from user entered data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addTableButton_Click(Object sender, EventArgs e)
        {
            //Uses ASP.NET function IsValid() to test user input and the current error state before proceeding
            if (Page.IsValid)
            {
                TableModel newTable = new TableModel();
                BuildingModel bm = new BuildingModel();
                RoomModel rm = new RoomModel();
                
                //Selects single selected building form buildinglist
                bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault();
                int id = bm.BuildingID;

                //Fills the list for the next to take it
                rooms = RoomBL.fillRoomsList(id);

                //Selects single selected building from roomlist
                rm = rooms.Where(r => r.RoomID == Int32.Parse(roomDropdown.Text)).FirstOrDefault();

                //Sets the table values from user data
                newTable.RoomID = rm.RoomID;
                newTable.Category = inTableCatagory.Value;
                newTable.PersonCapacity = Convert.ToInt32(inTableCapacity.Value);

                //Adds a new table to the database
                TableBL.ProcessAddNewTable(newTable);
                
                //Visually displays recognition of successful table creation
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Table Created!" + "');", true);

            }
        }

        /// <summary>
        /// Refills the relevant buildings list as pulled from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlbuildingDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildingModel bm = new BuildingModel();

            //Gets a single selected building
            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); 

            int id = bm.BuildingID;

            //Pulls all rooms from the database
            rooms = RoomBL.fillRoomsList(id);

            //Updates the dropdown for user viewing
            roomDropdown.DataSource = rooms;
            roomDropdown.DataValueField = "RoomID";
            roomDropdown.DataTextField = "RoomName";
            roomDropdown.DataBind();

        }
    }
}