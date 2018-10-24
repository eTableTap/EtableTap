using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.Models;
using TableTap.BusinessLayer.Classes;
using System.Configuration;

namespace TableTap.UL
{
    public partial class Map : System.Web.UI.Page
    {

        List<BuildingModel> buildings = new List<BuildingModel>();

        protected void Page_Load(object sender, EventArgs e) //created by beau
        {
            
            
            buildings = BuildingBL.fillBuildingsList();
           // Image1.ImageUrl = "~/Images/Room1.png";


            if (!IsPostBack) //need this to stop it reverting to the top value every button click
            {
                buildingDropdown.DataSource = buildings;
                buildingDropdown.DataValueField = "BuildingID";
                buildingDropdown.DataTextField = "BuildingName";
                buildingDropdown.DataBind();

               
            }
        }

        protected void goToBuildingButton_Click(Object sender, EventArgs e)
        {
            BuildingModel bm = new BuildingModel();

            bm = buildings.Where(b => b.BuildingID == Int32.Parse(buildingDropdown.Text)).FirstOrDefault(); //grabs single selected building
            
            int id = bm.BuildingID;

            string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Building.aspx?id=" + id;
            Response.Redirect(url);
            
            // Response.Redirect("Building.aspx?id=" + id);

        }







    }
}