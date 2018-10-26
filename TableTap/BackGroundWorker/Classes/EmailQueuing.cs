using System;
using Hangfire;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.BusinessLayer;
using TableTap.DataAccessLayer;

namespace TableTap.BackGroundWorker.Classes
{
    public class EmailQueuing
    {


        public static bool startEmailNotificationSystem()
        {
            try
            {
                RecurringJob.AddOrUpdate(
                () => emailWorker(),
                Cron.Hourly);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static void emailWorker()
        {
            DateTime time = System.DateTime.Now;


        }




    }
}