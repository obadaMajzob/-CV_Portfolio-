namespace CVproject.Helpers.Email
{
    public interface IEmailHelper
    {
        void SendEmail(string toEmail, string subject, string body);
        void SendEmailHTMLBody(string toEmail, string subject, string htmlMessage);

    }
}
