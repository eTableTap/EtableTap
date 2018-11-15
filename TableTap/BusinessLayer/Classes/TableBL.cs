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


        public static bool checkTableHourAvailability(int TableID, int Hour, DateTime dateTime)
        {
            bool bCheckHour = TableDAL.checkTableHourAvailability(TableID, Hour, dateTime);
            if (bCheckHour == true)
            {
                return true;
            }

            return false;
        }


        public static bool processCalanderBookTable(BookingModel groupModel)
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

        public static int getGroupIntByGroupModel(BookingModel groupModel)
        {
            int i = TableDAL.getGroupIDByGroupModel(groupModel);

            return i;
        }

        public static string processTableCheckin(BookingModel groupModel)
        {
            bool bCheck = TableDAL.checkCheckin(groupModel); //check if booking exists - return false if exists
            if (bCheck == false)
            {
                
                    return groupModel.emailAddress + " has successfully checked in!";
                
            }

            return "Failed to check in";
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