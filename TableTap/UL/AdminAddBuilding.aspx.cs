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
    public partial class AdminAddBuilding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void addBuildingButton_Click(Object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                BuildingModel newBuilding = new BuildingModel();

                newBuilding.BuildingName = inBuildingName.Value;
                newBuilding.BuildingLabel = inBuildingLabel.Value;
                newBuilding.RoomQty = Convert.ToInt32(inRoomQty.Value);


                BuildingBL.ProcessAddNewBuilding(newBuilding);


                Response.Redirect("AdminHome.aspx");
            }
        }
    }
}