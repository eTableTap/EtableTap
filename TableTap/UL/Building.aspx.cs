using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.Models;
using TableTap.BusinessLayer.Classes;
using System.Configuration;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as back-end processing when a user selects a building as part of the booking process
 */

namespace TableTap.UL
{
    public partial class Building : System.Web.UI.Page
    {
        List<RoomModel> rooms = new List<RoomModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Gets all buildings by an ID
            int ID = Int32.Parse(Request.QueryString["ID"]);
            lblHeading.Text = "Building: " + BuildingBL.getBuildingByID(ID).BuildingName;
            rooms = RoomBL.fillRoomsList(ID);
           
            if (!IsPostBack) 
            {           
                //Fill list with all relevant rooms
                inputRoomSelecter.DataSource = rooms;
                inputRoomSelecter.DataValueField = "RoomID";
                inputRoomSelecter.DataTextField = "RoomName";
                inputRoomSelecter.DataBind();
            }

            if (inputRoomSelecter.Items.Count < 1)
            {
                //If no rooms found, output error code and hide selection options
                sideLbl.Text = "No rooms found";
                inputRoomSelecter.Visible = false;
                goToRoomingButton.Visible = false;

            }
        }

        /// <summary>
        /// After room selection, it redirects to the associated room page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void goToRoomButton_Click(Object sender, EventArgs e)
        {
            RoomModel rm = new RoomModel();

            //Select single selected building  
            rm = rooms.Where(b => b.RoomID == Int32.Parse(inputRoomSelecter.Value)).FirstOrDefault();
            int id = rm.RoomID;

            //Redirects the user to the relevant room page
            string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Room.aspx?id=" + id;
            Response.Redirect(url);

        }
    }
}