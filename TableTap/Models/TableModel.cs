using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class TableModel
    {

        public int TableID { get; set; }

        //public string TableQR { get; set; }

        public int RoomID { get; set; }

        public int PersonCapacity { get; set; }

        public string Category { get; set; }

        //public bool Available { get; set; }

        //public bool Reserable { get; set; }

        public TableModel()
        {

        }

        public TableModel(int tid, /*string tqr,*/ int rid, int pca, string cat/*, bool avi, bool res*/)
        {
            this.TableID = tid;
            //this.TableQR = tqr;
            this.RoomID = rid;
            this.PersonCapacity = pca;
            this.Category = cat;
            //this.Available = avi;
            //this.Reserable = res;
        }
    }
}