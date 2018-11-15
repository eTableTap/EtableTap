using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;

namespace TableTap.UL
{
    public partial class AdminAddRoom : System.Web.UI.Page
    {
        List<BuildingModel> buildings = new List<BuildingModel>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((string)Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("Login.aspx");
            }
            buildings = BuildingBL.fillBuildingsList();

            if (!IsPostBack) //need this to stop it reverting to the top value every button click ------------------!!!!!!!!!!!!!!!!!!!
            {
                buildingDropdown.DataSource = buildings;
                buildingDropdown.DataValueField = "BuildingID";
                buildingDropdown.DataTextField = "BuildingName";
                buildingDropdown.DataBind();

                ddlbuildingDropDown_SelectedIndexChanged(sender, e);

            }
        }
        protected void addRoomButton_Click(Object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BuildingModel bm = new BuildingModel();

                bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); //grabs single selected building

                int id = bm.BuildingID;

                RoomModel newRoom = new RoomModel();

                newRoom.BuildingID = id;
                newRoom.RoomName = inRoomName.Value;
                newRoom.RoomLabel = inRoomLabel.Value;
                newRoom.TableQty = Convert.ToInt32(inTableQty.Value);


                RoomBL.ProcessAddNewRoom(newRoom);


                Response.Redirect("AdminHome.aspx");
            }
        }

        protected void ddlbuildingDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

            BuildingModel bm = new BuildingModel();

            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); //grabs single selected building

            int id = bm.BuildingID;




        }
    }
}