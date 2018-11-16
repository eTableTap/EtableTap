using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.Models;
using TableTap.BusinessLayer.Classes;
using System.Configuration;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Facilitates the Map.aspx functionality, by permitting room search
 */

namespace TableTap.UL{
    public partial class Map : System.Web.UI.Page
    {
        List<BuildingModel> buildings = new List<BuildingModel>();

        protected void Page_Load(object sender, EventArgs e) 
        {   
            buildings = BuildingBL.fillBuildingsList();
            
            if (!IsPostBack)
            {
                //Sets relevant building fields
                inputBuildingSelecter.DataSource = buildings;
                inputBuildingSelecter.DataValueField = "BuildingID";
                inputBuildingSelecter.DataTextField = "BuildingName";
                inputBuildingSelecter.DataBind();
            }

            if (inputBuildingSelecter.Items.Count < 1)
            {
                //If rooms are not found, output an error code & do not display building selector / goto building button
                sideLbl.Text = "No rooms found";
                inputBuildingSelecter.Visible = false;
                goToBuildingButton.Visible = false;
            }
        }

        /// <summary>
        /// Redirects user to the building map view module
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void goToBuildingButton_Click(Object sender, EventArgs e)
        {
            BuildingModel bm = new BuildingModel();

            //Selects single selected building
            bm = buildings.Where(b => b.BuildingID == Int32.Parse(inputBuildingSelecter.Value)).FirstOrDefault(); 
            
            int id = bm.BuildingID;
            
            //Generates the URL for redirection for the specific selected building
            string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Building.aspx?id=" + id;
            Response.Redirect(url);
        }







    }
}