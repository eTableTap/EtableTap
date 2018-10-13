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


        protected void anLogic()
        {
            List<string> addresslist = new List<string>();
            addresslist = data();
            string street = addresslist[0].Replace(" ", "+");
            string address = "google.navigation:q=" + street;
            Label1.Text = "WHY WONT THIS FUCKING WORK";
//            Response.BufferOutput = true;
            Response.Redirect("https://stackoverflow.com/questions/6635349/how-to-delete-cookies-on-an-asp-net-website");

        }

        protected void iPLogic()
        {
            List<string> addresslist = new List<string>();
            addresslist = data();

            Response.Redirect("http://maps.apple.com/?saddr=Cupertino&daddr=San+Francisco", true);
        }

        protected void iPadLogic()
        {

        }

        protected void otherlogic()
        {
            anLogic();
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session.Abandon();

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


