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
            
            
            bool bCheck = TableDAL.checkCurrentTableStatus(id);

            return bCheck;
        }

        public static BookingModel getDayTableBooking(int id)
        {
            BookingModel bookings = TableDAL.loadTableBookingList(id);

            return bookings;
        }

        public static bool bookTable(int id, string login, string hour)
        {
            //NEED TO ADD A CHECK STATUS FOR THE SELECTED HOUR
            bool bCheck = TableDAL.checkTableStatus(id, hour); 
            if (bCheck == true)
            {
                if (TableDAL.bookTable(id, login, hour))
                {
                    return true;
                }
            }

            return false;
        }
    }
}