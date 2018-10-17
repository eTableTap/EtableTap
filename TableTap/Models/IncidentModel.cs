using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class IncidentModel
    {

        public int IncidentID { get; set; }

        public DateTime Date { get; set; }

        public string Info { get; set; }

        public int TableID { get; set; }

        public int roomID { get; set; }

        public int userID { get; set; }


        public IncidentModel()
        {

        }

        public IncidentModel(int id, string email, string psw, string fname, string lname, byte admperm, string ph)
        {
            this.IncidentID = id;
            this.Date = email;
            this.Info = psw;
            this.TableID = fname;
            this.roomID = lname;
            this.AdminPermissi = admperm;
            this.phoneNum = ph;
        }
    }
}