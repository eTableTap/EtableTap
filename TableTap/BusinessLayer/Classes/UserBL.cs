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
            try
            { }
                catch
            { }
            UserDAL.AddNewUser(user);

        }


        

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


        
        public static UserModel passUserSearch(string email)
        {

            UserModel loadeduser = new UserModel();
            /// <summary>
            /// Passes accesses data from data access layer
            /// input a email
            /// outputs list of user info associated with email
            /// if no email found or in the event of a error returns null

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


        
        public static void userDelete(int userID)
        {


            UserModel user = new UserModel();

            /// access user delete function
            /// 

            user = getUserByID(userID);

            IncidenceDAL.incAllUserDelete(userID);
            GroupDAL.groupAllUserDelete(user.Email);
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