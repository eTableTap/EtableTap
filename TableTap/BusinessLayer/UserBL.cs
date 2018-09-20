using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.DataAccessLayer;
using TableTap.Models;

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

   

    }
}