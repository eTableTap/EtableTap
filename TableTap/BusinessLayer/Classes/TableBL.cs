﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;

namespace TableTap.BusinessLayer.Classes
{
    public class TableBL
    {
        public static List<TableModel> FillTableList(int id)
        {
            List<TableModel> tables = new List<TableModel>();

            tables = TableDAL.LoadTableList(id);

            return tables;
        }
        public static TableModel GetTableByID(int id)
        {
            TableModel table = new TableModel();

            table = TableDAL.LoadTableByID(id);

            return table;
        }


        public static bool CheckTableHourAvailability(int TableID, int Hour, DateTime dateTime)
        {
            bool bCheckHour = TableDAL.CheckTableHourAvailability(TableID, Hour, dateTime);
            if (bCheckHour == true)
            {
                return true;
            }

            return false;
        }


        public static bool ProcessCalanderBookTable(BookingModel bookingModel)
        {
            bool bCheck = TableDAL.CheckTableStatus(bookingModel); //check if booking exists - return false if exists
            if (bCheck == true)
            {
                if (TableDAL.CreateCalanderBookTable(bookingModel))
                {
                    return true;
                }
            }

            return false;
        }

        public static int GetBookingIDByBookingModel(BookingModel bookingModel) 
        {
            
            int i = TableDAL.GetBookingIDByBookingModel(bookingModel);

            return i;
        }

        public static string ProcessTableCheckin(BookingModel bookingModel)
        {
            bool bCheck = TableDAL.CheckCheckin(bookingModel); //check if booking exists - return false if exists
            if (bCheck == false)
            {
                
                    return bookingModel.emailAddress + " has successfully checked in!";
                
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