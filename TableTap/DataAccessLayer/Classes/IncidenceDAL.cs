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

        public static void incAllBuildingDelete(int buildingID)
        {
            //deletes all incidents via building ID

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblIncidence WHERE buildingID=" + buildingID.ToString(), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }





        public static void incOldIncDelete()
        {
            //deletes all incidents via building ID

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblIncidence WHERE incENDDate<" + System.DateTime.Now.AddDays(-1).ToString(), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }






        public static void AddNewIncidentTable(IncidentModel incident)
        {
            // adds a incident  for a table

         IncidentModel newIncident = incident;
         SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (conn)
            {

                conn.Open();


                //reeeeeeee
                using (SqlCommand command = new SqlCommand(
                "INSERT INTO tblIncidence(incDate, info, tableID, roomID, buildingID, userID, incLevel, incENDDate) VALUES ("
                    + "'" + newIncident.Incdate.ToString() + "'" + ", "
                    + "'" + newIncident.Info + "'" + ", "
                    + "'" + newIncident.TableID + "'" + ","
                    + "'" + newIncident.RoomID + "'" + ","
                    + "'" + newIncident.buildingID + "'" + ","
                    + "'" + newIncident.UserID + "'" + ","
                    + "'" + newIncident.IncLevel + "'" + ","
                    + "'" + newIncident.IncENDDate.ToString() + "'" + ")"
                    ,
                    conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

        }





        public static void AddNewIncidentRoom(IncidentModel incident)
        {
            // adds a incident by for a room

            IncidentModel newIncident = incident;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (conn)
            {

                conn.Open();

                using (SqlCommand command = new SqlCommand(
                "INSERT INTO tblIncidence(incDate, info, roomID, userID, incLevel, buildingID) VALUES ("
                    + "'" + newIncident.Incdate.ToString() + "'" + ", "
                    + "'" + newIncident.Info + "'" + ", "
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

        public static void AddNewIncidentBuilding(IncidentModel incident)
        {
            // adds a incident by for a Building

            IncidentModel newIncident = incident;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (conn)
            {

                conn.Open();

                using (SqlCommand command = new SqlCommand(
                "INSERT INTO tblIncidence(incDate, info, userID, incLevel, buildingID) VALUES ("
                    + "'" + newIncident.Incdate.ToString() + "'" + ", "
                    + "'" + newIncident.Info + "'" + ", "
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





        public static IncidentModel searchviadateandUserID(IncidentModel user)
        {
            // searches inc table for records for user ID and date,
            // returns a incident model

            IncidentModel incident = new IncidentModel();
            try
            {

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(
                        "SELECT * FROM tblIncidence WHERE userID=" + "'" + user.UserID + "'" + " AND incDate=" + "'" + user.Incdate + "'",
                        conn))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        dr.Read();

                        incident.IncidentID = Convert.ToInt32(dr["incidenceID"].ToString());
                        incident.Incdate = DateTime.Parse(dr["incDate"].ToString());
                        incident.Info = dr["info"].ToString();
                        incident.TableID = int.Parse(dr["tableID"].ToString());
                        incident.RoomID = int.Parse(dr["roomID"].ToString());
                        incident.buildingID = int.Parse(dr["buildingID"].ToString());
                        incident.UserID = int.Parse(dr["userID"].ToString());
                        incident.IncLevel = Convert.ToBoolean(dr["incLevel"]);
                        incident.IncENDDate = Convert.ToDateTime(dr["incENDDate"]);


                        dr.Close();
                    }
                    conn.Close();
                }

                return incident;

            }
            catch
            {
                incident = null;

                return incident;
            }

            
        }


        public static List<IncidentModel> loadIncidentList()
        {
            List<IncidentModel> incidentList = new List<IncidentModel>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblIncidence",
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    IncidentModel incident;
                    while (dr.Read())
                    {
                        incident = new IncidentModel();
                        incident.IncidentID = Convert.ToInt32(dr["incidenceID"].ToString());
                        incident.Incdate = DateTime.Parse(dr["incDate"].ToString());
                        incident.Info = dr["info"].ToString();
                        incident.TableID = int.Parse(dr["tableID"].ToString());
                        incident.RoomID = int.Parse(dr["roomID"].ToString());
                        incident.buildingID = int.Parse(dr["buildingID"].ToString());
                        incident.UserID = int.Parse(dr["userID"].ToString());
                        incident.IncLevel = Convert.ToBoolean(dr["incLevel"]);
                        incident.IncENDDate = Convert.ToDateTime(dr["incENDDate"]);
                    }
                    dr.Close();
                }
                conn.Close();
            }

            return incidentList;
        }



    }






}