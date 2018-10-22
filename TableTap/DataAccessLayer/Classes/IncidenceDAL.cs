using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TableTap.Models;

namespace TableTap.DataAccessLayer.Classes
{
    public class IncidenceDAL
    {
        // deletes all incidences made by a user
        // input: userID
        // output: NA
        public static void incAllUserDelete(int userID)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblIncidence WHERE userID=" + userID.ToString(), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }


        // deletes all incidences by room
        // Input: roomID
        // Output: NA

        public static void incAllRoomDelete(int roomID)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblIncidence WHERE roomID=" + roomID.ToString(), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }



        // deletes all incidences by tableID
        // input: tableID
        // output: NA
        public static void incAllTableDelete(int tableID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblIncidence WHERE tableID=" + tableID.ToString(), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }


        public static void AddNewIncident(IncidentModel incident)
        {
         IncidentModel newIncident = incident;
         SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
         using (conn)
        {
                conn.Open();


                //reeeeeeee
                using (SqlCommand command = new SqlCommand(
                "INSERT INTO tblIncidence(incDate, info, tableID, roomID, userID, incLevel, buildingID) VALUES ("
                    + "'" + newIncident.Incdate.ToString() + "'" + ", "
                    + "'" + newIncident.Info + "'" + ", "
                    + "'" + newIncident.TableID + "'" + ","
                    + "'" + newIncident.RoomID + "'" + ","
                    + "'" + newIncident.UserID + "'" + ","
                    + "'" + newIncident.IncLevel + "'" + ","
                    + "'" + newIncident.buildingID + "'" + ")"
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