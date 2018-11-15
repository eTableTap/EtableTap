using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableTap.Models;
using TableTap.DataAccessLayer.Classes;

namespace TableTap.BusinessLayer.Classes
{
    public class GroupBL
    {






        public static BookingModel searchGroupByID(int groupID)
        {
            BookingModel group = GroupDAL.checkGroupBooking(groupID);

            return group;

        }
    }
}