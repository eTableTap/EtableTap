using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;
using TableTap.Models;

namespace TableTap.UL
{
    public partial class Room : System.Web.UI.Page
    {
        List<TableModel> tables = new List<TableModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Int32.Parse(Request.QueryString["ID"]);
            lblHeading.Text = "Room: " + RoomBL.getRoomByID(ID).RoomName;
            tables = TableBL.fillTableList(ID);

            if (!IsPostBack) //need this to stop it reverting to the top value every button click
            {
                tableDropdown.DataSource = tables;
                tableDropdown.DataValueField = "TableID";
                tableDropdown.DataTextField = "TableID";
                tableDropdown.DataBind();
            }

            if (tableDropdown.Items.Count < 1)
            {
                lblAboveDropdown.Text = "No tables currently available";
                tableDropdown.Visible = false;
                goToTableButton.Visible = false;
            }

            //
            List<TableModel> drawtables = new List<TableModel>();
            drawtables = TableBL.fillTableList(ID);
            int iLenght = drawtables.Count();
            int x = 0;
            /*///////////////////////
            TextBox textBox = new TextBox();
            textBox.ID = "textBox1";
            textBox.Text = iLenght.ToString();
            div1.Controls.Add(textBox);
            ////////////////////////*/
            while (x < iLenght)
            {

                createImageTable(Convert.ToInt32(drawtables[x].TableID.ToString()));
                x++;
            }
        }

        protected void goToTableButton_Click(Object sender, EventArgs e)
        {
            TableModel tm = new TableModel();

            tm = tables.Where(t => t.TableID == Int32.Parse(tableDropdown.Text)).FirstOrDefault(); //grabs single selected building

            int id = tm.TableID;

            string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Table.aspx?id=" + id;
            Response.Redirect(url);

        }

        protected void createImageTable(int tableNumber)
        {
            string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Table.aspx?id=" + tableNumber;
            /////////////////
            Image imageTable = new Image();
            imageTable.ID = "imgBox" + tableNumber.ToString();
            imageTable.Attributes.Add("height", "42");
            imageTable.Attributes.Add("width", "42");
            imageTable.Attributes.Add("class", "img-circle");

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

            divTableImages.Controls.Add(imageHL);
        }
    }
    
}