using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class BuildingModel
    {
        public int BuildingID { get; set; }

        public string BuildingLabel { get; set; }

        public string BuildingName { get; set; }

        public int RoomQty { get; set; }

        //public Map Image

        public BuildingModel()
        {

        }

        public BuildingModel(int bid, string bl, string bn, int rq)
        {
            this.BuildingID = bid;
            this.BuildingLabel = bl;
            this.BuildingName = bn;
            this.RoomQty = rq;
        }
    }
}