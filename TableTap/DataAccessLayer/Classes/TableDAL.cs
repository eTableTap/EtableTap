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

        public static string checkTableStatus(int id)
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

            if (sTest == "")
            {
                sTest = "This table is availabile!";
            }
            else
            {
                sTest = "This table is Occupied";
            }

            return sTest;
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