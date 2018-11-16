using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;
using System.Drawing.Imaging;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as a the back-end for the administrator, and provides functionality for updating / managing incidents in the system
 */

namespace TableTap.UL
{
    public partial class AdminPrintQR : System.Web.UI.Page
    {
        List<BuildingModel> buildings = new List<BuildingModel>();
        List<RoomModel> rooms = new List<RoomModel>();
        List<TableModel> tables = new List<TableModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Load data if user has initiated so, by button click.
            if ((string)Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("home.aspx");
            }

            buildings = BuildingBL.fillBuildingsList();

            //Update building information if user has initiated so, by button click.
            if (!IsPostBack)
            {
                buildingDropdown.DataSource = buildings;
                buildingDropdown.DataValueField = "BuildingID";
                buildingDropdown.DataTextField = "BuildingName";
                buildingDropdown.DataBind();
            }
                
        }

        /// <summary>
        /// Update list of buildings on change of content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlbuildingDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildingModel bm = new BuildingModel();

            //Selects single selected building
            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); 
            int id = bm.BuildingID;

            //Pull all rooms from the database
            rooms = RoomBL.fillRoomsList(id);
            
            //Update values from user input
            roomDropdown.DataSource = rooms;
            roomDropdown.DataValueField = "RoomID";
            roomDropdown.DataTextField = "RoomName";
            roomDropdown.DataBind();            
        }

        /// <summary>
        /// Update list of rooms on change of content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlroomDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildingModel bm = new BuildingModel();
            //Selects single selected building
            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); 
            int id = bm.BuildingID;

            //Pull all rooms from the database
            rooms = RoomBL.fillRoomsList(id);

            RoomModel rm = new RoomModel();
            //Selects single selected building
            rm = rooms.Where(r => r.RoomID == Int32.Parse(roomDropdown.Text)).FirstOrDefault(); 
            int rid = rm.RoomID;

            tables = TableBL.FillTableList(rid);


            //Update values from user input
            tableDropdown.DataSource = tables;
            tableDropdown.DataValueField = "TableID";
            tableDropdown.DataTextField = "TableID";
            tableDropdown.DataBind();            
        }

        protected void generateButton_Click(object sender, EventArgs e)
        {
            //Create new instance of QRencoder
            QRCodeEncoder encoder = new QRCodeEncoder();
            generateButton.Text = tableDropdown.Text;

            //Generate string of url
            string sGeneration = "www.etabletap.com/UL/" + "Table.aspx?id=" + tableDropdown.Text;

            //Encodes image into bitmap format
            Bitmap img = encoder.Encode(sGeneration);

            Session["QRURL"] = sGeneration;
            Session["filename"] = makeFileName();
          
            //Dictates the storage location of the file
            string path = Server.MapPath("~/Resources/Images/QR/");
            generateButton.Text = path;

            //Geneaterates the image
            img.Save(path + makeFileName() + ".Png", System.Drawing.Imaging.ImageFormat.Png);

            //Redirects to the page to preview the QR
            Response.Redirect("PrintPage.aspx");
        }

        /// <summary>
        /// Create a filename
        /// </summary>
        /// <returns></returns>
        private string makeFileName()
        {
            string data = Session["login"].ToString();

            data = data.Replace(".", "");
            data = data.Replace("@", "");

            string filename = data;
            return filename;

        }
    }
}