using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SportClubs.Interfaces;
using System.Net.Mail;

namespace SportClubs.Services
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {
        }

        public void Send(string mail, int verificationCode)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("tes01.star@gmail.com"));
            email.To.Add(MailboxAddress.Parse(mail));
            email.Subject = "Title";
            email.Body = new TextPart(TextFormat.Html) { Text = $" Your verification code: {verificationCode} " };

            // send email
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("tes01.star@gmail.com", "hwxrwoardwqjpdkn");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
