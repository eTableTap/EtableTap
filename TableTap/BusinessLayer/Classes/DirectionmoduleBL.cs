﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;

namespace TableTap
{
    public class DirectionModuleBL
    {
        public static BuildingModel TESTINGdata(int num)
        {
            BuildingModel building = new BuildingModel();

            // testing placeholder
            building.street = "ICT";
            building.suburb = "Callaghan";
            building.provence = "NSW";
            building.country = "Australia";
            return building;
        }

        public static BuildingModel data(int buildingID)
        {
            BuildingModel building = new BuildingModel();

            try
            {
             building = BuildingDAL.loadBuildingByID(buildingID);
            }
            catch
            {
                building.street = "University of Newcastle";
                building.suburb = "Callaghan";
                building.provence = "NSW";
                building.country = "Australia";
            }
            return building;
        }


        public static string anLogic(int buildingID)
        {
            //android method for opening google maps (using Intent for reliability)

            BuildingModel building = data(buildingID);
            string street = building.street.Replace(" ", "+");
            string suburb = building.suburb.Replace(" ", "+");
            string provence = building.provence.Replace(" ", "+");
            //            string URL = "google.navigation:q=" + street + ",+" + addresslist[1] + ",+" + addresslist[2] + ",+" + addresslist[3]; // -- use if Intent doesnt work
            string URL = "intent://www.google.com.au/maps/dir//" + street + ",+" + suburb + ",+" + provence + ",+" + building.country
                + "#Intent;scheme=http;package=com.google.android.apps.maps;end"; // - in use as more reliable in tewsting with older phones
            return URL;
        }

        public static string iPLogic(int buildingID)
        {
            // Iphone method for opening google maps

            BuildingModel building = data(buildingID);
            string street = building.street.Replace(" ", "+");
            string suburb = building.suburb.Replace(" ", "+");
            string provence = building.provence.Replace(" ", "+");
            string URL = "comgooglemaps://?daddr=" + street + ",+" + suburb + ",+" + provence + ",+" + building.country;
            return URL;
        }

        public static string iPadLogic(int buildingID)
        {

            // Ipad method - redirects to the Iphone

            string URL = iPLogic(buildingID); // may require modification in the future based of test devices
            return URL;
        }

        public static string otherlogic(int buildingID)
        {

            // Computer method for opening googles maps (website)

            BuildingModel building = data(buildingID);
            string street = building.street.Replace(" ", "+");
            string suburb = building.suburb.Replace(" ", "+");
            string provence = building.provence.Replace(" ", "+");
            string URL = "https://www.google.com/maps/dir/?api=1&destination=" + street + ",+" + suburb + ",+" + provence + ",+" + building.country;
            return URL;
        }




        public static string start(int buildingID)
        {
            /// This method detects a device and sends it down correct code path

            string URL;

            if (HttpContext.Current.Request.UserAgent.IndexOf("Android") > 0)
            {
                URL = anLogic(buildingID);
            }
            else if (HttpContext.Current.Request.UserAgent.IndexOf("iPhone") > 0)
            {
                URL = iPLogic(buildingID);
            }
            else if (HttpContext.Current.Request.UserAgent.IndexOf("iPad") > 0)
            {
                URL = iPadLogic(buildingID);
            }
            else
            {
                URL = otherlogic(buildingID);
            }

            return URL;

        }

    }



}