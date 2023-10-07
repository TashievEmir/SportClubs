using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface ILogInService
    {
        TokenModel LogIn(LogInDto request);
    }
}
