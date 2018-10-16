using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableTap
{
    public class DirectionModuleBL
    {
        public static List<string> data()
        {
            // testing placeholder
            string street = "142 Nagles Falls Road, Sherwood, NSW, Australia";
            string suburb = "sherwood";
            string postcode = "2440";
            string state = "NSW";

            List<string> address = new List<string>();
            address.Add(street);
            address.Add(suburb);
            address.Add(postcode);
            address.Add(state);
            return address;
        }


        public static string anLogic()
        {
            List<string> addresslist = new List<string>();
            addresslist = data();
            string street = addresslist[0].Replace(" ", "+");
            string URL = "google.navigation:q=" + street + ",+" + addresslist[1] + ",+" + addresslist[2] + ",+" + addresslist[3];
            //           Session.Abandon();
            //            Response.BufferOutput = true;
            return URL;
        }

        public static string iPLogic()
        {
            List<string> addresslist = new List<string>();
            addresslist = data();
            string street = addresslist[0].Replace(" ", "+");
            string URL = "comgooglemaps://?daddr=" + street + ",+" + addresslist[1] + ",+" + addresslist[2] + ",+" + addresslist[3];
            return URL;
        }

        public static string iPadLogic()
        {
            string URL = iPLogic(); // may require modification
            return URL;
        }

        public static string otherlogic()
        {
            List<string> addresslist = new List<string>();
            addresslist = data();
            string street = addresslist[0].Replace(" ", "+");
            string URL = "https://www.google.com/maps/dir/?api=1&destination=" + street + ",+" + addresslist[1] + ",+" + addresslist[2] + ",+" + addresslist[3];
            return URL;
        }

        public static string start()
        {
            string URL;

            if (HttpContext.Current.Request.UserAgent.IndexOf("Android") > 0)
            {
                URL = anLogic();
            }
            else if (HttpContext.Current.Request.UserAgent.IndexOf("iPhone") > 0)
            {
                URL = iPLogic();
            }
            else if (HttpContext.Current.Request.UserAgent.IndexOf("iPad") > 0)
            {
                URL = iPadLogic();
            }
            else
            {
                URL = otherlogic();
            }

            return URL;

        }

    }



}