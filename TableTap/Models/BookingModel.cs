using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class BookingModel
    {

        public int bookingID { get; set; }

        public int tableID { get; set; }

        public DateTime bookingDate { get; set; }

        public string emailAddress { get; set; }

        public int bookingHour { get; set; }

        public string memberEmail1 { get; set; }
        public string memberEmail2 { get; set; }
        public string memberEmail3 { get; set; }
        public string memberEmail4 { get; set; }
        public string memberEmail5 { get; set; }

        public int checkinStatus { get; set; }

        public BookingModel()
        {

        }


        public BookingModel(int bookingIDE, int tableIDE, DateTime bDate, string usersEmailAddress, int bHour, 
            string member1, string member2, string member3, string member4, string member5, int checkin)
        {
            this.bookingID = bookingIDE;

            this.tableID = tableIDE;
            this.bookingDate = bDate;
            this.emailAddress = usersEmailAddress;
            this.bookingHour = bHour;
            this.memberEmail1 = member1;
            this.memberEmail2 = member2;
            this.memberEmail3 = member3;
            this.memberEmail4 = member4;
            this.memberEmail5 = member5;
            this.checkinStatus = checkin;

   
        }



    }
}