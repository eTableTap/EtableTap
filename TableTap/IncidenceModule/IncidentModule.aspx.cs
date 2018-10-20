using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.Models;
using TableTap.DataAccessLayer.Classes;

namespace TableTap.IncidentModule
{
    public partial class IncidentModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //test to add data via tableID
            int tableID = 00001;
            DateTime time = System.DateTime.Now;
            string info = "I am a test incident at user level";
            int userID = 100002;

            lbltime.Text = time.ToString();
            lbluser.Text = userID.ToString();
            lblText.Text = info;
            lblTable.Text = tableID.ToString();



            IncidentModel incident = new IncidentModel();
            start();

        }


        protected void start()
        {
            IncidentModel incident = new IncidentModel();


            // importing data 

            incident.UserID = Convert.ToInt32(lbluser.Text);
            incident.TableID = Convert.ToInt32(lblTable.Text);
            incident.Incdate = System.DateTime.Now;
            incident.Info = lblText.Text;
            incident.RoomID = 0001;
            incident.buildingID = 001;
            incident.IncLevel = false;

            datalayerpassadd(incident);

        }

        protected void datalayerpassadd(IncidentModel incident)
        {


            IncidenceDAL.AddNewIncident(incident);



        }




    }
}