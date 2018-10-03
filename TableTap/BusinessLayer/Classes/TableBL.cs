using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;

namespace TableTap.BusinessLayer.Classes
{
    public class TableBL
    {
        public static List<TableModel> fillTableList(int id)
        {
            List<TableModel> tables = new List<TableModel>();

            tables = TableDAL.loadTableList(id);

            return tables;
        }

        public static bool checkTableStatus(int id)
        {
            
            
            bool bCheck = TableDAL.checkTableStatus(id);

            return bCheck;
        }

        public static BookingModel getDayTableBooking(int id)
        {
            BookingModel bookings = TableDAL.loadTableBookingList(id);

            return bookings;
        }
    }
}