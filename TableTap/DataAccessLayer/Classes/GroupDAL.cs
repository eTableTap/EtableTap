using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TableTap.Models;

namespace TableTap.DataAccessLayer.Classes
{
    public class GroupDAL
    {

        public static void groupAllUserDelete(string emailAddress)
        {

            //delete all records in group via user email

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblGroup WHERE emailAddress=" + emailAddress, conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }





        public static bool CreateCalanderBookTable(BookingModel groupModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                BookingModel newGroupModel = groupModel;

                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(

                        "INSERT INTO tblGroup (TableID, gDate, emailAddress, gHour, memberEmail, memberEmail1, memberEmail2, memberEmail3, memberEmail4) VALUES ("
                        + "'" + newGroupModel.tableID + "'" + ", "
                        + "'" + newGroupModel.gDate.ToString("yyyy-MM-d") + "'" + ", "
                        + "'" + newGroupModel.emailAddress + "'" + ", "
                        + "'" + newGroupModel.gHour + "'" + ", "
                        + "'" + newGroupModel.memberEmail1 + "'" + ", "
                        + "'" + newGroupModel.memberEmail2 + "'" + ", "
                        + "'" + newGroupModel.memberEmail3 + "'" + ", "
                        + "'" + newGroupModel.memberEmail4 + "'" + ", "
                        + "'" + newGroupModel.memberEmail5 + "'" + ")"
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




        public static BookingModel checkGroupBooking(int groupIDE)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            BookingModel group = new BookingModel();

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblGroup WHERE groupID=" + "'" + groupIDE.ToString() + "'",
                    conn))


                {
                    SqlDataReader dr = command.ExecuteReader();
                    dr.Read();

                


                    group.groupID = groupIDE;
                    group.tableID = int.Parse(dr["tableID"].ToString());
                    group.gDate = DateTime.Parse(dr["gDate"].ToString());
                    group.emailAddress = dr["emailAddress"].ToString();
                    group.gHour = int.Parse(dr["gHour"].ToString());
                    group.memberEmail1 = dr["memberEmail1"].ToString();
                    group.memberEmail2 = dr["memberEmail2"].ToString();
                    group.memberEmail3 = dr["memberEmail3"].ToString();
                    group.memberEmail4 = dr["memberEmail4"].ToString();
                    group.memberEmail5 = dr["memberEmail5"].ToString();

                    dr.Close();
                }
                conn.Close();
            }

            return group;
    
        }



        public static List<BookingModel> loadGroupListattime()
        {
            List<BookingModel> groups = new List<BookingModel>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblGroup WHERE gHour = " + "'" + System.DateTime.Now.AddHours(1).ToString("HH") + "'" + " AND  gDate =" + "'"
                    + System.DateTime.Now.ToString("yyyy-MM-d") + "'",
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    BookingModel group;
                    while (dr.Read())
                    {

                        group = new BookingModel();
                        group.groupID = Convert.ToInt32(dr["groupID"].ToString());
                        group.tableID = Convert.ToInt32(dr["tableID"].ToString());
                        group.gDate = Convert.ToDateTime(dr["gDate"].ToString());
                        group.emailAddress = dr["emailAddress"].ToString();
                        group.gHour = Convert.ToInt32(dr["gHour"].ToString());
                        group.memberEmail1 = dr["memberEmail1"].ToString();
                        group.memberEmail2 = dr["memberEmail2"].ToString();
                        group.memberEmail3 = dr["memberEmail3"].ToString();
                        group.memberEmail4 = dr["memberEmail4"].ToString();
                        group.memberEmail5 = dr["memberEmail5"].ToString();

                        groups.Add(group);

                    }

                    dr.Close();
                }

                conn.Close();
            }

            return groups;
        }


    }



}