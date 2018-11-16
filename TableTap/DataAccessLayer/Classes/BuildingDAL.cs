using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TableTap.Models;

namespace TableTap.DataAccessLayer.Classes
{
    public class BuildingDAL
    {

        /// <summary>
        /// adds new building to database via building model
        /// </summary>
        public static void AddNewBuilding(BuildingModel building)
        {
            BuildingModel newBuilding = building;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                "INSERT INTO tblBuilding (buildingLabel, buildingName, roomQty) VALUES ("
                    + "'" + newBuilding.BuildingLabel + "'" + ", "
                    + "'" + newBuilding.BuildingName + "'" + ", "
                    + "'" + newBuilding.RoomQty.ToString() + "'"
                    + ")"
                    ,
                    conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

        }


        /// <summary>
        /// returns complete list of all records in building table
        /// as a list of building models
        /// </summary>
        public static List<BuildingModel> loadBuildingList()
        {
            List<BuildingModel> buildings = new List<BuildingModel>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblBuilding",
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    BuildingModel building;
                    while (dr.Read())
                    {
                        building = new BuildingModel();
                        building.BuildingID = Convert.ToInt32(dr["buildingID"]);
                        building.BuildingName = dr["buildingName"].ToString();
                        building.BuildingLabel = dr["buildingLabel"].ToString();
                        building.RoomQty = Convert.ToInt32(dr["roomQty"]);
                        
                        buildings.Add(building);
                    }
                    dr.Close();
                }
                conn.Close();
            }

            return buildings;
        }


        /// <summary>
        /// Loads a building record by building ID
        /// returns as a building Model
        /// </summary>
        public static BuildingModel loadBuildingByID(int id)
        {
            BuildingModel building = new BuildingModel();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblBuilding WHERE buildingID=" + "'"+id+"'",
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        building = new BuildingModel();
                        building.BuildingID = Convert.ToInt32(dr["buildingID"]);
                        building.BuildingName = dr["buildingName"].ToString();
                        building.BuildingLabel = dr["buildingLabel"].ToString();
                        building.RoomQty = Convert.ToInt32(dr["roomQty"]);
                        building.street = dr["street"].ToString();
                        building.suburb = dr["suburb"].ToString();
                        building.provence = dr["provence"].ToString();
                        building.country = dr["country"].ToString();


                    }
                    dr.Close();
                }
                conn.Close();
            }

            return building;
        }
    }
}