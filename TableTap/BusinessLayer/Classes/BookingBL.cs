using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.Models;
using TableTap.DataAccessLayer.Classes;

namespace TableTap.BusinessLayer.Classes
{
    public class BookingBL
    {
        /// <summary>
        /// Searches booking table by booking ID via BookingDAL.CheckBooking(bookingID);
        /// returns BookingModel booking
        /// </summary>
        public static BookingModel SearchBookingByID(int bookingID)
        {
            BookingModel booking = BookingDAL.CheckBooking(bookingID);

            return booking;

        }

        /// <summary>
        /// Gets the bookingID by bookingModel (TableID)   via BookingDAL.GetBookingIDByBookingModel(bookingModel)
        /// Returns bookingID
        /// </summary>
        public static int GetBookingIDByBookingModel(BookingModel bookingModel)
        {

            int bookingID = BookingDAL.GetBookingIDByBookingModel(bookingModel);

            return bookingID;
        }



        /// <summary>
        /// Calls check in function with booking Model BookingDAL.CheckCheckin(bookingModel);
        /// Returns string dependant on login success
        /// </summary>
        public static string ProcessTableCheckin(BookingModel bookingModel)
        {
            bool bCheck = BookingDAL.CheckCheckin(bookingModel); //check if booking exists - return false if exists
            if (bCheck == false)
            {

                return bookingModel.emailAddress + " has successfully checked in!";

            }

            return "Failed to check in. Booking does not exist. If you are more than 15 minutes late your booking has been deleted.";
        }


        /// <summary>
        /// Books a table with booking Model via  TableDAL.CheckTableStatus(bookingModel)
        /// If booking is successful returns bool true
        /// else returns bool false
        /// </summary>
        public static bool ProcessCalanderBookTable(BookingModel bookingModel)
        {


            bool bCheck = TableDAL.CheckTableStatus(bookingModel); //check if booking exists - return false if exists


            if (bCheck == true)
            {
                if (BookingDAL.CreateCalanderBookTable(bookingModel))
                {
                    return true;
                }
            }

            return false;
        }
    }
}