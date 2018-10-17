using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.Models;
using TableTap.BusinessLayer.Classes;
using System.Configuration;

namespace TableTap.UL
{
    public partial class Building : System.Web.UI.Page
    {
        List<RoomModel> rooms = new List<RoomModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            int ID = Int32.Parse(Request.QueryString["ID"]);
            lblHeading.Text = "Building: " + BuildingBL.getBuildingByID(ID).BuildingName;
            rooms = RoomBL.fillRoomsList(ID);

            if (!IsPostBack) //need this to stop it reverting to the top value every button click
            {
                roomDropdown.DataSource = rooms;
                roomDropdown.DataValueField = "RoomID";
                roomDropdown.DataTextField = "RoomName";
                roomDropdown.DataBind();
            }

            if (roomDropdown.Items.Count < 1)
            {
                lblAboveDropdown.Text = "No rooms currently available";
                roomDropdown.Visible = false;
                goToRoomingButton.Visible = false;


                //show room timetables

            }
        }

        protected void goToRoomButton_Click(Object sender, EventArgs e)
        {
            RoomModel rm = new RoomModel();

            rm = rooms.Where(b => b.RoomID == Int32.Parse(roomDropdown.Text)).FirstOrDefault(); //grabs single selected building
               
            
            int id = rm.RoomID;

            string url = ConfigurationManager.AppSettings["UnsecurePath"] + "UL/Room.aspx?id=" + id;
            Response.Redirect(url);

        }
    }
}