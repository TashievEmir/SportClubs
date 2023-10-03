using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;
using SportClubs.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SportClubs.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        public AccountService(AppDbContext context, IConfiguration configuration, ITokenService tokenService)
        {
            _context = context;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public void LogIn(LogInDto request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == request.Login);

            if (user is not null)
            {
                throw new Exception("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new Exception("Incorrect password");
            }

            string token = _tokenService.CreateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            _tokenService.SetRefreshToken(refreshToken, user);
        }

        public void Register(RegisterDto user)
        {
            throw new NotImplementedException();
        }

        public string CreatePasswordHash(string password)
        {
            string newPassword = BCrypt.Net.BCrypt.HashPassword(password);

            return newPassword;
        }
    }
}
