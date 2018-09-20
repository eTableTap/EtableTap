using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace TableTap.BusinessLayer.Classes
{
    public class TableManager
    {
        //Edit the availability of a table
        public void EditAvailability(string TableQR)
        {
            string DBConn;
            DBConn = ConfigurationManager.ConnectionStrings["udbTableTapConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();

                using (SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "UPDATE tblTable SET available = 1 WHERE tableQR=@tableQR";

                    command.Parameters.AddWithValue("@tableQR", TableQR);
                    int result = command.ExecuteNonQuery();
                }

            }
        }
    }
}