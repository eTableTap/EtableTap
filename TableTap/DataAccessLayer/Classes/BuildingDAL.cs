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
    }
}