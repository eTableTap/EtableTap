using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer;
using TableTap.Models;

namespace TableTap.UL
{
    public partial class HaydenTestingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            List<string> tester = new List<string>();
            tester.Add("100004");
            tester.Add("hayden.bartlett1@hotmail.com");
            tester.Add("123");
            tester.Add("berry");
            tester.Add("Clidestale");
            tester.Add("True");

            UserDAL.modifyUser(tester);





            string IDnumber = "?=ID10008";
            Response.Redirect("HaydenTestingPageURLIN.aspx" + IDnumber);

            //<add name="ConnectionString" connectionString="Data Source=ORBIT1\SQLSERVER;Initial Catalog=udbTableTap;Integrated Security=False;User ID=etableTap;Password=123" providerName="System.Data.SqlClient" />

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string email = inEmail.Value;
            string phone = inPhone.Value;
            string fName = "testfirstname";
            string sName = "testsurname";
            NotifyBL.startAccountNotification(email, phone, fName, sName);
        }
    }
}