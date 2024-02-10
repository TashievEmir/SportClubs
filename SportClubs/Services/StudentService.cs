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
    }
}
