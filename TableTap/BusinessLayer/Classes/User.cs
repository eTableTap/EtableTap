using TableTap.DataAccessLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OBSELETE REFER TO USERBL IN DataAccessLayer/Classes
/// </summary>


namespace TableTap.BusinessLayer.Classes
{
    //Instantiazation Method Class. Creates User with AddUser method.
    public class User
    {

        public string UserEmail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserPasscode { get; set; }

        public void AddUser()
        {
            UserDALkepler obj = new UserDALkepler();
            obj.AddUser(UserEmail, FirstName, LastName, UserPasscode);
        }

    }
}