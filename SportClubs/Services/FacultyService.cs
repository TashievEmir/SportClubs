using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;

namespace SportClubs.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly AppDbContext _context;
        public FacultyService(AppDbContext context)
        {
            _context = context;
        }
        public List<Faculty> GetFaculties()
        {
            return _context.Faculties.AsNoTracking().ToList();
        }
    }
}
