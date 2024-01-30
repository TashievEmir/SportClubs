using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;

namespace SportClubs.Services
{
    public class ClubService : IClubService
    {
        private readonly AppDbContext _context;

        public ClubService(AppDbContext context)
        {
            _context = context;
        }

        public List<Club> GetClubs()
        {
            return _context.Clubs.AsNoTracking().ToList();
        }

        public List<Student> GetMembersByClubId(int id)
        {
            var studentIds = _context.StudentClubs.Where(x => x.ClubId == id).AsNoTracking().Select(x => x.StudentId).ToList();

            List<Student> students = new List<Student>();
            foreach (var student in studentIds)
            {
                students.Add(_context.Students.FirstOrDefault(x => x.Id == student));
            }
            return students;
        }
    }
}
