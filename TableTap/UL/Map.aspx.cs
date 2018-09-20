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
                DropDownList1.DataSource = buildings;
                DropDownList1.DataValueField = "BuildingID";
                DropDownList1.DataTextField = "BuildingName";
                DropDownList1.DataBind();
               
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

        protected void bookTableBtn_Click(object sender, EventArgs e)
        {

        }

        protected void buildingDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string str = DropDownList1.Text;
            //Image1.ImageUrl = "~/Images/" + str + ".png";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = DropDownList1.Text;
            Image1.ImageUrl = "~/Images/" + str + ".png";
            //if (str == "Newcastle City")
            //{
            //    Image1.ImageUrl = "~/Images/Room1.png";
            //}

        }


    }
}