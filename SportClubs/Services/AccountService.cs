using Microsoft.AspNetCore.Mvc;
using SportClubs.Data;
using SportClubs.Models;
using System.Security.Cryptography;

namespace SportClubs.Services
{
    public class AccountService
    {
        private AppDbContext _context;
        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public async void LogIn(LogInRequest request)
        {
            

       
        }

        public async void Register(RegisterRequest user)
        {

          
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt/* need change to password from DB */)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
