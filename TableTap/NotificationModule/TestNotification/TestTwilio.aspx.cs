using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

/// <summary>
///  THIS REQUIRES THE TWILIO API FROM NUGET TO RUN AND;
/// using Twilio;
/// using Twilio.Rest.Api.V2010.Account;
/// using Twilio.Types;
/// this will need some logic to convert +61 style numbers into conventional numbers and exception catching
/// </summary>

namespace TableTap.TestNotification
{
    public partial class TestTwilio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string phonenum = txbData.Text;
            /// ------------------------------------------------------SUPPLIED BY TWILIO -------------------------- \\\
            // Account Information from Twilio account
            const string accountSid = "ACb3c8b45d687f30b390eace020d89fe75";
            const string authToken = "964f618c7094b7051e85fb65d13c676d";



            TwilioClient.Init(accountSid, authToken);
            // creates message and specifies numbers
            var message = MessageResource.Create(
                // contains message to be sent
                body: "TEST",
                // Number supplied by Twilio account
                from: new PhoneNumber("+61447465857"),
                // Destination number
                to: new PhoneNumber(phonenum)
            );

            Console.WriteLine(message.Sid);

        }
    }
}