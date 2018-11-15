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

        public TimeSpan OpeningTime { get; set; }

        public TimeSpan ClosingTime { get; set; }

        public int TableQty { get; set; }

        public RoomModel()
        {

        }

        public RoomModel(int rid, string rn, string rl, int bid, TimeSpan ot, TimeSpan ct, int tq)
        {
            this.RoomID = rid;
            this.RoomName = rn;
            this.RoomLabel = rl;
            this.BuildingID = bid;
            this.OpeningTime = ot;
            this.ClosingTime = ct;
            this.TableQty = tq;

        }

    }

    

        
}