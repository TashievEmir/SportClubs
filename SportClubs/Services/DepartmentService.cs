using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;

namespace SportClubs.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDbContext _context;
        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }
        public List<Department> GetDepartments()
        {
            return _context.Departments.AsNoTracking().ToList();
        }

        public List<Department> GetDepartmentsById(int facultyId)
        {
            return _context.Departments.Where(x => x.FacultyId == facultyId).AsNoTracking().ToList();
        }
    }
}
