using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class GroupModel
    {

        public int groupID { get; set; }

        public int statusID { get; set; }

        public int tableID { get; set; }

        public DateTime gDate { get; set; }

        public string emailAddress { get; set; }

        public int gHour { get; set; }

        public string memberEmail1 { get; set; }
        public string memberEmail2 { get; set; }
        public string memberEmail3 { get; set; }
        public string memberEmail4 { get; set; }
        public string memberEmail5 { get; set; }

        public GroupModel()
        {

        }


        public GroupModel(int groupIDE, int statusIDE, int tableIDE, DateTime bookingDate, string usersEmailAddress, int BookingHour, 
            string member1, string member2, string member3, string member4, string member5)
        {
            this.groupID = groupIDE;
            this.statusID = statusIDE;
            this.tableID = tableIDE;
            this.gDate = bookingDate;
            this.emailAddress = usersEmailAddress;
            this.gHour = BookingHour;
            this.memberEmail1 = member1;
            this.memberEmail2 = member2;
            this.memberEmail3 = member3;
            this.memberEmail4 = member4;
            this.memberEmail5 = member5;

   
        }



    }
}