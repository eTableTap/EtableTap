using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;

namespace TableTap.DataAccessLayer.Classes
{
    public class TableDAL
    {

        public static void AddNewTable(TableModel table)
        {
            TableModel newTable = table;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();



               /* using (SqlCommand command = new SqlCommand(
                "INSERT INTO tblTable (emailAddress, passcode, firstName, lastName, adminPermission) VALUES ("
                    + "'" + newTable.Email.ToString() + "'" + ", "

                    + ")"
                    ,
                    conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close(); */
            }

        }
        //Add user with input strings from registration page
        /*public void AddTable(string TableQR, int RoomID, int PersonCapacity, string Category, Boolean Reservable)
        {
            string DBConn;
            DBConn = ConfigurationManager.ConnectionStrings["udbTableTapConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();

                using (SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO tblTable (tableQR, roomID, personCapacity, category, reservable) VALUES (@tableQR, @roomID, @personCapacity, @category, @reservable)";

                    command.Parameters.AddWithValue("@tableQR", TableQR);
                    command.Parameters.AddWithValue("@roomID", RoomID);
                    command.Parameters.AddWithValue("@personCapacity", PersonCapacity);
                    command.Parameters.AddWithValue("@category", Category);
                    command.Parameters.AddWithValue("@reservable", Reservable);

                    int result = command.ExecuteNonQuery();
                }

            }
        }*/
        public static List<TableModel> loadTableList(int id)
        {
            List<TableModel> tables = new List<TableModel>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblTable WHERE roomID=" + id.ToString(),
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    TableModel table;
                    while (dr.Read())
                    {
                        table = new TableModel();
                        table.TableID = Convert.ToInt32(dr["tableID"]);
                        table.RoomID = Convert.ToInt32(dr["tableID"]);
                        table.PersonCapacity = Convert.ToInt32(dr["personCapacity"]);
                        table.Category = dr["category"].ToString();

                        tables.Add(table);
                    }
                    dr.Close();
                }
                conn.Close();
            }

            return tables;
        }

        public static BookingModel loadTableBookingList(int id)
        {
            BookingModel bookings = new BookingModel();

            DateTime dateNow = DateTime.Now;
            string date = dateNow.ToString("yyyy-MM-d");

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblStatus WHERE tableID=" + "'" + id.ToString() + "'" + " AND date=" + "'" + date + "'",
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();

                    dr.Read();             

                        bookings.StatusID = Convert.ToInt32(dr["StatusID"]);
                        bookings.TableID = Convert.ToInt32(dr["TableID"]);
                        bookings.Date = DateTime.Parse(dr["Date"].ToString());
                        bookings.Hour[0] = dr["hour00"].ToString();
                        bookings.Hour[1] = dr["hour01"].ToString();
                        bookings.Hour[2] = dr["hour02"].ToString();
                        bookings.Hour[3] = dr["hour03"].ToString();
                        bookings.Hour[4] = dr["hour04"].ToString();
                        bookings.Hour[5] = dr["hour05"].ToString();
                        bookings.Hour[6] = dr["hour06"].ToString();
                        bookings.Hour[7] = dr["hour07"].ToString();
                        bookings.Hour[8] = dr["hour08"].ToString();
                        bookings.Hour[9] = dr["hour09"].ToString();
                        bookings.Hour[10] = dr["hour10"].ToString();
                        bookings.Hour[11] = dr["hour11"].ToString();
                        bookings.Hour[12] = dr["hour12"].ToString();
                        bookings.Hour[13] = dr["hour13"].ToString();
                        bookings.Hour[14] = dr["hour14"].ToString();
                        bookings.Hour[15] = dr["hour15"].ToString();
                        bookings.Hour[16] = dr["hour16"].ToString();
                        bookings.Hour[17] = dr["hour17"].ToString();
                        bookings.Hour[18] = dr["hour18"].ToString();
                        bookings.Hour[19] = dr["hour19"].ToString();
                        bookings.Hour[20] = dr["hour20"].ToString();
                        bookings.Hour[21] = dr["hour21"].ToString();
                        bookings.Hour[22] = dr["hour22"].ToString();
                        bookings.Hour[23] = dr["hour23"].ToString();
                    /*
                    bookings.Hour0 = dr["hour00"].ToString();
                    bookings.Hour1 = dr["hour01"].ToString();
                    bookings.Hour2 = dr["hour02"].ToString();
                    bookings.Hour3 = dr["hour03"].ToString();
                    bookings.Hour4 = dr["hour04"].ToString();
                    bookings.Hour5 = dr["hour05"].ToString();
                    bookings.Hour6 = dr["hour06"].ToString();
                    bookings.Hour7 = dr["hour07"].ToString();
                    bookings.Hour8 = dr["hour08"].ToString();
                    bookings.Hour9 = dr["hour09"].ToString();
                    bookings.Hour10 = dr["hour10"].ToString();
                    bookings.Hour11 = dr["hour11"].ToString();
                    bookings.Hour12 = dr["hour12"].ToString();
                    bookings.Hour13 = dr["hour13"].ToString();
                    bookings.Hour14 = dr["hour14"].ToString();
                    bookings.Hour15 = dr["hour15"].ToString();
                    bookings.Hour16 = dr["hour16"].ToString();
                    bookings.Hour17 = dr["hour17"].ToString();
                    bookings.Hour18 = dr["hour18"].ToString();
                    bookings.Hour19 = dr["hour19"].ToString();
                    bookings.Hour20 = dr["hour20"].ToString();
                    bookings.Hour21 = dr["hour21"].ToString();
                    bookings.Hour22 = dr["hour22"].ToString();
                    bookings.Hour23 = dr["hour23"].ToString();
                    */

                    dr.Close();
                }
                conn.Close();
            }

            return bookings;
        }

        public static bool checkTableStatus(int id)
        {
            bool hasData = false; //for testing purpuses
            string sTest = "default - this should not matter";
            

            DateTime dateNow = DateTime.Now;
            //string hour = dateNow.ToString("HH");
            string date = dateNow.ToString("yyyy-MM-d");
            string dateYear = dateNow.ToString("yyyy");
            string dateMonth = dateNow.ToString("MM");
            string dateDay = dateNow.ToString("Day");
            //string date = dateNow.ToString("dd/MM/yyyy");
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT hour" + dateNow.ToString("HH").ToString() + " FROM tblStatus WHERE tableID=" + "'" + id.ToString() + "'" + " AND date=" + "'" + date + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        sTest = dr["hour"+dateNow.ToString("HH")].ToString();
                    }
                    dr.Close();
                }
                conn.Close();
            }

            if (sTest.Contains("Free"))
            {
                //sTest = "This table is currently availabile! Times below are also available";
                return true;
            }
            /*else
            {
                sTest = "This table is Occupied. Times below are available";
            }*/

            return false;
        }





        /// <summary>
        ///  For accessing table data, returns list full of table info
        /// </summary>

        public static List<string> LoadTable(string tableID)
        {

            List<string> tableRecord = new List<string>();



            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblTable WHERE tableID=" + "'" + tableID + "'", conn))
                {


                    SqlDataReader dr = command.ExecuteReader();
                    dr.Read();

                    try
                    {

                        string roomID = dr["roomID"].ToString();
                        string personCapacity = dr["personCapacity"].ToString();
                        string category = dr["category"].ToString();
                        

                        tableRecord.Add(tableID);
                        tableRecord.Add(roomID);
                        tableRecord.Add(personCapacity);
                        tableRecord.Add(category);


                        dr.Close();

                        return tableRecord;
                    }
                    catch
                    {
                        tableRecord = null;

                        return tableRecord;
                    }
                }

                conn.Close();
            }


        }


        /// <summary>
        /// Modifys table record from associated tableID passed in
        /// Uses list (tabledata) to store all data
        /// </summary>
        public static void modifyTable(List<string> tableData)
        {
            string tableID = tableData[0];
            string roomID = tableData[1];
            string personCapacity = tableData[2];
            string category = tableData[3];

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand modify = new SqlCommand();
            SqlDataReader reader;
            modify.CommandText = "UPDATE tblTable SET roomID=" + "'" + roomID + "', personCapacity=" + "'" + personCapacity + "', category='" + category 
                + "' WHERE tableID=" + "'" + tableID + "'";
            modify.CommandType = System.Data.CommandType.Text;
            modify.Connection = conn;
            conn.Open();
            reader = modify.ExecuteReader();

            conn.Close();



        }

        /// <summary>
        /// deletes table associated with tableID
        /// </summary>
        public static void deleteTable(string tableID)
        {
            UserModel newUser = new UserModel();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblTable WHERE tableID=" + tableID, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

        }
    }
}