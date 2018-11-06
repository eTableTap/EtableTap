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




    }
}