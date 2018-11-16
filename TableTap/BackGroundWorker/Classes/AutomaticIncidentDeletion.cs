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
            // starts automatic deletion of old incidents in the incident
            // table

            stopTask(); // prevents build up of tasks

            try
            {
                RecurringJob.RemoveIfExists("02");
                RecurringJob.AddOrUpdate("02",
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
            // calls a IncidentDAL method deleting all old incidents

            IncidenceDAL.incOldIncDelete();
        }


        public static void stopTask()
        {
            
            // stops any existing job with ID 02 (the job ID of the incident deletion background task)

            RecurringJob.RemoveIfExists("02");
        }



    }
}