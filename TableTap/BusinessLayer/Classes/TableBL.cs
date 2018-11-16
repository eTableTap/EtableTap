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


        /// <summary>
        /// searches for all tables within associated building by ID via TableDAL.LoadTableList(buildingID);
        /// Returns list of TableModels
        /// </summary>
        public static List<TableModel> FillTableList(int buildingID)
        {
            List<TableModel> tables = new List<TableModel>();

            tables = TableDAL.LoadTableList(buildingID);

            return tables;
        }


        /// <summary>
        /// searches for a table by tableID via TableDAL.LoadTableByID(tableID);
        /// returns tableModel
        /// </summary>
        public static TableModel GetTableByID(int tableID)
        {
            TableModel table = new TableModel();

            table = TableDAL.LoadTableByID(tableID);

            return table;
        }


        /// <summary>
        /// checks avalibility of table by tableID, Hour and Date via TableDAL.CheckTableHourAvailability(TableID, Hour, dateTime);
        /// returns bool if avaliable or not
        /// </summary>
        public static bool CheckTableHourAvailability(int TableID, int Hour, DateTime dateTime)
        {
            bool bCheckHour = TableDAL.CheckTableHourAvailability(TableID, Hour, dateTime);
            if (bCheckHour == true)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// adds a new table by tableModel via TableDAL.AddNewTable(table);
        /// </summary>
        public static void ProcessAddNewTable(TableModel table)
        {
            TableModel newTable = table;
            try
            {
                TableDAL.AddNewTable(table);
            }
            catch
            { }
            

        }
    }
}