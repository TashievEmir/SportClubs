using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;

namespace SportClubs.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _appDbContext;
        public TeacherService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public Teacher GetTeacherByFullname(string fullname)
        {
            string[] fullName = fullname.Split(' ');
            if (fullName.Count() == 2)
            {
                return _appDbContext.Teachers.AsNoTracking().FirstOrDefault(x => x.LastName == fullName[0] && x.FirstName == fullName[1]);
            }
            return _appDbContext.Teachers.AsNoTracking().FirstOrDefault(x => x.LastName == $"{fullName[0]} {fullName[1]}" && x.FirstName == fullName[2]);
        }

        public List<Teacher> GetTeachers()
        {
            return _appDbContext.Teachers.AsNoTracking().ToList();
        }
    }
}
