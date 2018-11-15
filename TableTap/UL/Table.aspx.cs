using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.BusinessLayer; //UserBL is not in the namespace Businesslayer.Classes, need to fix and change all references
using TableTap.Models;
using System.Configuration;

namespace TableTap.UL
{
    public partial class Table : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);

            TableModel ThisTable = TableBL.getTableByID(ID);
            lblgetID.Text = ThisTable.TableID.ToString();
            lblgetCategory.Text = ThisTable.Category;
            lblgetSeatingCapacity.Text = ThisTable.PersonCapacity.ToString();

            DateTime today = DateTime.Now;   //HH = 24hours, hh = 12hours, M = month, m = minute, d = day, y = year.
            lblHeading.Text = "Select Hour: ";


            
            /////For New System///Checks

            List<string> hoursList = new List<String>();
            int x = Convert.ToInt32(today.ToString("HH")); ; //set y to current hour
            RoomModel thisRoom = RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID);
            if (x >= thisRoom.ClosingTime.TotalHours)
            {
                btnBook.Enabled = false;

            }
            while (x < thisRoom.ClosingTime.TotalHours)      //will loop until the end of the day's booking aka 2300. Can change to room closing time     
            {
                if (!TableBL.checkTableHourAvailability(Int32.Parse(Request.QueryString["ID"]), x, today))
                {
                    hoursList.Add(x.ToString() + ": " + "is free");
                }
                else
                {
                    hoursList.Add(x.ToString() + ": Occupied");
                }

                x++;
            }
            if (!IsPostBack)
            {
                hourDropdown.DataSource = hoursList;
                hourDropdown.DataBind();
            }

            if (hourDropdown.SelectedValue.ToString().Contains("Occupied"))
            {
                btnBook.Visible = false;
                lblStatus.Text = "THE TABLE IS CURRENTLY OCCUPIED";
            }

            showCalInputBoxes((TableBL.getTableByID(ID).PersonCapacity) - 1); // -1 because the user takes up 1 spot
            showInputBoxes((TableBL.getTableByID(ID).PersonCapacity) - 1);
            

        }
        protected void hourDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hourDropdown.SelectedValue.ToString().Contains("Occupied"))
            {
                btnBook.Visible = false;
            }
            else
            {
                btnBook.Visible = true;
            }
        }
        protected void calHourDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CalHourDropDown.SelectedValue.ToString().Contains("Occupied"))
            {
                btnBookCalander.Visible = false;
            }
            else
            {
                btnBookCalander.Visible = true;
            }
        }
        protected void MyCalendar_SelectionChanged(object sender, EventArgs e)
        {
            lblCalCheck.Text = "You selected date: ";
            CalHourDropDown.Visible = true;
            lblHourHelper.Visible = true;
            foreach (DateTime dt in Cal.SelectedDates)
            {
                lblCalCheck.Text += dt.ToLongDateString() + "<br />";
            }
            int ID = Int32.Parse(Request.QueryString["ID"]);
            RoomModel thisRoom = RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID);
            List<string> hoursList = new List<String>();

            double x = thisRoom.OpeningTime.TotalHours; //building opening time

            while (x < thisRoom.ClosingTime.TotalHours)      //will loop until the end of the day's booking aka 2300. Can change to room closing time     
            {
                if (!TableBL.checkTableHourAvailability(Int32.Parse(Request.QueryString["ID"]), Convert.ToInt32(x), Cal.SelectedDate))
                {
                    hoursList.Add(x.ToString() + ": " + "is free");
                }
                else
                {
                    hoursList.Add(x.ToString() + ": Occupied");
                }

                x++;
            }

            CalHourDropDown.DataSource = hoursList;
            CalHourDropDown.DataBind();

            if (CalHourDropDown.SelectedValue.ToString().Contains("Occupied"))
            {
                btnBookCalander.Visible = false;
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
            

            ///for new system
            ///

            int ID = Int32.Parse(Request.QueryString["ID"]);
            string sHour = hourDropdown.SelectedValue.ToString();
            sHour = new string(sHour.TakeWhile(Char.IsDigit).ToArray());
            //DateTime date = DateTime.Now;
            BookingModel newGroupBooking = new BookingModel();
            newGroupBooking.tableID = ID;
            newGroupBooking.gDate = DateTime.Now;
            newGroupBooking.emailAddress = Session["Login"].ToString();
            newGroupBooking.gHour = Int32.Parse(sHour);
            newGroupBooking.memberEmail1 = InputEmail1.Value;
            newGroupBooking.memberEmail2 = InputEmail2.Value;
            newGroupBooking.memberEmail3 = InputEmail3.Value;
            newGroupBooking.memberEmail4 = InputEmail4.Value;
            newGroupBooking.memberEmail5 = InputEmail5.Value;

            if (TableBL.processCalanderBookTable(newGroupBooking))
            {
                lblHeading.Text = "Table was booked";

                lblStatus.Text = "Table: " + TableBL.getTableByID(ID).TableID + "<br />Room Name: " + RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).RoomName.ToString() + "<br />in building: " + BuildingBL.getBuildingByID(RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).BuildingID).BuildingName + "<br />at: " + sHour + "00 -" + (Convert.ToInt32(sHour) + 1).ToString() + "00" + "<br /> was successfully booked";

                if (InputEmail1.Value != null)
                {
                    notifyGroup(InputEmail1.Value, ID, DateTime.Now, sHour);
                }
                if (InputEmail2.Value != null)
                {
                    notifyGroup(InputEmail2.Value, ID, DateTime.Now, sHour);
                }
                if (InputEmail3.Value != null)
                {
                    notifyGroup(InputEmail3.Value, ID, DateTime.Now, sHour);
                }
                if (InputEmail4.Value != null)
                {
                    notifyGroup(InputEmail4.Value, ID, DateTime.Now, sHour);
                }
                if (InputEmail5.Value != null)
                {
                    notifyGroup(InputEmail5.Value, ID, DateTime.Now, sHour);
                }
                //(string email, int tableID,DateTime date, string sHour)
                btnDirections.Visible = true;

                int receipt = TableBL.getGroupIntByGroupModel(newGroupBooking);

                string url = ConfigurationManager.AppSettings["UnsecurePath"] + "BookingReceipt.aspx?id=" + receipt;
                Response.Redirect(url);
            }


        }
        protected void btnDirections_Click(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
            int buildingID = BuildingBL.getBuildingByID(RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).BuildingID).BuildingID; 
            // directions module
            string URL = DirectionModuleBL.start(buildingID);

            Response.Redirect(URL);
        }
        protected void btnBookCalander_Click(Object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                string url = Request.Url.AbsoluteUri;
                Session["LoginFallback"] = url;
                Response.Redirect("Login.aspx");
            }

            int ID = Int32.Parse(Request.QueryString["ID"]);
            string sHour = CalHourDropDown.SelectedValue.ToString();
            sHour = new string(sHour.TakeWhile(Char.IsDigit).ToArray());
            DateTime date = Cal.SelectedDate;
            BookingModel newGroupBooking = new BookingModel();
            newGroupBooking.tableID = ID;
            newGroupBooking.gDate = Cal.SelectedDate.Date;
            newGroupBooking.emailAddress = Session["Login"].ToString();
            newGroupBooking.gHour = Int32.Parse(sHour);
            newGroupBooking.memberEmail1 = InputCalEmail1.Value;
            newGroupBooking.memberEmail2 = InputCalEmail2.Value;
            newGroupBooking.memberEmail3 = InputCalEmail3.Value;
            newGroupBooking.memberEmail4 = InputCalEmail4.Value;
            newGroupBooking.memberEmail5 = InputCalEmail5.Value;

            //bool btest = TableBL.processCalanderBookTable(newGroupBooking);
            if(TableBL.processCalanderBookTable(newGroupBooking))
            {
                lblHeading.Text = "Table was booked";

                lblStatus.Text = "Table: " + TableBL.getTableByID(ID).TableID + "<br />Room Name: " + RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).RoomName.ToString() + "<br />in building: " + BuildingBL.getBuildingByID(RoomBL.getRoomByID(TableBL.getTableByID(ID).RoomID).BuildingID).BuildingName + "<br />at: " + sHour + "00 -" + (Convert.ToInt32(sHour) + 1).ToString() + "00" + "<br /> was successfully booked";

                if (InputCalEmail1.Value != null)
                {
                    notifyGroup(InputCalEmail1.Value, ID, date, sHour);
                }
                if (InputCalEmail2.Value != null)
                {
                    notifyGroup(InputCalEmail2.Value, ID, date, sHour);
                }
                if (InputCalEmail3.Value != null)
                {
                    notifyGroup(InputCalEmail3.Value, ID, date, sHour);
                }
                if (InputCalEmail4.Value != null)
                {
                    notifyGroup(InputCalEmail4.Value, ID, date, sHour);
                }
                if (InputCalEmail5.Value != null)
                {
                    notifyGroup(InputCalEmail5.Value, ID, date, sHour);
                }
                //(string email, int tableID,DateTime date, string sHour)
                btnDirections.Visible = true;

                int receipt = TableBL.getGroupIntByGroupModel(newGroupBooking);

                string url = ConfigurationManager.AppSettings["UnsecurePath"] + "BookingReceipt.aspx?id=" + receipt;
                Response.Redirect(url);
            }


        }

        protected void notifyGroup(string email, int tableID,DateTime date, string sHour)
        {
            NotifyBL.startNotifyGroupMember(UserBL.passUserSearch(Session["login"].ToString()).FirstName.ToString(),
            email,
            TableBL.getTableByID(tableID).TableID.ToString(),
            RoomBL.getRoomByID(TableBL.getTableByID(tableID).RoomID).RoomName.ToString(),
            BuildingBL.getBuildingByID(RoomBL.getRoomByID(TableBL.getTableByID(tableID).RoomID).BuildingID).BuildingName.ToString(),
            date.ToString("dd-MM-yyyy"),
            sHour + "00");
        }
        protected void showInputBoxes(int x)
        {
            
            if(x >= 1)
            {
                InputEmail1.Visible = true;
                lblInviteHelp.Visible = true;
                lblOptional1.Visible = true;
            }
            if (x >= 2)
            {
                InputEmail2.Visible = true;
                lblOptional2.Visible = true;
            }
            if (x >= 3)
            {
                InputEmail3.Visible = true;
                lblOptional3.Visible = true;
            }
            if (x >= 4)
            {
                InputEmail4.Visible = true;
                lblOptional4.Visible = true;
            }
            if (x >= 5)
            {
                InputEmail5.Visible = true;
                lblOptional5.Visible = true;
            }


        }
        protected void showCalInputBoxes(int x)
        {

            if (x >= 1)
            {
                InputCalEmail1.Visible = true;
                lblCalInviteHelp.Visible = true;
                lblCalOptional1.Visible = true;
            }
            if (x >= 2)
            {
                InputCalEmail2.Visible = true;
                lblCalOptional2.Visible = true;
            }
            if (x >= 3)
            {
                InputCalEmail3.Visible = true;
                lblCalOptional3.Visible = true;
            }
            if (x >= 4)
            {
                InputCalEmail4.Visible = true;
                lblCalOptional4.Visible = true;
            }
            if (x >= 5)
            {
                InputCalEmail5.Visible = true;
                lblCalOptional5.Visible = true;
            }


        }
        protected void btnBookNowSection_Click(object sender, EventArgs e)
        {
            BookNowSection.Visible = true;
            CalanderSection.Visible = false;
            CheckinSection.Visible = false;
        }
        protected void btnCalanderSection_Click(object sender, EventArgs e)
        {
            BookNowSection.Visible = false;
            CalanderSection.Visible = true;
            CheckinSection.Visible = false;
        }
        protected void btnCheckinSection_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                string url = Request.Url.AbsoluteUri;
                Session["LoginFallback"] = url;
                Response.Redirect("Login.aspx");
            }

            BookNowSection.Visible = false;
            CalanderSection.Visible = false;
            CheckinSection.Visible = true;

            int ID = Int32.Parse(Request.QueryString["ID"]);
            string sHour = hourDropdown.SelectedValue.ToString();
            sHour = new string(sHour.TakeWhile(Char.IsDigit).ToArray());
            //DateTime date = DateTime.Now;
            BookingModel newCheckin = new BookingModel();
            newCheckin.tableID = ID;
            newCheckin.gDate = DateTime.Now;
            newCheckin.emailAddress = Session["Login"].ToString();
            newCheckin.gHour = Int32.Parse(sHour);

            lblCheckinResult.Text = TableBL.processTableCheckin(newCheckin);
            


        }
    }
}