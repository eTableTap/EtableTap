﻿using MessagingToolkit.QRCode.Codec;
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


namespace TableTap.UL
{
    public partial class AdminPrintQR : System.Web.UI.Page
    {
        List<BuildingModel> buildings = new List<BuildingModel>();
        List<RoomModel> rooms = new List<RoomModel>();
        List<TableModel> tables = new List<TableModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("Login.aspx");
            }*/

            buildings = BuildingBL.fillBuildingsList();

            if (!IsPostBack) //need this to stop it reverting to the top value every button click ------------------!!!!!!!!!!!!!!!!!!!
            {
                buildingDropdown.DataSource = buildings;
                buildingDropdown.DataValueField = "BuildingID";
                buildingDropdown.DataTextField = "BuildingName";
                buildingDropdown.DataBind();
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

        protected void ddlroomDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildingModel bm = new BuildingModel();

            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); //grabs single selected building
            int id = bm.BuildingID;

            rooms = RoomBL.fillRoomsList(id);

            ///////////////////////////////// currently works but selecting a new building wont change the previous

            RoomModel rm = new RoomModel();

            rm = rooms.Where(r => r.RoomID == Int32.Parse(roomDropdown.Text)).FirstOrDefault(); //grabs single selected building
            int rid = rm.RoomID;

            tables = TableBL.FillTableList(rid);

            tableDropdown.DataSource = tables;
            tableDropdown.DataValueField = "TableID";
            tableDropdown.DataTextField = "TableID";
            tableDropdown.DataBind();
         
            

            
        }

        protected void generateButton_Click(object sender, EventArgs e)
        {


            /*BuildingModel bm = new BuildingModel();

            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); //grabs single selected building
            int id = bm.BuildingID;

            rooms = RoomBL.fillRoomsList(id);

            ///////////////////////////////// currently works but selecting a new building wont change the previous

            RoomModel rm = new RoomModel();

            rm = rooms.Where(r => r.RoomID == Int32.Parse(roomDropdown.Text)).FirstOrDefault(); //grabs single selected building
            int rid = rm.RoomID;

            tables = TableBL.fillTableList(rid);
            
            tableDropdown.DataSource = tables;
            //tableDropdown.DataValueField = "TableID";
            //tableDropdown.DataTextField = "TableID";
            tableDropdown.DataBind();
            ////////////////////

           

            TableModel tm = new TableModel();

            tm = tables.Where(t => t.TableID == Int32.Parse(tableDropdown.Text)).FirstOrDefault(); //grabs single selected building

            int tid = tm.TableID;

            generateButton.Text = tid.ToString();*/
            QRCodeEncoder encoder = new QRCodeEncoder();
            generateButton.Text = tableDropdown.Text;

            string sGeneration = "www.etabletap.com/UL/" + "Table.aspx?id=" + tableDropdown.Text;


            Bitmap img = encoder.Encode(sGeneration);

            Session["QRURL"] = sGeneration;
            Session["filename"] = makeFileName();
            //   Response.ContentType = "image/png";
            //     img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);

            //Change to your own location if you want to store a copy-- not needed
            string path = Server.MapPath("~/Resources/Images/QR/");
            generateButton.Text = path;

            img.Save(path + makeFileName() + ".Png", System.Drawing.Imaging.ImageFormat.Png);
            // QRImage.ImageUrl = "LastQRCodeCreated.png";

            Response.Redirect("PrintPage.aspx");

        }

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