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
        public static TableModel getTableByID(int id)
        {
            TableModel table = new TableModel();

            table = TableDAL.loadTableByID(id);

            return table;
        }

        public static bool checkTableStatus(int id)
        {
            
            
            bool bCheck = TableDAL.checkCurrentTableStatus(id);

            return bCheck;
        }
        public static bool checkTableHourAvailability(int TableID, int Hour, DateTime dateTime)
        {
            bool bCheckHour = TableDAL.checkTableHourAvailability(TableID, Hour, dateTime);
            if (bCheckHour == true)
            {
                return true;
            }

            return false;
        }

        public static BookingModel getDayTableBooking(int id)
        {
            BookingModel bookings = TableDAL.loadTableBookingList(id);

            return bookings;
        }

        public static bool bookTable(int id, string login, string hour)
        {
            
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

        public static bool processCalanderBookTable(GroupModel groupModel)
        {
            bool bCheck = TableDAL.checkTableStatus(groupModel); //check if booking exists - return false if exists
            if (bCheck == true)
            {
                if (TableDAL.CreateCalanderBookTable(groupModel))
                {
                    return true;
                }
            }

            return false;
        }

        public static void ProcessAddNewTable(TableModel table)
        {
            TableModel newTable = table;
            try
            { }
            catch
            { }
            TableDAL.AddNewTable(table);

        }
    }
}