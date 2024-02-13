
using SendGrid.Helpers.Mail;
using SendGrid;

namespace HangFire.WEB.Services
{
    public class EmailSender : IEmeailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Sender(string userId, string message)
        {
            //bu sahip userId yi bul ve emaill adresini all


            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("swouz@hotmail.com", "Example User");
            var subject = "www.mysite.com bilgilendirme";
            var to = new EmailAddress("oguzsavas.43@gmail.com", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
