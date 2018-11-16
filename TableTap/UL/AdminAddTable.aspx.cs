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
    public partial class AdminAddTable : System.Web.UI.Page
    {
        List<BuildingModel> buildings = new List<BuildingModel>();
        List<RoomModel> rooms = new List<RoomModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("home.aspx");
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

        protected void addTableButton_Click(Object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                TableModel newTable = new TableModel();
                BuildingModel bm = new BuildingModel();
                RoomModel rm = new RoomModel();
                
                //grabs single selected building form buildinglist
                bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault();
                int id = bm.BuildingID;

                //need to fill the list for the next to take it
                rooms = RoomBL.fillRoomsList(id);
                
                //grabs single selected building from roomlist
                rm = rooms.Where(r => r.RoomID == Int32.Parse(roomDropdown.Text)).FirstOrDefault();
                
                newTable.RoomID = rm.RoomID;
                newTable.Category = inTableCatagory.Value;
                newTable.PersonCapacity = Convert.ToInt32(inTableCapacity.Value);

                TableBL.ProcessAddNewTable(newTable);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Table Created!" + "');", true);

            }
        }

        protected void ddlbuildingDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

            BuildingModel bm = new BuildingModel();

            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); //grabs single selected building

            int id = bm.BuildingID;


            rooms = RoomBL.fillRoomsList(id);


            roomDropdown.DataSource = rooms;
            roomDropdown.DataValueField = "RoomID";
            roomDropdown.DataTextField = "RoomName";
            roomDropdown.DataBind();

        }
    }
}