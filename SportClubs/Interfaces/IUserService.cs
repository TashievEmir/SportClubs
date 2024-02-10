using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
    }
}
