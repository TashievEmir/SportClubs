using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Enums;
using SportClubs.Interfaces;
using SportClubs.Models;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SportClubs.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IMemoryCache _cache;
        public RegistrationService(AppDbContext context, IConfiguration configuration, ITokenService tokenService, IEmailService emailService, IMemoryCache cache)
        {
            _context = context;
            _configuration = configuration;
            _tokenService = tokenService;
            _emailService = emailService;
            _cache = cache;
        }

        public ActionResult<string> Register(RegistrationDto user)
        {
            if (!CheckValidManasEmail(user.Email))
            {
                return new BadRequestObjectResult("Invalid Manas email");
            }

            if (CheckTeacherEmail(user.Email))
            {
                RegisterTeacher(user);
                return new OkObjectResult("User added succesfully");
            }

            if(CheckStudentEmail(user.Email))
            {
                RegisterStudent(user);
                return new OkObjectResult("User added succesfully");
            }

            return new BadRequestObjectResult("Incorrect Manas Email");
        }

        public void RegisterStudent(RegistrationDto request)
        {
            RegisterUser(request, Role.student);

            var userId = _context.Users.AsNoTracking().FirstOrDefault(x => x.Login == request.Email).Id;

            Student student = new Student
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Email = request.Email,
                Phone = request.Phone,
                DepartmentId = Convert.ToInt32(request.Department),
                UserId = userId
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                request.Photo.CopyTo(memoryStream);
                student.Photo = memoryStream.ToArray();
            }

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

        public void RegisterTeacher(RegistrationDto request)
        {
            RegisterUser(request, Role.teacher);

            var userId = _context.Users.AsNoTracking().FirstOrDefault(x => x.Login == request.Email).Id;

            Teacher teacher = new Teacher
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                Email = request.Email,
                Phone = request.Phone,
                DepartmentId = Convert.ToInt32(request.Department),
                UserId = userId
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                request.Photo.CopyTo(memoryStream);
                teacher.Photo = memoryStream.ToArray();
            }

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

        public void RegisterUser(RegistrationDto request, Role role)
        {
            /*if (!IsStrongPassword(request.Password))
            {
                throw new Exception("Password is not strong");
            }*/

            User user = new User()
            {
                Login = request.Email,
                Password = CreatePasswordHash(request.Password),
                Role = (int)role
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

        private bool CheckValidManasEmail(string email)
        {
            string pattern = @"^[A-Za-z0-9._%+-]+@manas\.edu\.kg$";

            var answer = Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);

            return answer;
        }

        private bool IsStrongPassword(string password)
        {
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d).{6,}$";

            return Regex.IsMatch(password, pattern);
        }

        private string CreatePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool CheckTeacherEmail(string email)
        {
            string pattern = @"^[a-zA-Z.]+@manas\.edu\.kg$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        private bool CheckStudentEmail(string email)
        {
            string pattern = @"^[0-9.]+@manas\.edu\.kg$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
}
