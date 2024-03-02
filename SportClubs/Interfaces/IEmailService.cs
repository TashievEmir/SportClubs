using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(string email);

        void Send(string email, int verificationCode);

        int GenerateVerifyCode();

        bool VerifyEmail(VerifyEmailDto request);
    }
}
