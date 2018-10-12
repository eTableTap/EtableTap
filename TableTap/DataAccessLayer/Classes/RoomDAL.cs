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
    }
}
