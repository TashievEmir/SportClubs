using SportClubs.Entities;
using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface IAccountService
    {
        TokenModel LogIn(LogInDto request);
        void Register(RegistrationDto request);
        string CreatePasswordHash(string password);

    }
}
