using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.Models;
using TableTap.BusinessLayer.Classes;
using System.Data;

namespace TableTap.UL
{
    public partial class AdminIncidence : System.Web.UI.Page
    {

        //List<IncidentModel> incidences = IncidenceBL.GetIncidentList();

        protected void Page_Load(object sender, EventArgs e)
        {
            

           

            
            if (!IsPostBack)
            {
                FillData();

            }


        }

        protected void IncidentRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            GridViewRow row = (GridViewRow)IncidentGrid.Rows[e.RowIndex];
            IncidenceBL.DeleteRow(Convert.ToInt32(row.Cells[0].Text));
            
            FillData();
        }

        protected void IncidentRowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewRow row = (GridViewRow)IncidentGrid.Rows[e.NewEditIndex]; 
            IncidenceBL.EditStatus(Convert.ToInt32(row.Cells[0].Text));
            FillData();
         
        }

        protected void IncidentRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)IncidentGrid.Rows[e.RowIndex];
            IncidenceBL.EditStatus(Convert.ToInt32(row.Cells[0].Text));
            FillData();
        }

        protected void FillData()
        {
            List<IncidentModel> incidences = IncidenceBL.GetIncidentList();
            IncidentGrid.DataSource = incidences;
            IncidentGrid.DataBind();
        }


    }
}