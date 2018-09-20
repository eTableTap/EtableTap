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
                lblAboveDropdown.Text = "No rooms currently available";
                tableDropdown.Visible = false;
                goToTableButton.Visible = false;
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
    }
    
}