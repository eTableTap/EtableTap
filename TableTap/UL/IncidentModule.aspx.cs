using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.Models;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer.Classes;


namespace TableTap.IncidentModule
{
    public partial class IncidentModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                string url = Request.Url.AbsoluteUri;
                Session["LoginFallback"] = url;
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //test to add data via tableID
            int tableID = 00001;
            DateTime time = System.DateTime.Now;
            string info = "I am a test incident at user level";

            UserModel user = UserBL.passUserSearch(Session["login"].ToString());

            lbltime.Text = time.ToString();
            lbluser.Text = user.UserID.ToString();
            lblText.Text = info;
            lblTable.Text = tableID.ToString();


            IncidentModel incident = new IncidentModel();
            start();

        }


        protected void start()
        {
            IncidentModel incident = new IncidentModel();
            UserModel user = UserBL.passUserSearch(Session["login"].ToString());




            // importing/creating 

            incident.UserID = Convert.ToInt32(user.UserID);
            incident.TableID = Convert.ToInt32(lblTable.Text); // needs to come from input
            incident.Incdate = System.DateTime.Now;
            incident.Info = lblText.Text; // needs to come from input
            incident.RoomID = 0001; // needs to come from input / tableID
            incident.buildingID = 001; // needs to come from input/table ID
            incident.IncENDDate = (System.DateTime.Now.AddDays(1)); // needs to come from input if user is admin, else leave as is;
            if (user.AdminPermission == 1)
            {
                incident.IncLevel = true;
            }
            else
            {
                incident.IncLevel = false;
            }


           if (IncidenceBL.spamPrevention(incident) == true && incident.IncLevel != true)
            {

                lblText.Text = "Bugger off mate";


            }
            else
            {
                IncidenceBL.datalayerpassadd(incident);

            }

            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            UserModel user = UserBL.passUserSearch(Session["login"].ToString());


            IncidenceDAL.incAllUserDelete(user.UserID);
        }
    }
}