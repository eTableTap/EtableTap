using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.Models;
using TableTap.DataAccessLayer.Classes;

namespace TableTap.BusinessLayer.Classes
{
    public class IncidenceBL
    {
        /// <summary>
        ///  THIS FUNCTION HAS NOT BEEN FULLY IMPLEMENTED
        ///  Designed to act as a reporting/notification module for users and admins
        /// </summary>



        /// <summary>
        ///  Searches for all Incidences created via IncidenceDAL.loadIncidentList();
        ///  returns list of IncidentModels
        /// </summary>
        public static List<IncidentModel> GetIncidentList()
        {
            List<IncidentModel> incidences = new List<IncidentModel>();

            incidences = IncidenceDAL.loadIncidentList();

            return incidences;
        }



        /// <summary>
        /// Deletes incident by Incident ID via IncidenceDAL.DeleteIncidentByID(incID);
        /// </summary>
        public static void DeleteRow(int incID)
        {
            IncidenceDAL.DeleteIncidentByID(incID);
 
        }


        /// <summary>
        /// Updates status to the value of I (1 or 0)
        /// 
        /// </summary>
        public static void EditStatus(int i)
        {
            IncidenceDAL.EditIncidentStatusByID(i);

        }


        /// <summary>
        /// Passes Incident Model to IncidenceDAL.AddNewIncidentTable(incident);
        /// Creates new Incident
        /// </summary>
        public static void datalayerpassadd(IncidentModel incident)
        {
            try
            {

                IncidenceDAL.AddNewIncidentTable(incident);
            }
            catch
            {
                // insulation
            }



        }

        /// <summary>
        /// Searches Incidence table by date and User ID usinf a incidence Model
        /// Via IncidenceDAL.searchviadateandUserID(user);
        /// 
        /// </summary>
        public static IncidentModel searchviadateandUserID(IncidentModel user)
        {
            IncidentModel incident = IncidenceDAL.searchviadateandUserID(user);

            return incident;
        }



        /// <summary>
        /// Checks if user has created a Incident in the same day
        /// returns bool false if no incident created
        /// else returns true
        /// </summary>
        public static bool spamPrevention(IncidentModel user)
        {
            IncidentModel incident = searchviadateandUserID(user);



            if(incident == null)
            {
                return false;
            }
            else
            {
                return true;
            }



        }


        /// <summary>
        /// Deletes all incidents made by a user by userID via IncidenceDAL.incAllUserDelete(id);
        /// </summary>
        public static void passUserDelete(int id)
        {
            try
            {

                IncidenceDAL.incAllUserDelete(id);
            }
            catch
            {

            }
        }


        /// <summary>
        /// Deletes all incidents associated with a table by tableID via IncidenceDAL.incAllTableDelete(id);
        /// </summary>
        public static void passTableDelete(int id)
        {
            try
            {

                IncidenceDAL.incAllTableDelete(id);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Deletes all incidents associated with a room by roomID via IncidenceDAL.incAllRoomDelete(id);
        /// </summary>
        public static void passRoomDelete(int id)
        {
            try
            {

                IncidenceDAL.incAllRoomDelete(id);
            }
            catch
            {

            }
        }


        /// <summary>
        /// Deletes all incidents associated with a building by buildingID via IncidenceDAL.incAllBuildingDelete(id);
        /// </summary>
        public static void passBuildingDelete(int id)
        {
            try
            {

                IncidenceDAL.incAllBuildingDelete(id);
            }
            catch
            {

            }
        }


    }
}