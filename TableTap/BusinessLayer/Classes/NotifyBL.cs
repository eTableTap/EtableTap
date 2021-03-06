﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// take note of the modules below:
using Hangfire; //using background tasks for increased user-level performance
using MimeKit;
using MailKit.Net.Smtp;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

/// <summary>
/// This module uses Mailkit and Twilio from NuGet
/// This module contains a functional email form for confirmation
/// This module contains a fucntional email form for account creation
/// this module contains a functional SMS form for confirmation
/// this module includes a functional SMS form for account creation
/// this module includes supporting methods for above
/// when applying methods from this module be sure to take ALL the linked methods or the logic will break
/// </summary>

namespace TableTap.BusinessLayer.Classes
{
    public class NotifyBL
    {

        // The three methods below start backgroundtasks to operate the email and SMS functions for performance reasons 
        public static void startAccountNotification(string email, string phone, string fName, string sName)
        {
            BackgroundJob.Enqueue(() => AccountNotification(email, phone, fName, sName));

        }

        
        public static void startbookNotify(string email, string phone, string fName, string sName, string tableID, string roomName)
        {
            BackgroundJob.Enqueue(() => bookingNotify(email, phone, fName, sName, tableID, roomName));

        }

        public static void startNotifyGroupMember(string user, string email, string tableID, string roomName, string buildingName, string date, string hour)
        {
            BackgroundJob.Enqueue(() => notifyGroupMember(user, email, tableID, roomName, buildingName, date, hour));
        }

        public static void startNotifyBooking(string user, string phone, string email, string tableID, string roomName, string buildingName, string date, string hour, string URL)
        {
            BackgroundJob.Enqueue(() => notifyBooking(user, phone, email, tableID, roomName, buildingName, date, hour, URL));
        }





        // booking notification code requires sendmail(), phNumFormat() and sendSMS methods
        public static void bookingNotify(string email, string phone, string fName, string sName, string tableID, string roomName)
        {

            try
            {
                ///--------------------EMAIL SECTION -------------------------\\\

                // variables for the email address, email subject line, and message respectively
                string subject = fName + "  your TableTap booking";
                string message = "Hi " + fName + Environment.NewLine + "Thank you, " + fName + " "
                    + sName + ", your tabletap booking has been created for the table: "
                    + Environment.NewLine + tableID + " in " + roomName + Environment.NewLine + Environment.NewLine
                    + "Regards, TableTap team       www.etabletap.com";
                /// ---- Start EMAIL NOTIFICATION ----\\\

                // new Mail instance
                var eMail = new MimeMessage();
                // Specifies sending address
                eMail.From.Add(new MailboxAddress("eTableTap", "eTableTap@GMail.com"));
                // specifies target address
                eMail.To.Add(new MailboxAddress(fName + " " + sName, email));
                // email subject line
                eMail.Subject = subject;
                // email body
                eMail.Body = new TextPart("plain") { Text = message };

                // calls external method to SmtpClient method to send email
                sendemail(eMail);
            }
            catch
            {

            }

            try
            {
                ///--------------------------SMS SECTION----------------------\\\
                // creates strings for SMS message, forPhone generated by the Method phNumFormat
                string smsMessage = "Thank you for choosing TableTap, your booking for table " + tableID + " in room " + roomName;
                string forPhone = phNumFormat(phone);

                //if statement preventing the application from failing if there was a issue detected with "phone" in method phNumFormat  
                if (forPhone == null)
                {
                    // POSSIBLE ERROR MESSAGE TO BE ADDED, ELSE LEAVE BLANK
                }
                else
                {
                    //calls external method to send SMS via twilio
                    sendSMS(smsMessage, forPhone);
                }
            }
            catch
            {

            }

            }






        // formats phonenumber to twilio standards input string phone output formattedPhone
        public static string phNumFormat(string phone)
        {


            int length = phone.Length;
            string formattedPhone;

            // if statement level one detects +614 numbers and passes it on
            if (phone.Substring(0, 4) == "+614" && length == 12)
            {
                formattedPhone = phone;
            }
            // Detects if number is a 04 number and replaces 0 with +614
            else if (length == 10 && phone.Substring(0, 1) == "0")
            {
                formattedPhone = "+614" + phone.Substring(2);
            }
            // if number does not meet number requirements its passed back as a null
            else
            {
                formattedPhone = null;
            }



            return formattedPhone;
        }




        // account creation notification code includes both email and SMS notification requires sendmail(), phNumFormat() and sendSMS methods
        public static void AccountNotification(string email, string phone, string fName, string sName)
        {
            try
            {
                ///--------------------EMAIL SECTION -------------------------\\\

                // variables for the email address, email subject line, and message respectively
                string subject = fName + "  your TableTap account";
                string message = "Hi " + fName + Environment.NewLine + "Thank you, " + fName + " "
                    + sName + ", your table tap account has been created with the email: " + Environment.NewLine
                    + email + Environment.NewLine + "And the mobile number: " + Environment.NewLine
                    + phone + Environment.NewLine + Environment.NewLine
                    + "Regards, TableTap team       www.etabletap.com";
                /// ---- Start EMAIL NOTIFICATION ----\\\

                // new Mail instance
                var eMail = new MimeMessage();
                // Specifies sending address
                eMail.From.Add(new MailboxAddress("eTableTap", "eTableTap@GMail.com"));
                // specifies target address
                eMail.To.Add(new MailboxAddress(fName + " " + sName, email));
                // email subject line
                eMail.Subject = subject;
                // email body
                eMail.Body = new TextPart("plain") { Text = message };

                // calls external method to SmtpClient method to send email
                sendemail(eMail);
            }

            catch
            {

            }

            try
            {
                ///--------------------------SMS SECTION----------------------\\\
                // creates strings for SMS message, forPhone generated by the Method phNumFormat
                string smsMessage = "Thank you for choosing TableTap, your account has been activated";
                string forPhone = phNumFormat(phone);

                //if statement preventing the application from failing if there was a issue detected with "phone" in method phNumFormat  
                if (forPhone == null)
                {
                    // POSSIBLE ERROR MESSAGE TO BE ADDED, ELSE LEAVE BLANK
                }
                else
                {
                    //calls external method to send SMS via twilio
                    sendSMS(smsMessage, forPhone);
                }
            }
            catch
            {

            }

        }







        // method for sending Emails using SmtpClient, requires input of MimeMessage Variable
        public static void sendemail(MimeMessage eMail)
        {
            using (var client = new SmtpClient())
            {
                // smtp details for G-mail
                client.Connect("smtp.gmail.com", 587);

                // Email account details
                client.Authenticate("eTableTap@GMail.com", "INFT3970");

                client.Send(eMail);
                client.Disconnect(true);
            }
        }





        // Twilio SMS notification method, requires input of a message and a phone number as +614 format
        // no-a-touchytouchy
        public static void sendSMS(string message, string phone)
        {
            /// ------------------------------------------------------SUPPLIED BY TWILIO -------------------------- \\\
            // Account Information from Twilio account
            const string accountSid = "ACb3c8b45d687f30b390eace020d89fe75";
            const string authToken = "964f618c7094b7051e85fb65d13c676d";



            TwilioClient.Init(accountSid, authToken);
            // creates message and specifies numbers
            var smsMessage = MessageResource.Create(
                // contains message to be sent
                body: message,
                // Number supplied by Twilio account
                from: new PhoneNumber("+61447465857"),
                // Destination number
                to: new PhoneNumber(phone)
            );

            Console.WriteLine(smsMessage.Sid);
            /// ------------------------------------------------------SUPPLIED BY TWILIO END-------------------------- \\\
        }


        //notify a added group member of the users booked table
        public static void notifyGroupMember(string user, string email, string tableID, string roomName, string buildingName, string date, string hour)
        {
            try
            {
                ///--------------------EMAIL SECTION -------------------------\\\

                // variables for the email address, email subject line, and message respectively
                string subject = " ETableTap group booking";
                string message = "Hi " + Environment.NewLine
                    + user + ", has made a group booking which includes you " + Environment.NewLine
                    + "At building: " +  buildingName + Environment.NewLine
                    + "In room: " + roomName + Environment.NewLine 
                    + "For table: " + tableID + Environment.NewLine 
                    + "On date: " + date + Environment.NewLine
                    + "At hour: " + hour + Environment.NewLine
                    + "Regards, TableTap team       www.etabletap.com";
                /// ---- Start EMAIL NOTIFICATION ----\\\

                // new Mail instance
                var eMail = new MimeMessage();
                // Specifies sending address
                eMail.From.Add(new MailboxAddress("eTableTap", "eTableTap@GMail.com"));
                // specifies target address
                eMail.To.Add(new MailboxAddress(user + " " + "group", email));
                // email subject line
                eMail.Subject = subject;
                // email body
                eMail.Body = new TextPart("plain") { Text = message };

                // calls external method to SmtpClient method to send email
                sendemail(eMail);
            }
            catch
            {

            }

          

        }




        //notify a added group member of the users booked table
        public static void notifyBooking(string user, string phone, string email, string tableID, string roomName, string buildingName, string date, string hour, string URL)
        {
            try
            {
                ///--------------------EMAIL SECTION -------------------------\\\

                // variables for the email address, email subject line, and message respectively
                string subject = " ETableTap group booking";
                string message = "Hi " + Environment.NewLine
                    + "created by:" + user + ", just a friendly reminder of your booking " + Environment.NewLine
                    + "At building: " + buildingName + Environment.NewLine
                    + "In room: " + roomName + Environment.NewLine
                    + "For table: " + tableID + Environment.NewLine
                    + "On date: " + date + Environment.NewLine
                    + "At hour: " + hour + Environment.NewLine
                    + "For more information see :" + URL + Environment.NewLine
                    + "Regards, TableTap team       www.etabletap.com";
                /// ---- Start EMAIL NOTIFICATION ----\\\

                // new Mail instance
                var eMail = new MimeMessage();
                // Specifies sending address
                eMail.From.Add(new MailboxAddress("eTableTap", "eTableTap@GMail.com"));
                // specifies target address
                eMail.To.Add(new MailboxAddress(user + " " + "group", email));
                // email subject line
                eMail.Subject = subject;
                // email body
                eMail.Body = new TextPart("plain") { Text = message };

                // calls external method to SmtpClient method to send email
                sendemail(eMail);
            }
            catch
            {

            }

            try
            {
                ///--------------------------SMS SECTION----------------------\\\
                // creates strings for SMS message, forPhone generated by the Method phNumFormat
                string smsMessage = "Hi " + Environment.NewLine 
                    + "Thank you for choosing TableTap, We're just letting you know about your upcoming booking  " + Environment.NewLine
                    + "for: " + tableID + " in " + roomName + " " + buildingName;
                string forPhone = phNumFormat(phone);

                //if statement preventing the application from failing if there was a issue detected with "phone" in method phNumFormat  
                if (forPhone == null)
                {
                    // POSSIBLE ERROR MESSAGE TO BE ADDED, ELSE LEAVE BLANK
                }
                else
                {
                    //calls external method to send SMS via twilio
                    sendSMS(smsMessage, forPhone);
                }
            }
            catch
            {

            }



        }


    }






}