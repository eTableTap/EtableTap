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

//


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

                using (SqlCommand command = new SqlCommand(
                "INSERT INTO tblTable (roomID, personCapacity, Category) VALUES ("
                    + "'" + newTable.RoomID.ToString() + "'" + ", "
                    + "'" + newTable.PersonCapacity.ToString() + "'" + ", "
                    + "'" + newTable.Category + "'" + ")"
                    ,
                    conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

        }
       
        public static List<TableModel> LoadTableList(int id)
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
                        table.RoomID = Convert.ToInt32(dr["roomID"]);
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

        public static TableModel LoadTableByID(int id)
        {

            TableModel table = new TableModel();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblTable WHERE tableID=" + id.ToString(),
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        table.TableID = Convert.ToInt32(dr["tableID"]);
                        table.RoomID = Convert.ToInt32(dr["roomID"]);
                        table.PersonCapacity = Convert.ToInt32(dr["personCapacity"]);
                        table.Category = dr["category"].ToString();


                    }
                    dr.Close();
                }
                conn.Close();
            }

            return table;
        }

        public static bool CheckTableHourAvailability(int TableID, int Hour, DateTime date)
        {
           

            string sTest = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblBooking WHERE tableID=" + "'" + TableID.ToString() + "'"
                    + " AND bookingDate=" + "'" + date.ToString("yyyy-MM-d") + "'"
                    + " AND bookingHour=" + "'" + Hour.ToString() + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        sTest = dr["bookingHour"].ToString();
                    }
                    dr.Close();
                }
                conn.Close();
            }
            if (sTest != null)
            {
                return true;
            }


            return false;
        }

        public static bool CreateCalanderBookTable(BookingModel bookingModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                BookingModel newBookingModel = bookingModel;

                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(

                        "INSERT INTO tblBooking (TableID, bookingDate, emailAddress, bookingHour, memberEmail1, memberEmail2, memberEmail3, memberEmail4, memberEmail5) VALUES ("
                        + "'" + newBookingModel.tableID + "'" + ", "
                        + "'" + newBookingModel.bookingDate.ToString("yyyy-MM-d") + "'" + ", "
                        + "'" + newBookingModel.emailAddress + "'" + ", "
                        + "'" + newBookingModel.bookingHour + "'" + ", "
                        + "'" + newBookingModel.memberEmail1 + "'" + ", "
                        + "'" + newBookingModel.memberEmail2 + "'" + ", "
                        + "'" + newBookingModel.memberEmail3 + "'" + ", "
                        + "'" + newBookingModel.memberEmail4 + "'" + ", "
                        + "'" + newBookingModel.memberEmail5 + "'" + ")"
                        ,
                        conn))
                    {
                        SqlDataReader dr = command.ExecuteReader();

                        dr.Close();
                    }
                    conn.Close();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool CheckTableStatus(BookingModel bookingModel)
        {

            string sTest = null;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblBooking WHERE tableID=" + "'" + bookingModel.tableID.ToString() + "'"
                    + " AND bookingDate=" + "'" + bookingModel.bookingDate.ToString("yyyy-MM-d") + "'"
                    + " AND bookingHour=" + "'" + bookingModel.bookingHour.ToString() + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        sTest = dr["bookingHour"].ToString();
   
                    }
                    dr.Close();

                }
                conn.Close();

            }

            if (sTest == null)
            {
                return true; //  = available to book
            }

            return false; // = table is already booked
        }

        public static bool CheckCheckin(BookingModel bookingModel)
        {

            string sTest = null;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblBooking WHERE tableID=" + "'" + bookingModel.tableID.ToString() + "'"
                    + " AND bookingDate=" + "'" + bookingModel.bookingDate.ToString("yyyy-MM-d") + "'"
                    + " AND bookingHour=" + "'" + bookingModel.bookingHour.ToString() + "'"
                    + " AND emailAddress=" + "'" + bookingModel.emailAddress + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {

                        sTest = dr["emailAddress"].ToString();

                    }
                    dr.Close();

                }
                conn.Close();

            }

            if (sTest == null)
            {



                return true; //  = not exist or wrong user
            }
            else
            {


                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(
                        "UPDATE tblBooking SET checkinStatus = 1 WHERE tableID=" + "'" + bookingModel.tableID.ToString() + "'"
                        + " AND bookingDate=" + "'" + bookingModel.bookingDate.ToString("yyyy-MM-d") + "'"
                        + " AND bookingHour=" + "'" + bookingModel.bookingHour.ToString() + "'"
                        + " AND emailAddress=" + "'" + bookingModel.emailAddress + "'",
                        conn))


                    {
                        SqlDataReader dr = command.ExecuteReader();

                        /* while (dr.Read())
                         {

                             sTest = dr["emailAddress"].ToString();

                         }
                         dr.Close();*/

                    }
                    conn.Close();

                    return false; // = table can be checked into
                }

            }

            
        }
        
        //decalred but not use/////////////////////////////////////////////////////////////////////////////////////////////////
            
        public static int GetBookingIDByBookingModel(BookingModel bookingModel)
        {

            int iTest = 0;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT bookingID FROM tblBooking WHERE tableID=" + "'" + bookingModel.tableID.ToString() + "'"
                    + " AND bookingDate=" + "'" + bookingModel.bookingDate.ToString("yyyy-MM-d") + "'"
                    + " AND bookingHour=" + "'" + bookingModel.bookingHour.ToString() + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();

                    while (dr.Read())
                    {
                        iTest = Convert.ToInt32(dr["bookingID"].ToString());

                    }
                    dr.Close();

                }
                conn.Close();

            }

            
            return iTest; 
        }
        

        public static List<string> LoadTable(string tableID)
        {
            /// <summary>
            ///  For accessing table data, returns list full of table info
            /// </summary>
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

                        conn.Close();

                        return tableRecord;
                    }
                    catch
                    {
                        tableRecord = null;

                        conn.Close();

                        return tableRecord;
                    }
                }
            }


        }

        public static void ModifyTable(List<string> tableData)
        {
            /// <summary>
            /// Modifys table record from associated tableID passed in
            /// Uses list (tabledata) to store all data
            /// </summary>
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

        public static void deleteTable(string tableID)
        {
            /// <summary>
            /// deletes table associated with tableID
            /// </summary>
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