using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class BookingModel
    {
        public int StatusID { get; set; }

        public int TableID { get; set; }

        public DateTime Date { get; set; }

        public string Hour0 { get; set; }
        public string Hour1 { get; set; }
        public string Hour2 { get; set; }
        public string Hour3 { get; set; }
        public string Hour4 { get; set; }
        public string Hour5 { get; set; }
        public string Hour6 { get; set; }
        public string Hour7 { get; set; }
        public string Hour8 { get; set; }
        public string Hour9 { get; set; }
        public string Hour10 { get; set; }
        public string Hour11 { get; set; }
        public string Hour12 { get; set; }
        public string Hour13 { get; set; }
        public string Hour14 { get; set; }
        public string Hour15 { get; set; }
        public string Hour16 { get; set; }
        public string Hour17 { get; set; }
        public string Hour18 { get; set; }
        public string Hour19 { get; set; }
        public string Hour20 { get; set; }
        public string Hour21 { get; set; }
        public string Hour22 { get; set; }
        public string Hour23 { get; set; }

        public BookingModel()
        {

        }

        public BookingModel(int sid, int tid, DateTime date, string h0, string h1, string h2, string h3, string h4, string h5,
            string h6, string h7, string h8, string h9, string h10, string h11, string h12, string h13, string h14, string h15,
            string h16, string h17, string h18, string h19, string h20, string h21, string h22, string h23)
        {
            this.StatusID = sid;
            this.TableID = tid;
            this.Date = date;
            this.Hour0 = h0;
            this.Hour1 = h1;
            this.Hour2 = h2;
            this.Hour3 = h3;
            this.Hour4 = h4;
            this.Hour5 = h5;
            this.Hour6 = h6;
            this.Hour7 = h7;
            this.Hour8 = h8;
            this.Hour9 = h9;
            this.Hour10 = h10;
            this.Hour11 = h11;
            this.Hour12 = h12;
            this.Hour13 = h13;
            this.Hour14 = h14;
            this.Hour15 = h15;
            this.Hour16 = h16;
            this.Hour17 = h17;
            this.Hour18 = h18;
            this.Hour19 = h19;
            this.Hour20 = h20;
            this.Hour21 = h21;
            this.Hour22 = h22;
            this.Hour23 = h23;


        }
    }
}