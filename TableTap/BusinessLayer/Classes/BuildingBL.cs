using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;

namespace TableTap.BusinessLayer.Classes
{
    public class BuildingBL
    {
        /// <summary>
        /// Passes inputted building model
        /// to the AddNewBuilding method in BuildingDAL
        /// to be added to the database
        /// </summary>
        public static void ProcessAddNewBuilding(BuildingModel building)
        {
            BuildingModel newBuilding = building;

            BuildingDAL.AddNewBuilding(newBuilding);

        }


        /// <summary>
        /// calls BuildingDAL.loadBuildingList() to access all building
        /// records
        /// Returns a list of all buildingModels found in database
        /// </summary>
        public static List<BuildingModel> fillBuildingsList()
        {
            List<BuildingModel> buildings = new List<BuildingModel>();

            buildings = BuildingDAL.loadBuildingList();

            return buildings;
        }


        /// <summary>
        /// calls BuildingDAL.loadBuildingByID(id) to search building table 
        /// bu building ID
        /// Returns a buildingModel found in database
        /// </summary>
        public static BuildingModel getBuildingByID(int id)
        {
            BuildingModel building = new BuildingModel();

            building = BuildingDAL.loadBuildingByID(id);

            return building;
        }

    }
}