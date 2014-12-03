using System.Configuration;
using System.Net;
using System.Net.Mail;

using SendGrid;

namespace AzureDemoCiber
{
    public class SendgridService
    {
        public void Send(string to, string subject, string text)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(to);
            myMessage.From = new MailAddress("julenissen@ciber.no", "Ciber");
            myMessage.Subject = subject;
            myMessage.Text = text;

            // Create credentials, specifying your user name and password.
            var userName = ConfigurationManager.AppSettings["SendGridUser"];
            var password = ConfigurationManager.AppSettings["SendGridPassword"];
            var credentials = new NetworkCredential(userName, password);

            // Create an Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            transportWeb.Deliver(myMessage);
        }
    }
}