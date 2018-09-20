using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableTap.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AdminPermission { get; set; }

        public UserModel()
        {

        }

        public UserModel(int id, string email, string psw, string fname, string lname, byte admperm)
        {
            this.UserID = id;
            this.Email = email;
            this.Password = psw;
            this.FirstName = fname;
            this.LastName = lname;
            this.AdminPermission = admperm;
        }
    }
}




 
 