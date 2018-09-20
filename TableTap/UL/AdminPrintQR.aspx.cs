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
    public partial class AdminPrintQR : System.Web.UI.Page
    {
        List<BuildingModel> buildings = new List<BuildingModel>();
        List<RoomModel> rooms = new List<RoomModel>();
        List<TableModel> tables = new List<TableModel>();

        protected void Page_Load(object sender, EventArgs e)
        {

            
            buildings = BuildingBL.fillBuildingsList();

            if (!IsPostBack) //need this to stop it reverting to the top value every button click
            {
                buildingDropdown.DataSource = buildings;
                buildingDropdown.DataValueField = "BuildingID";
                buildingDropdown.DataTextField = "BuildingName";
                buildingDropdown.DataBind();

                
            }
                
        }

        protected void ddlroomDropDown_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void ddltableDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* TableModel tm = new TableModel();

            tm = tables.Where(t => t.TableID == Int32.Parse(tableDropdown.Text)).FirstOrDefault(); //grabs single selected building

            int id = tm.TableID;

            tables = TableBL.fillTableList(id);

            tableDropdown.DataSource = tables;
            tableDropdown.DataValueField = "TableID";
            tableDropdown.DataTextField = "TableID";
            tableDropdown.DataBind();*/
        }
    }
}