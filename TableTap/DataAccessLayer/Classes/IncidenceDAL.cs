using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TableTap.Models;

namespace TableTap
{
    public class IncidenceDAL
    {
        // deletes all incidences made by a user
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



    }



}