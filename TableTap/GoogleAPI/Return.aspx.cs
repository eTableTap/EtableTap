using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using TableTap.BusinessLayer.Classes;

namespace TableTap.GoogleAPI
{
    public partial class Return : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["accessToken"])) return;

            //let's send an http-request to Google+ API using the token           
            string json = GetGoogleUserJSON(Request.QueryString["access_token"]);

            //and Deserialize the JSON response
            JavaScriptSerializer js = new JavaScriptSerializer();
            GoogleEmail oUser = js.Deserialize<GoogleEmail>(json);

            if (oUser != null)
            {
                Response.Write("Welcome, " + oUser.data.email);
            }
        }

        private string GetGoogleUserJSON(string access_token)
        {
            string url = "https://www.googleapis.com/userinfo/email?alt=json";

            WebClient wc = new WebClient();
            wc.Headers.Add("Authorization", "OAuth " + Request.QueryString["accessToken"]);
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string retirnedJson = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return retirnedJson;
        }
    }
}