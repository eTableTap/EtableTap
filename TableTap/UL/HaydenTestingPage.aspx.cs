using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer;
using TableTap.Models;
using System.Configuration;

namespace TableTap.UL
{
    public partial class HaydenTestingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dosomeshit();



        }

        protected void dosomeshit()
        {
            if (Request.UserAgent.IndexOf("Android") > 0)
            {
                TextBox1.Text = "android";
            }
            else if (Request.UserAgent.IndexOf("iPhone") > 0)
            {
                TextBox1.Text = "IOS";
            }
            else if (Request.UserAgent.IndexOf("iPad") > 0)
            {
                TextBox1.Text = "IOS";
            }
            else
                TextBox1.Text = "reeeeee";
        }

        public String GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}