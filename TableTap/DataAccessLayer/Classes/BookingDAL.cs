using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TableTap.Models;

namespace TableTap.DataAccessLayer.Classes
{
    public class BookingDAL
    {

        /// <summary>
        /// Deletes users by emailaddress
        /// </summary>
        public static void BookingAllUserDelete(string emailAddress)
        {

            //delete all records in booking via user email

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblBooking WHERE emailAddress=" + emailAddress, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }


        /// <summary>
        /// gets bookingID by booking Model (tableID)
        /// returns BookingID
        /// </summary>
        public static int GetBookingIDByBookingModel(BookingModel bookingModel)
        {
            // when a booking is made the ID is auto generated. This uses data that created the booking to get the ID 
            // so we can go to the recipt page
            int iTest = 0;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT bookingID FROM tblBooking WHERE tableID=" + "'" + bookingModel.tableID.ToString() + "'"
                    + " AND bookingDate=" + "'" + bookingModel.bookingDate.ToString("yyyy-MM-d") + "'"
                    + " AND bookingHour=" + "'" + bookingModel.bookingHour.ToString() + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        iTest = Convert.ToInt32(dr["bookingID"].ToString());

                    }
                    dr.Close();

                }
                conn.Close();

            }


            return iTest;
        }


        /// <summary>
        /// Fetches booking associated with bookingID
        /// returns booking as booking model
        /// </summary>
        public static BookingModel CheckBooking(int bookingIDE)
        {
            //gives back a booking from the ID given
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            BookingModel booking = new BookingModel();

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblBooking WHERE bookingID=" + "'" + bookingIDE.ToString() + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();
                    dr.Read();

                


                    booking.bookingID = bookingIDE;
                    booking.tableID = int.Parse(dr["tableID"].ToString());
                    booking.bookingDate = DateTime.Parse(dr["bookingDate"].ToString());
                    booking.emailAddress = dr["emailAddress"].ToString();
                    booking.bookingHour = int.Parse(dr["bookingHour"].ToString());
                    booking.memberEmail1 = dr["memberEmail1"].ToString();
                    booking.memberEmail2 = dr["memberEmail2"].ToString();
                    booking.memberEmail3 = dr["memberEmail3"].ToString();
                    booking.memberEmail4 = dr["memberEmail4"].ToString();
                    booking.memberEmail5 = dr["memberEmail5"].ToString();

                    dr.Close();
                }
                conn.Close();
            }

            return booking;
    
        }



        /// <summary>
        /// Creates a booking by Booking Model
        /// Returns bool true if successful
        /// else retuns false
        /// </summary>
        public static bool CreateCalanderBookTable(BookingModel bookingModel)
        {
            //creates a booking for a specific time given
            //both booking buttons ended up using this because it can be fed the current date
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                BookingModel newBookingModel = bookingModel;

                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(

                        "INSERT INTO tblBooking (TableID, bookingDate, emailAddress, bookingHour, memberEmail1, memberEmail2, memberEmail3, memberEmail4, memberEmail5) VALUES ("
                        + "'" + newBookingModel.tableID + "'" + ", "
                        + "'" + newBookingModel.bookingDate.ToString("yyyy-MM-d") + "'" + ", "
                        + "'" + newBookingModel.emailAddress + "'" + ", "
                        + "'" + newBookingModel.bookingHour + "'" + ", "
                        + "'" + newBookingModel.memberEmail1 + "'" + ", "
                        + "'" + newBookingModel.memberEmail2 + "'" + ", "
                        + "'" + newBookingModel.memberEmail3 + "'" + ", "
                        + "'" + newBookingModel.memberEmail4 + "'" + ", "
                        + "'" + newBookingModel.memberEmail5 + "'" + ")"
                        ,
                        conn))
                    {
                        SqlDataReader dr = command.ExecuteReader();

                        dr.Close();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// Loads all bookings for current time
        /// returns list of bookings
        /// </summary>
        public static List<BookingModel> loadBookingListattime()
        {
            List<BookingModel> bookings = new List<BookingModel>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblBooking WHERE bookingHour = " + "'" + System.DateTime.Now.AddHours(1).ToString("HH") + "'" + " AND  bookingDate =" + "'"
                    + System.DateTime.Now.ToString("yyyy-MM-d") + "'",
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    BookingModel booking;
                    while (dr.Read())
                    {

                        booking = new BookingModel();
                        booking.bookingID = Convert.ToInt32(dr["bookingID"].ToString());
                        booking.tableID = Convert.ToInt32(dr["tableID"].ToString());
                        booking.bookingDate = Convert.ToDateTime(dr["bookingDate"].ToString());
                        booking.emailAddress = dr["emailAddress"].ToString();
                        booking.bookingHour = Convert.ToInt32(dr["bookingHour"].ToString());
                        booking.memberEmail1 = dr["memberEmail1"].ToString();
                        booking.memberEmail2 = dr["memberEmail2"].ToString();
                        booking.memberEmail3 = dr["memberEmail3"].ToString();
                        booking.memberEmail4 = dr["memberEmail4"].ToString();
                        booking.memberEmail5 = dr["memberEmail5"].ToString();

                        bookings.Add(booking);

                    }

                    dr.Close();
                }

                conn.Close();
            }

            return bookings;
        }


        /// <summary>
        /// Checks if a table is able to be check into. Will check in if able.
        /// Returns false if it checks in
        /// Returns true if it is unable to check in
        /// </summary>
        public static bool CheckCheckin(BookingModel bookingModel)
        {

            string sTest = null;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblBooking WHERE tableID=" + "'" + bookingModel.tableID.ToString() + "'"
                    + " AND bookingDate=" + "'" + bookingModel.bookingDate.ToString("yyyy-MM-d") + "'"
                    + " AND bookingHour=" + "'" + bookingModel.bookingHour.ToString() + "'"
                    + " AND emailAddress=" + "'" + bookingModel.emailAddress + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        sTest = dr["emailAddress"].ToString();

                    }
                    dr.Close();

                }
                conn.Close();

            }

            if (sTest == null)
            {



                return true; //  = not exist or wrong user
            }
            else
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(
                        "UPDATE tblBooking SET checkinStatus = 1 WHERE tableID=" + "'" + bookingModel.tableID.ToString() + "'"
                        + " AND bookingDate=" + "'" + bookingModel.bookingDate.ToString("yyyy-MM-d") + "'"
                        + " AND bookingHour=" + "'" + bookingModel.bookingHour.ToString() + "'"
                        + " AND emailAddress=" + "'" + bookingModel.emailAddress + "'",
                        conn))


                    {
                        SqlDataReader dr = command.ExecuteReader();


                    }
                    conn.Close();

                    return false; // = table can be checked into
                }

            }


        }
    }



}