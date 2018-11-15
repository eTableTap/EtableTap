using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class TableModel
    {

        public int TableID { get; set; }

        public int RoomID { get; set; }

        public int PersonCapacity { get; set; }

        public string Category { get; set; }

        public TableModel()
        {

        }

        public TableModel(int tid, int rid, int pca, string cat)
        {
            this.TableID = tid;
            this.RoomID = rid;
            this.PersonCapacity = pca;
            this.Category = cat;
        }
    }
}