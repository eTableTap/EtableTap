﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TableTap.UL
{
    public partial class AdminAddTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] != "admin") //stops non admins accessing page
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}