using SportClubs.Entities;
using SportClubs.Helpers;
using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
        RefreshToken GenerateRefreshToken();
        void SetRefreshToken(RefreshToken refreshToken, User user);
    }
}
