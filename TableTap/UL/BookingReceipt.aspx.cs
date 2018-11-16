using System;
using Hangfire;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;


/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Activates worker operators related to the booking
 */

namespace TableTap.UL
{
    public partial class BookingReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {      
            //Successful parsing of the query string will initiate a mainworker operation
            try
            {
                int ID = Int32.Parse(Request.QueryString["ID"]);
                MainWorker(ID);
            }
            //Failure to parse the query string will result in an error
            catch
            {
                Response.Redirect("Error.aspx");
            }
        }

        /// <summary>
        /// Generates relevant booking information, as acquired from the user's booking information supplied
        /// </summary>
        /// <param name="bookingID"></param>
        protected void MainWorker(int bookingID)
        {
            //Get booking by the ID provided
            BookingModel booking = BookingBL.SearchBookingByID(bookingID);

            UserModel user = new UserModel();
            TableModel table = new TableModel();
            RoomModel room = new RoomModel();
            BuildingModel building = new BuildingModel();

            //Get all values by their identifiers (table, users & room)
            table = TableBL.GetTableByID(booking.tableID);
            user = UserBL.passUserSearch(booking.emailAddress);
            room = RoomBL.getRoomByID(table.RoomID);
            building = BuildingBL.getBuildingByID(room.BuildingID);

            string name = user.FirstName;
            string day = booking.bookingDate.ToString("yyyy-MM-d");
            string hour = booking.bookingHour.ToString() + ":00";
            string bTable = table.TableID.ToString();
            string roomName = room.RoomName;
            string buildingName = building.BuildingName;

            //Generate a string from acquired data
            string buildingAddress = building.street + " " + building.suburb + Environment.NewLine + "<br />"
                + " " + building.provence + " " + building.country;

            //Update relevant data from user input booking information
            lblName.Text = name;
            lblDay.Text = day;
            lblHour.Text = hour;
            lblTable.Text = bTable;
            lblRoom.Text = roomName;
            lblBuilding.Text = buildingName;
            lblAddress.Text = buildingAddress;
            lblbuildingid.Text = building.BuildingID.ToString();
        }

        /// <summary>
        /// Directions module will parse the relevant directions information and redirect to the location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Directions_Click(object sender, EventArgs e)
        {
            int buildingID = int.Parse(lblbuildingid.Text); 
            string URL = DirectionModuleBL.start(buildingID);
            Response.Redirect(URL);
        }

        /// <summary>
        /// Redirects to the homepage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void goToHomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}