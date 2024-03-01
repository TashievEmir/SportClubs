namespace SportClubs.Interfaces
{
    public interface IEmailService
    {
        void Send(string email, int verificationCode);
    }
}
