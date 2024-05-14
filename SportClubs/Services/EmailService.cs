using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SportClubs.Interfaces;
using SportClubs.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SportClubs.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMemoryCache _cache;
        public EmailService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public int GenerateVerifyCode()
        {
            Random random = new Random();
            return random.Next(1000, 10000);
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

        public void SendEmail(string email)
        {
            var code = GenerateVerifyCode();

            _cache.Set(email, code, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            });

            Send(email, code);
        }

        public bool VerifyEmail(VerifyEmailDto request)
        {
            _cache.TryGetValue(request.Email, out string code);

            if (code is null)
            {
                throw new Exception("Code hasn't been provided");
            }

            if (code == request.Code)
            {
                return true;
            }
            return false ;
        }
    }
}
