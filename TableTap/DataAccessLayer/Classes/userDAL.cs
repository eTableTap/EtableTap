using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TableTap.Models;

namespace TableTap.DataAccessLayer.Classes
{
    public class UserDAL
    {
        public static List<UserModel> LoadUsersList()
        {
            List<UserModel> users = new List<UserModel>();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblUser",
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    UserModel user;
                    while (dr.Read())
                    {
                        user = new UserModel();
                        user.UserID = Convert.ToInt32(dr["userID"]);
                        user.Email = dr["emailAddress"].ToString();
                        user.Password = dr["passcode"].ToString();
                        user.FirstName = dr["firstName"].ToString();
                        user.LastName = dr["lastName"].ToString();
                        user.AdminPermission = Convert.ToByte(dr["adminPermission"]);
                        user.phoneNum = dr["phoneNum"].ToString();

                        users.Add(user);
                    }
                    dr.Close();
                }
                conn.Close();
            }

            return users;
        }

        public static UserModel loadUserByID(int id)
        {
            UserModel user = new UserModel();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            using (conn)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblUser WHERE userID=" + id.ToString(),
                    conn))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    dr.Read();



                    //user = new UserModel();
                    user.UserID = Convert.ToInt32(dr["userID"]);
                    user.Email = dr["emailAddress"].ToString();
                    user.Password = dr["passcode"].ToString();
                    user.FirstName = dr["firstName"].ToString();
                    user.LastName = dr["lastName"].ToString();
                    user.AdminPermission = Convert.ToByte(dr["adminPermission"]);
                    user.phoneNum = dr["phoneNum"].ToString();


                    dr.Close();
                }
                conn.Close();
            }

            return user;
        }

        public static UserModel loadUserByEmailAndPassword(string email, string password)
        {
            UserModel loadeduser = new UserModel();

           

            

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

            List<UserModel> userList = LoadUsersList();

            UserModel user = userList.Where(u => u.Email == email && u.Password == password).FirstOrDefault();

            if (user != null)
            {
                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblUser WHERE emailAddress=" + "'" + email.ToString() + "'" + "AND passcode=" + "'" + password.ToString() + "'",
                    conn))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        dr.Read();



                        //user = new UserModel();
                        loadeduser.UserID = Convert.ToInt32(dr["userID"]);
                        loadeduser.Email = dr["emailAddress"].ToString();
                        loadeduser.Password = dr["passcode"].ToString();
                        loadeduser.FirstName = dr["firstName"].ToString();
                        loadeduser.LastName = dr["lastName"].ToString();
                        loadeduser.AdminPermission = Convert.ToByte(dr["adminPermission"]);
                        loadeduser.phoneNum = dr["phoneNum"].ToString();


                        dr.Close();
                    }
                    conn.Close();
                }
            }

            return user;
        }

        public static void AddNewUser(UserModel user)
        {
            UserModel newUser = user;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

              using (conn)
              {
                  conn.Open();

                    

                  using (SqlCommand command = new SqlCommand(
                  "INSERT INTO tblUser (emailAddress, passcode, firstName, lastName, adminPermission, phoneNum) VALUES ("
                      + "'" + newUser.Email.ToString() + "'" + ", "
                      + "'" + newUser.Password.ToString() + "'" + ", "
                      + "'" + newUser.FirstName + "'" + ", "
                      + "'" + newUser.LastName + "'" + ", "
                      + "'" + newUser.AdminPermission + "'" + ","
                      + "'" + newUser.phoneNum + "'" + ")"
                      ,
                      conn))
                  {
                      command.ExecuteNonQuery();
                  }
                  conn.Close();
              } 
            
        }




        /// <summary>
        /// CREATED BY HAYDEN
        /// Takes input of email
        /// returns matching record as a usermodel
        public static UserModel EmailSearch(string email)
        {
            UserModel loadeduser = new UserModel();



        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        List<UserModel> userList = LoadUsersList();

        UserModel user = userList.Where(u => u.Email == email).FirstOrDefault();

            if (user != null)
            {
                using (conn)
                {
                    conn.Open();

                    using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM tblUser WHERE emailAddress=" + "'" + email.ToString() + "'",
                    conn))
                    {
                        SqlDataReader dr = command.ExecuteReader();
                        dr.Read();


                        //user = new UserModel();
                        loadeduser.UserID = Convert.ToInt32(dr["userID"]);
                        loadeduser.Email = dr["emailAddress"].ToString();
                        loadeduser.Password = dr["passcode"].ToString();
                        loadeduser.FirstName = dr["firstName"].ToString();
                        loadeduser.LastName = dr["lastName"].ToString();
                        loadeduser.AdminPermission = Convert.ToByte(dr["adminPermission"]);
                        loadeduser.phoneNum = dr["phoneNum"].ToString();


                        dr.Close();
                    }
                     conn.Close();
                }
            }

            return user;
        }



        /// <summary>
        /// Modifys user record from associated email passed in
        /// Uses list (userdata) to store all data
        /// </summary>
        public static void modifyUser(List<string> userdata)
        {
            string UserID = userdata[0];
            string email = userdata[1];
            string password = userdata[2];
            string firstname = userdata[3];
            string lastname = userdata[4];
            string admin = userdata[5];

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand modify = new SqlCommand();
            SqlDataReader reader;
            modify.CommandText = "UPDATE tblUser SET emailAddress=" + "'" + email + "', passcode=" + "'" + password + "', firstName=" + "'" + firstname 
                + "', lastName=" + "'" + lastname + "', adminPermission=" + "'" + admin + "'" + "WHERE userID=" + "'" + UserID + "'";
            modify.CommandType = System.Data.CommandType.Text;
            modify.Connection = conn;
            conn.Open();
            reader = modify.ExecuteReader();

            conn.Close();


            
        }



        /// <summary>
        /// deletes user associated with userID
        /// </summary>
        public static void deleteUser(int UserID)
        {

            /*
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand modify = new SqlCommand();
            SqlDataReader reader;
            modify.CommandText = "DELETE FROM tblUser " + "WHERE userID=" + "'" + UserID + "'";
            modify.CommandType = System.Data.CommandType.Text;
            modify.Connection = conn;
            conn.Open();
            reader = modify.ExecuteReader();

            conn.Close();
            */
            UserModel newUser = new UserModel();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            
            using (conn)
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(
                "DELETE FROM tblUser WHERE userID=" + UserID.ToString(), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

        }

        public static int CheckLogin(UserModel logUser)
        {
            List<UserModel> userList = LoadUsersList();
            //List<UserModel> adminList = LoadAdminsList();

            UserModel user = userList.Where(u => u.Email == logUser.Email && u.Password == logUser.Password).FirstOrDefault();
            //UserModel admin = adminList.Where(u => u.Email == logUser.Email && u.Password == logUser.Password).FirstOrDefault();
            
            
            
            if (user != null)
            {
                if (user.AdminPermission == 1)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            return 5;
        }


    }
}