using System;
using Hangfire;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;

namespace TableTap.BackGroundWorker.Classes
{
    public class EmailQueuing
    {

        public static void stopEmail()
        {
            /// stops the EmailNotification hangfire task (01)
            /// 

            RecurringJob.RemoveIfExists("01");
        }

        public static bool startEmailNotificationSystem()
        {
            /// creates hangfire task to send hourly reminder email notifications
            /// returns a true if job starts successfully, a false if there is an error

            stopEmail();

            try
            {

                RecurringJob.AddOrUpdate("01",
                () => startEmailWorker(),
                Cron.Hourly);

                startEmailWorker();

                return true;
            }
            catch
            {
                return false;
            }
        }



        public static void startEmailWorker()
        {
            // main Email worker, searches for any bookings in the next hour
            // via the booking table, searches user, room and building tables for associated data
            // loops through each booking sending email notifications via NotifyBL
            


            List<BookingModel> groups = new List<BookingModel>();


            groups = BookingDAL.loadBookingListattime();


            // loops through each booking returned by BookingDAL.loadBookingListattime();
            foreach (BookingModel booking in groups)
            {
                List<string> dataset1 = new List<string>();

                string URL = "https://www.etabletap.com/UL/BookingReceipt.aspx?id=" +  booking.bookingID;

                UserModel user = new UserModel();
                TableModel table = new TableModel();
                RoomModel room = new RoomModel();
                BuildingModel building = new BuildingModel();


                table = TableBL.GetTableByID(booking.tableID);

                user = UserBL.passUserSearch(booking.emailAddress);

                room = RoomBL.getRoomByID(table.RoomID);

                building = BuildingBL.getBuildingByID(room.BuildingID);


                // main user
                NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, user.Email , table.TableID.ToString(),
                    room.RoomName, building.BuildingName, booking.bookingDate.ToString(), booking.bookingHour.ToString() + ":00", URL);

                //booking member 1
                try
                { 
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, booking.memberEmail1, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, booking.bookingDate.ToString(), booking.bookingHour.ToString() + ":00", URL);
                }
                catch
                {

                }

                // booking member 2
                try
                {
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, booking.memberEmail2, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, booking.bookingDate.ToString(), booking.bookingHour.ToString() + ":00", URL);
                }
                catch
                {

                }

                // groupmember 3
                try
                {
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, booking.memberEmail3, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, booking.bookingDate.ToString(), booking.bookingHour.ToString() + ":00", URL);
                }
                catch
                {

                }

                // booking member 4
                try
                {
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, booking.memberEmail4, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, booking.bookingDate.ToString(), booking.bookingHour.ToString() + ":00", URL);
                }
                catch
                {

                }

                // groupmember 5
                try
                {
                    NotifyBL.startNotifyBooking(user.FirstName + " " + user.LastName, user.phoneNum, booking.memberEmail5, table.TableID.ToString(),
                    room.RoomName, building.BuildingName, booking.bookingDate.ToString(), booking.bookingHour.ToString() + ":00", URL);
                }
                catch
                {

                }
            }

        }






    }
}