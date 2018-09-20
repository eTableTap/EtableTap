using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimeKit;
using MailKit.Net.Smtp;


/// <summary>
/// SENDS BASIC EMAIL USING 
/// using MimeKit;
/// using MailKit.Net.Smtp;
/// Requires Mailkit from NUGET
/// can be used to create more complex with extra commands
/// </summary>
namespace TableTap.TestNotification
{
    public partial class TestEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // variables for the email address, email subject line, and message respectively
            string email = txbData.Text;
            string subject = txbSubject.Text;
            string message = txbMessage.Text;
            /// ---- Start EMAIL NOTIFICATION ----\\\

            // new Mail instance
            var eMail = new MimeMessage();
            // Specifies sending address
            eMail.From.Add(new MailboxAddress("eTableTap", "eTableTap@GMail.com"));
            // specifies target address
            eMail.To.Add(new MailboxAddress("Valued Client", email));
            // email subject line
            eMail.Subject = subject;
            // email body
            eMail.Body = new TextPart("plain") { Text = message };

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
    }
}