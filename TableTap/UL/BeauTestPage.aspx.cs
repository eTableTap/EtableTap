using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;
using System.Device.Location;



//



namespace TableTap.UL
{
    public partial class BeauTestPage : System.Web.UI.Page
    {

        //List<UserModel> users = new List<UserModel>();
        


        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!Request.IsSecureConnection)
            {
                string url =
                    ConfigurationManager.AppSettings["SecurePath"] + "/UL/BeauTestPage.aspx";
                Response.Redirect(url);

                

            }*/
            GetLocationProperty();

        }
        protected void TestButton_Click(object sender, EventArgs e)
        {

            UserModel user = new UserModel();

            int id = 100001;
            user = UserBL.getUserByID(id);
            txtbxUserID.Text = user.UserID.ToString();
            txtbxEmail.Text = user.Email.ToString();
            txtbxPassword.Text = user.Password.ToString();
            txtbxFname.Text = user.FirstName.ToString();
            txtbxLname.Text = user.LastName.ToString();
            txtbxAdminP.Text = user.AdminPermission.ToString();

            // creates a dynamic textbox -- can change to images
            /*    TextBox textBox = new TextBox();
                textBox.ID = "textBox1";
                //textBox.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                //textBox.Style[HtmlTextWriterStyle.Top] = "0" + "px";
                //textBox.Style[HtmlTextWriterStyle.Left] = "50px";
                //top += 50;
                div1.Controls.Add(textBox);*/


            List<TableModel> tables = new List<TableModel>();
            tables = TableBL.fillTableList(1);
            int iLenght = tables.Count();
            int x = 0;
            /*///////////////////////
            TextBox textBox = new TextBox();
            textBox.ID = "textBox1";
            textBox.Text = iLenght.ToString();
            div1.Controls.Add(textBox);
            ////////////////////////*/
            while (x  < iLenght)
            {

                createImageTable(Convert.ToInt32(tables[x].TableID.ToString()));
                x++;
            }
        }

        protected void TestGeoLocationButton_Click(object sender, EventArgs e)
        {
            /*
             watcher.TryStart(false, TimeSpan.FromMilliseconds(1000));
             GeoCoordinate coord = watcher.Position.Location;
             lblTest.Text = "Lat: " + coord.Latitude + "</br>Long: " + coord.Longitude;
             */

            GetLocationProperty();

        }

        protected void GetLocationProperty()
        {
            //From https://docs.microsoft.com/en-us/dotnet/api/system.device.location.geocoordinatewatcher.position?view=netframework-4.7.2
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
           
            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
            
            GeoCoordinate coord = watcher.Position.Location;
           
            
            

            if (coord.IsUnknown != true)
            {
                lblTest.Text = "Lat: " + coord.Latitude + "</br>Long: " + coord.Longitude;
                Console.WriteLine("Lat: {0}, Long: {1}",
                    coord.Latitude,
                    coord.Longitude);
                GeoCoordinate geoLibrary = new GeoCoordinate(-32.892086, 151.698285);
                double distance = coord.GetDistanceTo(geoLibrary);
                lblTest.Text += "</br>Distance to library = " + distance;
                
            }
            else
            {
                lblTest.Text = "Unknown latitude and longitude.";
                
                Console.WriteLine("Unknown latitude and longitude.");
            }
            
        }

        protected void createImageTable(int tableNumber)
        {
            string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Table.aspx?id=" + tableNumber;
            /////////////////
            Image imageTable = new Image();
            imageTable.ID = "imgBox" + tableNumber.ToString();
            imageTable.Attributes.Add("height", "42");
            imageTable.Attributes.Add("width", "42");

            imageTable.Attributes.Add("style", "border-radius:14px;margin-bottom:20px; ");

            HyperLink imageHL = new HyperLink();
            imageHL.ID = "hLink" + tableNumber.ToString();
            imageHL.Attributes.Add("style", "margin-left:20px; ");

            //imageHL.Text = "hLink" + tableNumber.ToString();

            imageHL.Controls.Add(imageTable);//adds image to the hyperlink
            if (TableBL.checkTableStatus(tableNumber))
            {
                imageTable.BackColor = System.Drawing.Color.Green;
                imageHL.NavigateUrl = url; //will only genertate url if table is available
            }
            else
            {
                imageTable.BackColor = System.Drawing.Color.Red;
            }

            div1.Controls.Add(imageHL);
        }
    }
}