using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.DataAccessLayer.Classes;
using TableTap.Models;
using System.Configuration;




namespace TableTap.BusinessLayer.Classes
{
    public class UserBL
    {

        /// <summary>
        /// fetches complete list of records in user table 
        /// via UserDAL.LoadUsersList();
        /// returns a list of usermodels
        /// </summary>
        public static List<UserModel> FillUsersList()
        {
            List<UserModel> users = new List<UserModel>();

            users = UserDAL.LoadUsersList();

            return users;
        }


        /// <summary>
        /// fetches user record by userID via UserDAL.loadUserByID(id)
        /// returns a usermodel of associated userID
        /// </summary>
        public static UserModel getUserByID(int id)
        {
            UserModel user = UserDAL.loadUserByID(id);

            return user;
        }

        /// <summary>
        /// Fetches user record by Email and Password via UserDAL.loadUserByEmailAndPassword(email, password)
        /// returns UserModel
        /// </summary>
        public static UserModel getUserByEmailAndPassword(string email, string password)
        {
            UserModel user = UserDAL.loadUserByEmailAndPassword(email, password);

            return user;
        }


        /// <summary>
        /// Passes User Model to adding user method in DAL 
        /// UserDAL.AddNewUser(user);
        /// </summary>
        public static void ProcessAddNewUser(UserModel user)
        {
            UserModel newUser = user;
            try
            {
                UserDAL.AddNewUser(user);
            }
                catch
            { }
            

        }



        /// <summary>
        /// detects if email already exists in database by email via
        /// contacting AdminUserEditCheck
        /// Returns boolean if email exists returns true
        /// else returns false
        /// 
        /// </summary>

        public static bool emailDuplicateCheck(string email)
        {
            //detects if email already exists in database (by contacting AdminUserEditCheck)
            bool exists;

            UserModel listing = new UserModel();
            
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


        /// <summary>
        /// passes list from fed from input (adminedituser) to ModifyUser class
        /// </summary>   
        public static bool PassInModifyString(List<string> record)
        {

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


        /// <summary>
        /// Passes accesses data from data access layer
        /// input a email
        /// outputs list of user info associated with email
        /// if no email found or in the event of a error returns null
        public static UserModel passUserSearch(string email)
        {

            UserModel loadeduser = new UserModel();
            

            try
            {

               loadeduser = UserDAL.EmailSearch(email);
            }
            catch
            {
                loadeduser = null;
            }

            return loadeduser;

        }


        /// <summary>
        /// Calls by user ID and User Email
        /// IncidenceDAL.incAllUserDelete(userID);
        /// BookingDAL.BookingAllUserDelete(user.Email);
        /// UserDAL.deleteUser(userID);
        /// to delete a user and all referances to the user in the database
        /// </summary>
        public static void userDelete(int userID)
        {


            UserModel user = new UserModel();

            /// access user delete function
            /// 

            user = getUserByID(userID);

            IncidenceDAL.incAllUserDelete(userID);
            BookingDAL.BookingAllUserDelete(user.Email);
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



        /// <summary>
        /// Checks administrative level via usermodel
        /// </summary>
        public static int ProcessLogin(UserModel logUser)
        {

            return UserDAL.CheckLogin(logUser);
        }




    }
}