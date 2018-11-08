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


        public static IncidentModel searchviadateandUserID(IncidentModel user)
        {
            IncidentModel incident = IncidenceDAL.searchviadateandUserID(user);

            return incident;
        }

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