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

namespace TableTap.DataAccessLayer.Classes
{
    public class UserDALkepler
    {

        //Add user with input strings from registration page 
        public void AddUser(string UserEmail, string FirstName, string LastName, string UserPassword)
        {
            string DBConn;
            DBConn = ConfigurationManager.ConnectionStrings["udbTableTapConnectionString"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(DBConn))
            {
                sqlConnection.Open();

                using (SqlCommand command = sqlConnection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO tblUser (email, firstName, lastName, passcode) VALUES (@email, @firstName, @lastName, @passcode)";

                    command.Parameters.AddWithValue("@email", UserEmail);
                    command.Parameters.AddWithValue("@firstName", FirstName);
                    command.Parameters.AddWithValue("@lastName", LastName);
                    command.Parameters.AddWithValue("@passcode", UserPassword);

                    int result = command.ExecuteNonQuery();
                }

            }
        }
    }
}