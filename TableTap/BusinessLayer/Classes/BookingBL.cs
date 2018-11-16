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

        public static BookingModel SearchBookingByID(int bookingID)
        {
            BookingModel booking = BookingDAL.CheckBooking(bookingID);

            return booking;

        }

        public static int GetBookingIDByBookingModel(BookingModel bookingModel)
        {

            int i = BookingDAL.GetBookingIDByBookingModel(bookingModel);

            return i;
        }

        public static string ProcessTableCheckin(BookingModel bookingModel)
        {
            bool bCheck = BookingDAL.CheckCheckin(bookingModel); //check if booking exists - return false if exists
            if (bCheck == false)
            {

                return bookingModel.emailAddress + " has successfully checked in!";

            }

            return "Failed to check in. Booking does not exist. If you are more than 15 minutes late your booking has been deleted.";
        }

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