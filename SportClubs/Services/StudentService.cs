using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;

namespace SportClubs.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public Student GetStudentByUserId(int id)
        {
            return _context.Students.AsNoTracking().FirstOrDefault(x => x.UserId == id);
        }

        public async Task RemoveFromClub(string email)
        {
            var student = _context.Students.FirstOrDefault(x => x.Email == email);

            var studentClub = _context.StudentClubs.AsNoTracking().FirstOrDefault(x => x.StudentId == student.Id);

            try
            {
                _context.StudentClubs.Remove(studentClub);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
