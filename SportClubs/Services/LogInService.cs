﻿using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Interfaces;
using SportClubs.Models;

namespace SportClubs.Services
{
    public class LogInService : ILogInService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public LogInService(AppDbContext context, IConfiguration configuration, ITokenService tokenService)
        {
            _context = context;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public TokenModel LogIn(LogInDto request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Login == request.Login);

            if (user is null)
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

            var response = new TokenModel
            {
                AccessToken = token,
                RefreshToken = refreshToken,
            };
            return response;
        }
    }
}
