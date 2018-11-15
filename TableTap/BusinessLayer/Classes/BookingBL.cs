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
    }
}