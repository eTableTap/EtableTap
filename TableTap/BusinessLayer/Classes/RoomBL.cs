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

        /// <summary>
        /// Searches room table by buildingID via RoomDAL.loadRoomList(buildingId);
        /// Returns a list of rooms within a building
        /// </summary>
        public static List<RoomModel> fillRoomsList(int buildingId)
        {
            List<RoomModel> rooms = new List<RoomModel>();

            rooms = RoomDAL.loadRoomList(buildingId);

            return rooms;
        }

        /// <summary>
        /// searches for a room by its roomID via RoomDAL.loadRoomByID(roomId);
        /// returns a Room Model
        /// </summary>
        public static RoomModel getRoomByID(int roomId)
        {
            RoomModel room = new RoomModel();

            room = RoomDAL.loadRoomByID(roomId);

            return room;
        }

        /// <summary>
        /// Adds new room via RoomDAL.AddNewRoom(newRoom);
        /// Input of a Room Model
        /// </summary>
        public static void ProcessAddNewRoom(RoomModel room)
        { 
            RoomModel newRoom = room;
            RoomDAL.AddNewRoom(newRoom);

        }
    }
}