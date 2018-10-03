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
            //testButton1.Text = today.ToShortDateString();
            //testButton1.Text = today.ToString("dd-MM-yyyy");
            //testButton1.Text = today.ToString("yyyy-MM-dd");
            //testButton1.Text = today.ToString("HH");

            lblStatus.Text = TableBL.checkTableStatus(ID).ToString();

            BookingModel bookings = TableBL.getDayTableBooking(ID);
            

            List<string> dayList = new List<String>();
            int x = 0;
            while (x < 24)
            {
                dayList.Add(bookings.Hour[x]);
                x++;
            }
            if (!IsPostBack) //need this to stop it reverting to the top value every button click
            {
                hourDropdown.DataSource = dayList;
                
                hourDropdown.DataBind();
            }




            //need to create a drop down for available times for the rest of the day

            //need to create a booking page, that lets the user select a date

            //add user session to see who booked it.
        }
    }
}