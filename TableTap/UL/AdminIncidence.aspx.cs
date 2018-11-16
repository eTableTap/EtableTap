using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.Models;
using TableTap.BusinessLayer.Classes;
using System.Data;

/* 
    INFT 3970 - IT Major Project - Implementation
    Hayden Bartlett – C3185636
    Beau Maund – C3163068

    Source File Purpose:
    - Serves as a the back-end for the administrator, and provides functionality for updating / managing incidents in the system
 */

namespace TableTap.UL
{
    public partial class AdminIncidence : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                 
            //Load data if user has initiated so, by button click.
            if (!IsPostBack)
            {
                FillData();
            }
        }

        /// <summary>
        /// Deletes a row from the incidence listing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void IncidentRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Gets the user selected row   
            GridViewRow row = (GridViewRow)IncidentGrid.Rows[e.RowIndex];

            //Deletes the row from the database
            IncidenceBL.DeleteRow(Convert.ToInt32(row.Cells[0].Text));
            
            //Reloads the data from the database (now presumably excluding the deleted value)
            FillData();
        }

        /// <summary>
        /// Edits a row in the incidence listing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void IncidentRowEditing(object sender, GridViewEditEventArgs e)
        {
            //Gets the user selected row   
            GridViewRow row = (GridViewRow)IncidentGrid.Rows[e.NewEditIndex];

            //Edits the row from the database
            IncidenceBL.EditStatus(Convert.ToInt32(row.Cells[0].Text));

            //Reloads the data from the database (now presumably excluding the deleted value)
            FillData();
         
        }

        /// <summary>
        /// Updates the incidence listing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void IncidentRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Gets the user selected row  
            GridViewRow row = (GridViewRow)IncidentGrid.Rows[e.RowIndex];

            //Edits the row from the database
            IncidenceBL.EditStatus(Convert.ToInt32(row.Cells[0].Text));

            //Reloads the data from the database (now presumably excluding the deleted value)
            FillData();
        }

        /// <summary>
        /// Pulls the current data from the database and updates the incidence listing
        /// </summary>
        protected void FillData()
        {
            List<IncidentModel> incidences = IncidenceBL.GetIncidentList();
            IncidentGrid.DataSource = incidences;
            IncidentGrid.DataBind();
        }


    }
}