using System;
using Hangfire;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer.Classes;

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
                () => emailWorker(),
                Cron.Hourly);

                emailWorker();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static List<List<string>> getData()
        {
            /// 

            string email1 = "hayden.bartlett1@hotmail.com";
            string phone = "0434346773";
            string user = "Hayden Bartlett";
            string tableid = "001";
            string roomName = "room1";
            string buildName = "building1";
            string date = "09/09/1864";
            string hour = "9.30";
            string URL = "www.URL.com";
            

            string email2 = "c3185636@uon.edu.au";
            string phone2 = "0434346773";
            string user2 = "hayden bartlett2";
            string tableid2 = "001";
            string roomName2 = "room1";
            string buildName2 = "building1";
            string date2 = "09/09/1864";
            string hour1 = "9.30";
            string URL2 = "www.URL.com";

            //for each loop through SQL results 


            List<string> dataset1 = new List<string>();
            List<string> dataset2 = new List<string>();


            dataset1.Add(user);
            dataset1.Add(phone);
            dataset1.Add(email1);
            dataset1.Add(tableid);
            dataset1.Add(roomName);
            dataset1.Add(buildName);
            dataset1.Add(date);
            dataset1.Add(hour);
            dataset1.Add(URL);


            dataset2.Add(user2);
            dataset2.Add(phone2);
            dataset2.Add(email2);
            dataset2.Add(tableid2);
            dataset2.Add(roomName2);
            dataset2.Add(buildName2);
            dataset2.Add(date2);
            dataset2.Add(hour1);
            dataset2.Add(URL2);



            List<List<string>> data = new List<List<string>>();
            data.Add(dataset1);
            data.Add(dataset2);

            return data;
        }

        public static void emailWorker()
        {
            DateTime time = System.DateTime.Now;

            List<List<string>> bookings = getData();

            foreach(List<string> booking in bookings)
            {
                NotifyBL.startNotifyBooking(booking[0], booking[1], booking[2], booking[3], booking[4], booking[5], booking[6], booking[7], booking[8]);
            }



            

        }




    }
}