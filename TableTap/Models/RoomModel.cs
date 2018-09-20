using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class RoomModel
    {
        public int RoomID { get; set; }

        public string RoomName { get; set; }

        public string RoomLabel { get; set; }

        public int BuildingID { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }

        //need RoomMap image stored here

        public int TableQty { get; set; }

        public int TablesAvailable { get; set; }
        //probably dont need this, website can check this
        public RoomModel()
        {

        }

        public RoomModel(int rid, string rn, string rl, int bid, DateTime ot, DateTime ct, int tq, int ta)
        {
            this.RoomID = rid;
            this.RoomName = rn;
            this.RoomLabel = rl;
            this.BuildingID = bid;
            this.OpeningTime = ot;
            this.ClosingTime = ct;
            this.TableQty = tq;
            this.TablesAvailable = ta;
        }

    }

    

        
}