using System;
using Hangfire;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;

namespace TableTap.UL
{
    public partial class BookingReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            

            try
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                MainWorker(ID);
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }

        }





        protected void MainWorker(int groupID)
        {

            GroupModel group = GroupBL.searchGroupByID(groupID);

            UserModel user = new UserModel();
            TableModel table = new TableModel();
            RoomModel room = new RoomModel();
            BuildingModel building = new BuildingModel();


            table = TableBL.getTableByID(group.tableID);

            user = UserBL.passUserSearch(group.emailAddress);

            room = RoomBL.getRoomByID(table.RoomID);

            building = BuildingBL.getBuildingByID(room.BuildingID);
            string name = user.FirstName;
            string day = group.gDate.ToString("yyyy-MM-d");
            string hour = group.gHour.ToString() + ":00";
            string bTable = table.TableID.ToString();
            string roomName = room.RoomName;
            string buildingName = building.BuildingName;
            string buildingAddress = building.street + " " + building.suburb + Environment.NewLine + "<br />"
                + " " + building.provence + " " + building.country;
            lblName.Text = name;
            lblDay.Text = day;
            lblHour.Text = hour;
            lblTable.Text = bTable;
            lblRoom.Text = roomName;
            lblBuilding.Text = buildingName;
            lblAddress.Text = buildingAddress;
            lblbuildingid.Text = building.BuildingID.ToString();
 



        }


        protected void Directions_Click(object sender, EventArgs e)
        {
            int buildingID = int.Parse(lblbuildingid.Text); 
                                  // directions module
            string URL = DirectionModuleBL.start(buildingID);

            Response.Redirect(URL);
        }

        protected void goToHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}