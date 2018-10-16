﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableTap.DirectionsModule
{
    public partial class Directionsmodule : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected List<string> data()
        {
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


        protected string anLogic()
        {
            List<string> addresslist = new List<string>();
            addresslist = data();
            string street = addresslist[0].Replace(" ", "+");
            string URL = "google.navigation:q=" + street + ",+" + addresslist[1] + ",+" + addresslist[2] + ",+" + addresslist[3];
            //           Session.Abandon();
            //            Response.BufferOutput = true;
            return URL;
        }

        protected string iPLogic()
        {
            List<string> addresslist = new List<string>();
            addresslist = data();
            string street = addresslist[0].Replace(" ", "+");
            string URL = "comgooglemaps://?daddr=" + street + ",+" + addresslist[1] + ",+" + addresslist[2] + ",+" + addresslist[3];
            return URL;
        }

        protected string iPadLogic()
        {
            string URL = iPLogic(); // may require modification
            return URL;
        }

        protected string otherlogic()
        {
            List<string> addresslist = new List<string>();
            addresslist = data();
            string street = addresslist[0].Replace(" ", "+");
            string URL = "https://www.google.com/maps/dir/?api=1&destination=" + street + ",+" + addresslist[1] + ",+" + addresslist[2] + ",+" + addresslist[3];
            return URL;
        }

        protected string versionRedirect()
        {
            string URL;

            if (Request.UserAgent.IndexOf("Android") > 0)
            {
               URL = anLogic();
            }
            else if (Request.UserAgent.IndexOf("iPhone") > 0)
            {
              URL = iPLogic();
            }
            else if (Request.UserAgent.IndexOf("iPad") > 0)
            {
               URL = iPadLogic();
            }
            else
            {
               URL = otherlogic();
            }

            return URL;

        }


        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            // Testing function

            string URL = versionRedirect();

            Response.Redirect(URL);
        }


    }
}


