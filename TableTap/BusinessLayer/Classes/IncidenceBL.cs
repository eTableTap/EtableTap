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

                IncidenceDAL.AddNewIncident(incident);
            }
            catch
            {
                // insulation
            }



        }

    }
}