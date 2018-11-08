using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TableTap.Models;

namespace TableTap.DataAccessLayer.Classes
{
    public class RoomDAL
    {
        public static List<RoomModel> loadRoomList(int id)
        {
            List<RoomModel> rooms = new List<RoomModel>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblRoom WHERE buildingID=" + id.ToString(),
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    RoomModel room;
                    while (dr.Read())
                    {
                        room = new RoomModel();
                        room.RoomID = Convert.ToInt32(dr["roomID"]);
                        room.RoomName = dr["roomName"].ToString();
                        room.RoomLabel = dr["roomLabel"].ToString();
                        room.TableQty = Convert.ToInt32(dr["tableQty"]);

                        rooms.Add(room);
                    }
                    dr.Close();
                }
                conn.Close();
            }

            return rooms;
        }
        public static RoomModel loadRoomByID(int id)
        {
            RoomModel room = new RoomModel();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblRoom WHERE roomID=" + id.ToString(),
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        room = new RoomModel();
                        room.RoomID = Convert.ToInt32(dr["roomID"]);
                        room.RoomName = dr["roomName"].ToString();
                        room.RoomLabel = dr["roomLabel"].ToString();
                        room.BuildingID = Convert.ToInt32(dr["buildingID"]);
                        room.TableQty = Convert.ToInt32(dr["tableQty"]);
                        room.ClosingTime = TimeSpan.Parse(dr["closingTime"].ToString());
                        room.OpeningTime = TimeSpan.Parse(dr["openingTime"].ToString());


                    }
                    dr.Close();
                }
                conn.Close();
            }

            return room;
        }
        public static void AddNewRoom(RoomModel room)
        {
            RoomModel newRoom = room;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                "INSERT INTO tblRoom (roomLabel, roomName, buildingID, tableQty) VALUES ("
                    + "'" + newRoom.RoomLabel + "'" + ", "
                    + "'" + newRoom.RoomName + "'" + ", "
                    + "'" + newRoom.BuildingID.ToString() + "'" + ", "
                    + "'" + newRoom.TableQty.ToString() + "'"
                    + ")"
                    ,
                    conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

        }
    }
}
