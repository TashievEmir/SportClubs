using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;

namespace SportClubs.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) 
        { 
            _context = context;
        }
        public User GetUserByEmail(string login)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Login == login);
        }
    }
}
