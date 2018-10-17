using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class IncidentModel
    {

        public int IncidentID { get; set; }

        public DateTime userdate { get; set; }

        public string Info { get; set; }

        public int TableID { get; set; }

        public int RoomID { get; set; }

        public int UserID { get; set; }

        public bool IncLevel { get; set; }

        public IncidentModel()
        {

        }

        public IncidentModel(int id, DateTime date, string data, int tableID, int roomID, int userID, bool incLevel)
        {
            this.IncidentID = id;
            this.userdate = date;
            this.Info = data;
            this.TableID = tableID;
            this.RoomID = roomID;
            this.UserID = userID;
            this.IncLevel = incLevel;
        }
    }
}