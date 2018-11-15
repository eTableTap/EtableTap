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





        public static bool CreateCalanderBookTable(BookingModel bookingModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                BookingModel newBookingModel = bookingModel;

                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(

                        "INSERT INTO tblBooking (TableID, bookingDate, emailAddress, bookingHour, memberEmail, memberEmail1, memberEmail2, memberEmail3, memberEmail4) VALUES ("
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




        public static BookingModel CheckBooking(int bookingIDE)
        {
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


    }



}