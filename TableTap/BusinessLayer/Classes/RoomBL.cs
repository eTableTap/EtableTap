using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;

namespace TableTap.BusinessLayer.Classes
{
    public class RoomBL
    {
        public static List<RoomModel> fillRoomsList(int id)
        {
            List<RoomModel> rooms = new List<RoomModel>();

            rooms = RoomDAL.loadRoomList(id);

            return rooms;
        }
        public static RoomModel getRoomByID(int id)
        {
            RoomModel room = new RoomModel();

            room = RoomDAL.loadRoomByID(id);

            return room;
        }
    }
}