using System.Net.Mail;
using System.Net;

namespace CVproject.Helpers.Email
{
    public class EmailSettings
    {
        public int smtpPort { get; set; }
        public string smtpServer { get; set; }
        public string FromEmail { get; set; }
        public string password { get; set; }

    }

    public class EmailHelper : IEmailHelper
    {
        IConfiguration Configuration;

        public EmailHelper(IConfiguration configuration)
        {
            Configuration=configuration;
        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            /////////////////////// DynamicEmail
            var EMailSettings = Configuration.GetSection("EmailSettings").Get<EmailSettings>();

            ////Mail Settings 
            //// SMTP Port 
            //// SMTP Server 
            //// Email
            //// Password

            //var smtpPort = 587 ;
            //var smtpServer = "smtp.gmail.com ";
            //var FromEmail = "kynanmajthob@gmail.com";
            //var password = "qqzv pigp dqwj ezmv";

            var smtpPort = EMailSettings.smtpPort;
            var smtpServer = EMailSettings.smtpServer;
            var FromEmail = EMailSettings.FromEmail;
            var password = EMailSettings.password;


            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(FromEmail, password);
            MailMessage mailMessage = new MailMessage(); 

            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.Subject = subject;
            mailMessage.To.Add(toEmail);
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;
            smtpClient.Send(mailMessage);

        }

        public void SendEmailHTMLBody(string toEmail, string subject, string htmlMessage)
        {
            var emailConfig = Configuration.GetSection("EmailSettings").Get<EmailSettings>();

            var smtpPort = emailConfig.smtpPort;
            var smtpServer = emailConfig.smtpServer;
            var FromEmail = emailConfig.FromEmail;
            var password = emailConfig.password;



            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(FromEmail, password);
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(FromEmail);
            mail.Subject = subject;
            mail.To.Add(toEmail);
            mail.Body = htmlMessage;
            mail.IsBodyHtml = true;
            smtpClient.Send(mail);




            //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            //smtpClient.EnableSsl = true;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.Credentials = new NetworkCredential(FromEmail, password);
            //MailMessage mailMessage = new MailMessage();

            //mailMessage.From = new MailAddress(FromEmail);
            //mailMessage.Subject = subject;
            //mailMessage.To.Add(toEmail);
            //mailMessage.IsBodyHtml = true;
            //mailMessage.Body = htmlMessage;
            //smtpClient.Send(mailMessage);

        }
    }
}
