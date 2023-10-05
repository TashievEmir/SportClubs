using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Enums;
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

        public string CreatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public TokenModel LogIn(LogInDto request)
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

            var response = new TokenModel
            {
                AccessToken = token,
                RefreshToken = refreshToken,
            };
            return response;
        }

        public void Register(RegistrationDto user)
        {
            bool isDouble = double.TryParse(user.Number, out _);

            if (isDouble)
            {              
                RegisterStudent(user);
            }
            else
            {               
                RegisterTeacher(user);
            }
        }

        private void RegisterStudent(RegistrationDto request)
        {
            RegisterUser(request, "student");

            int departmentId = _context.Departments.FirstOrDefault(x => x.Name == request.Department).Id;
            var userId = _context.Users.FirstOrDefault(x => x.Login == request.Email).Id;

            Student student = new Student
            {
                StudentId = Convert.ToDouble(request.Number),
                LastName = request.LastName,
                FirstName = request.FirstName,
                Email = request.Email,
                Phone = request.Phone,
                DepartmentId = departmentId,
                UserId = userId
            };

            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception($"{error.Message}");
            }
        }

        private void RegisterTeacher(RegistrationDto request)
        {
            RegisterUser(request, "teacher");

            int departmentId = _context.Departments.FirstOrDefault(x => x.Name == request.Department).Id;
            var userId = _context.Users.FirstOrDefault(x => x.Login == request.Email).Id;

            Teacher teacher = new Teacher
            {
                TeacherId = Convert.ToInt32(request.Number),
                LastName = request.LastName,
                FirstName = request.FirstName,
                Email = request.Email,
                Phone = request.Phone,
                DepartmentId = departmentId,
                UserId = userId
            };

            try
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception($"{error.Message}");
            }
        }

        private void RegisterUser(RegistrationDto request, string role)
        {
            User user = new User()
            {
                Login = request.Email,
                Password = CreatePasswordHash(request.Password),
                Role = (int)Enum.ToObject(typeof(Role), role)
            };
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception($"{error.Message}");
            }

        }
    }
}
