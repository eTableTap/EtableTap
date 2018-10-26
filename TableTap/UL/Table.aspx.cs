using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.BusinessLayer; //UserBL is not in the namespace Businesslayer.Classes, need to fix and change all references
using TableTap.Models;


namespace TableTap.UL
{
    public partial class Table : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
           

            DateTime today = DateTime.Now;   //HH = 24hours, hh = 12hours, M = month, m = minute, d = day, y = year.
            lblHeading.Text = "Table: " + ID.ToString();
            //testButton1.Text = today.ToShortDateString();
            //testButton1.Text = today.ToString("dd-MM-yyyy");
            //testButton1.Text = today.ToString("yyyy-MM-dd");
            //testButton1.Text = today.ToString("HH");

            bool bCheck = TableBL.checkTableStatus(ID);
            if (bCheck == true)
            {
                lblStatus.Text = "THE TABLE IS AVAILABLE";
            }
            else
            {
                btnBook.Visible = false;
                lblStatus.Text = "THE TABLE IS CURRENTLY OCCUPIED";
            }

            BookingModel bookings = TableBL.getDayTableBooking(ID);

            
            List<string> dayList = new List<String>();
            int x = Convert.ToInt32(today.ToString("HH")); //sets x to current hour
            
            while (x < 24)      //will loop until the end of the day's booking aka 2300. Can change to room closing time     
            {
                if (bookings.Hour[x].ToString().Contains("Free"))
                {
                    dayList.Add(x.ToString() + ": " + bookings.Hour[x]);
                }
                else
                {
                    dayList.Add(x.ToString() + ": Occupied");
                }

                x++;
            }
           
            if (!IsPostBack) 
            {
                hourDropdown.DataSource = dayList;
                hourDropdown.DataBind();
            }

            //need to create a booking page, that lets the user select a date

        }
        protected void hourDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hourDropdown.SelectedValue.ToString().Contains("Occupied"))
            {
                btnBook.Visible = false;
                lblStatus.Text = "THE TABLE IS CURRENTLY OCCUPIED";
            }
            else
            {
                btnBook.Visible = true;
                lblStatus.Text = "THE TABLE IS AVAILABLE";
            }
        }
        protected void btnBook_Click(Object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                string url = Request.Url.AbsoluteUri;
                Session["LoginFallback"] = url;
                Response.Redirect("Login.aspx");
            }
            
            btnBook.Visible = false;
            //btnBook.Enabled = false;
            makeBooking();
            btnDirections.Visible = true;
           



        }
        protected void btnDirections_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
            int buildingID = BuildingBL.getBuildingByID(RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).BuildingID).BuildingID; 
            // directions module
            string URL = DirectionModuleBL.start(buildingID);

            Response.Redirect(URL);
        }
        protected void makeBooking()
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
            //string sHour = new String(hourDropdown.SelectedItem.Text.TakeWhile(Char.IsDigit).ToArray());
            string sHour = hourDropdown.SelectedValue.ToString();
            sHour = new string(sHour.TakeWhile(Char.IsDigit).ToArray());
            if (TableBL.bookTable(ID, Session["login"].ToString(), sHour))
            {
                lblHeading.Text = "Table was booked";

                lblStatus.Text = "Table: " + TableBL.getTableByID(ID).TableID + "<br />Room Name: " + RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).RoomName.ToString() + "<br />in building: " + BuildingBL.getBuildingByID(RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).BuildingID).BuildingName + "<br />at: " + sHour + "00 -" + (Convert.ToInt32(sHour) + 1).ToString() + "00" + "<br /> was successfully booked";

            }

            if (InputEmail1.Value != null)
            {
                lblStatus.Text += "<br />Session User: " + UserBL.passUserSearch(Session["login"].ToString()).FirstName.ToString()
                + "<br />Email: " + InputEmail1.Value.ToString()
                + "<br />Email: " + TableBL.getTableByID(ID).TableID.ToString()
                + "<br />Email: " + RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).RoomName.ToString()
                + "<br />Email: " + BuildingBL.getBuildingByID(RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).BuildingID).BuildingName.ToString();

                DateTime today = DateTime.Now;
                NotifyBL.startNotifyGroupMember(UserBL.passUserSearch(Session["login"].ToString()).FirstName.ToString(),
                InputEmail1.Value.ToString(),
                TableBL.getTableByID(ID).TableID.ToString(),
                RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).RoomName.ToString(),
                BuildingBL.getBuildingByID(RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).BuildingID).BuildingName.ToString(),
                today.ToString("dd-MM-yyyy"),
                sHour + "00");
            }
        }
    }
}