using System;
using Hangfire;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer.Classes;

namespace TableTap.BackGroundWorker.Classes
{
    public class AutomaticIncidentDeletion
    {

        public static bool startIncidentDeletionSystem()
        {
            stopTask(); // prevents build up of tasks

            try
            {
                
                RecurringJob.AddOrUpdate(
                () => incidentdeleter(),
                Cron.Daily);

                incidentdeleter();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static void incidentdeleter()
        {


        }


        public static void stopTask()
        {
            
        }



    }
}