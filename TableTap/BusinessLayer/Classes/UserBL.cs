using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.DataAccessLayer;
using TableTap.Models;
using System.Configuration;




namespace TableTap.BusinessLayer
{
    public class UserBL
    {
        public static List<UserModel> FillUsersList()
        {
            List<UserModel> users = new List<UserModel>();

            users = UserDAL.LoadUsersList();

            return users;
        }

        public static UserModel getUserByID(int id)
        {
            UserModel user = UserDAL.loadUserByID(id);

            return user;
        }

        public static UserModel getUserByEmailAndPassword(string email, string password)
        {
            UserModel user = UserDAL.loadUserByEmailAndPassword(email, password);

            return user;
        }

        public static void ProcessAddNewUser(UserModel user)
        {
            UserModel newUser = user;

            UserDAL.AddNewUser(user);

        }



        
       /* public static int loginScripting(string email, string password)
        {
            /// <summary>
            /// CREATED BY HAYDEN BARTLETT
            /// scripting for login, passes information from login page to datalayer USERDB.
            /// A return of INT 3 = username failure
            /// A return of INT 2 = Password failure
            /// A return of INT 1 = Login success
            /// INPUT email Password, from Login
            /// OUTPUT INT 1/3 passed from USERDAL
            /// </summary>
            int status;
            try
            {
                // PLACE ADDITIONAL CODE HERE
              //status =  UserDAL.loginCheck(email, password);
            }
            catch
            {
                status = 3;
            }

            return status;
        }*/



        
        public static bool emailDuplicateCheck(string email)
        {
            //detects if email already exists in database (by contacting AdminUserEditCheck)
            bool exists;

            List<String> listing = new List<string>();
            try
            {
                listing = UserDAL.EmailSearch(email);

                if(listing == null)
                {
                    exists = false;
                }
                else
                {
                    exists = true;
                }
            }
            catch
            {
                exists = false;
            }

            return exists;
        }


        
        public static bool PassInModifyString(List<string> record)
        {
            /// <summary>
            /// passes list from fed from input (adminedituser) to ModifyUser class
            /// </summary>
            bool success = false;
            try
            {
                UserDAL.modifyUser(record);

                success = true;
                return success;

            }
            catch
            {
                return success;
            }
            
        }


        
        public static List<string> passUserSearch(string email)
        {
            /// <summary>
            /// Passes accesses data from data access layer
            /// input a email
            /// outputs list of user info associated with email
            /// if no email found or in the event of a error returns null
            /// </summary>
            /// <param name="record"></param>
            /// <returns></returns>
            List<string> record = new List<string>();
            try
            {

               record = UserDAL.EmailSearch(email);
            }
            catch
            {
                record = null;
            }

            return record;

        }


        
        public static void userDelete(int userID)
        {

            /// access user delete function, if successful returns true else
            /// returns false
            IncidenceDAL.incAllUserDelete(userID);
            UserDAL.deleteUser(userID);
            /*bool success;
            try
            {
                
                return success = true;
            }
            catch
            {
                return success = false;
            }*/
        }

        public static int ProcessLogin(UserModel logUser)
        {

            return UserDAL.CheckLogin(logUser);
        }


    }
}