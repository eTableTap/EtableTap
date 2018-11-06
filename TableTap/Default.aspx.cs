﻿using Hangfire;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using TableTap.BusinessLayer.Classes;
using TableTap.DataAccessLayer;
using TableTap.Models;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using TableTap.BackGroundWorker.Classes;

namespace TableTap.UL
{
    public partial class TesterHeaderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void test1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UL/HaydenTestingPage.aspx");
        }

        protected void test2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UL/BeauTestPage.aspx");
        }

        protected void test3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UL/AdminHome.aspx");
        }

        protected void test4_Click(object sender, EventArgs e)
        {

            string domain = "UL/table.aspx";

            string IDnumber = "?ID=1";


            string url = "http://220.233.30.25/";

            string cUrl = url + domain + IDnumber;


            QRCodeEncoder encoder = new QRCodeEncoder();

            Bitmap img = encoder.Encode(cUrl);

            Response.ContentType = "image/png";
            img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);

            //Change to your own location if you want to store a copy-- not needed
            //img.Save("D:\\MyDocuments\\GitHub\\TableTap\\TableTap\\TestQR\\LastQRCodeCreated.png", ImageFormat.Png);
            //QRImage.ImageUrl = "LastQRCodeCreated.png";

            QRCodeDecoder decoder = new QRCodeDecoder();
        }

        protected void test5_Click(object sender, EventArgs e)
        {
            Response.Redirect("UL/Register.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int buildingID = 001;
            // directions module
            string URL = DirectionModuleBL.start(buildingID);

            Response.Redirect(URL);
        }

        protected void btntestnotify_Click(object sender, EventArgs e)
        {

            string fname = "fnametest";
            string sname = "sname";
            string phone = "0427669341";

            string user = fname + " " + sname;
            string email = "C3166581@uon.edu.au";
            string tableID = "I AM A TABLE RE";
            string roomName = "Hi I'm a room and my name is barry";
            string buildingName = "Nerg building";


            NotifyBL.startbookNotify(email, phone, fname, sname, tableID, roomName);
            NotifyBL.startAccountNotification(email, phone, fname, sname);
            //NotifyBL.notifyGroupMember(user, email, tableID, roomName, buildingName);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string fname = "fnametest";
            string sname = "sname";
            string phone = "0427669341";

            string user = fname + " " + sname;
            string email = "hayden.bartlett1@hotmail.com";
            string tableID = "I AM A TABLE RE";
            string roomName = "Hi I'm a room and my name is barry";
            string buildingName = "Nerg building";

            var jobId = BackgroundJob.Schedule(
           () => NotifyBL.startbookNotify(email, phone, fname, sname, tableID, roomName),
           TimeSpan.FromMinutes(1));
        }

        protected void buttontry_OnClick(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "?", "<script language=javascript>getLocation();</script>");
 //           ClientScript.RegisterStartupScript(this.GetType(), "?", "<script language=javascript>getLocation();</script>");
        }

        protected void btnBackgroundworker_Click(object sender, EventArgs e)
        {
            bool status = EmailQueuing.startEmailNotificationSystem();

            if(status == true)
            {
                lblsttatus.Text = "started";
            }
            else
            {
                lblsttatus.Text = "error";
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("GoogleAPI/Googlelogin.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            EmailQueuing.stahp();
        }
    }
}