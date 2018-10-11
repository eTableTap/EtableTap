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
    public partial class Table : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
           

            DateTime today = DateTime.Now;   //HH = 24hours, hh = 12hours, M = month, m = minute, d = day, y = year.
            lblHeading1.Text = "Table: " + ID.ToString();
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
                
                Response.Redirect("Login.aspx");
            }
            int ID = Int32.Parse(Request.QueryString["ID"]);
            //string sHour = new String(hourDropdown.SelectedItem.Text.TakeWhile(Char.IsDigit).ToArray());
            string sHour = hourDropdown.SelectedValue.ToString();
            sHour = new string(sHour.TakeWhile(Char.IsDigit).ToArray());
            btnBook.Text = sHour;
            if (TableBL.bookTable(ID, Session["login"].ToString(), sHour))
            {
                lblHeading1.Text = "Table was booked";

            }

        }
    }
}