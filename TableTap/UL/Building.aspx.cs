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

            if (!IsPostBack) 
            {
                
                inputRoomSelecter.DataSource = rooms;
                inputRoomSelecter.DataValueField = "RoomID";
                inputRoomSelecter.DataTextField = "RoomName";
                inputRoomSelecter.DataBind();
            }
            if (inputRoomSelecter.Items.Count < 1)
            {
                sideLbl.Text = "No rooms found";
                inputRoomSelecter.Visible = false;
                goToRoomingButton.Visible = false;

            }
        }

        protected void goToRoomButton_Click(Object sender, EventArgs e)
        {
            RoomModel rm = new RoomModel();

            rm = rooms.Where(b => b.RoomID == Int32.Parse(inputRoomSelecter.Value)).FirstOrDefault(); //grabs single selected building
               
            
            int id = rm.RoomID;

            string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Room.aspx?id=" + id;
            Response.Redirect(url);

        }
    }
}