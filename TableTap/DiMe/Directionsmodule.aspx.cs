using System;
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
            string street = "142 nagles falls road";
            string suburb = "sherwood";
            string postcode = "2449";
            string state = "NSW";

            List<string> address = new List<string>();
            address.Add(street);
            address.Add(suburb);
            address.Add(postcode);
            address.Add(state);
            return address;
        }


        protected void anLogic()
        {
            List<string> address = new List<string>();
            address = data();

        }

        protected void iPLogic()
        {

        }

        protected void iPadLogic()
        {

        }

        protected void otherlogic()
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (Request.UserAgent.IndexOf("Android") > 0)
            {
                anLogic();
            }
            else if (Request.UserAgent.IndexOf("iPhone") > 0)
            {
                iPLogic();
            }
            else if (Request.UserAgent.IndexOf("iPad") > 0)
            {
                iPadLogic();
            }
            else
            {
                otherlogic();
            }
        }
    }
}


