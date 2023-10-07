using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Enums;
using SportClubs.Interfaces;
using SportClubs.Models;
using System.Text.RegularExpressions;

namespace SportClubs.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public RegistrationService(AppDbContext context, IConfiguration configuration, ITokenService tokenService)
        {
            _context = context;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        public ActionResult<string> Register(RegistrationDto user)
        {
            if (!CheckValidManasEmail(user.Email))
            {
                return new BadRequestObjectResult("Invalid Manas email");
            }

            bool isDouble = double.TryParse(user.Number, out _);
            bool isInt = int.TryParse(user.Number, out _);

            if (isDouble)
            {
                RegisterStudent(user);
            }
            else if (isInt)
            {
                RegisterTeacher(user);
            }
            else
            {
                return new BadRequestObjectResult("Invalid Teacher/Student number");
            }

            return new OkObjectResult("User added succesfully");
        }

        public void RegisterStudent(RegistrationDto request)
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

        public void RegisterTeacher(RegistrationDto request)
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

        public void RegisterUser(RegistrationDto request, string role)
        {
            if (!IsStrongPassword(request.Password))
            {
                throw new Exception("Password is not strong");
            }

            User user = new User()
            {
                Login = request.Email,
                Password = CreatePasswordHash(request.Password),
                Role = Convert.ToInt32((Role)Enum.Parse(typeof(Role), role))
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

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
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
    }
}
