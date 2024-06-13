using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;
using SportClubs.Models;

namespace SportClubs.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly AppDbContext _appDbContext;
        public TeacherService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public ActionResult DeleteTeacher(int teacherId)
        {
            var teacher = _appDbContext.Teachers.FirstOrDefault(x => x.Id == teacherId);

            try
            {
                _appDbContext.Teachers.Remove(teacher);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }

            return new OkObjectResult("Teacher deleted succsefully");
        }

        public List<Teacher> GetFreeTeachers()
        {
            var teachers = _appDbContext.Teachers.AsNoTracking().ToList();
            var clubs = _appDbContext.Clubs.AsNoTracking().ToList();

            var teacherIdsInClubs = clubs.Select(c => c.TeacherId).ToList();
            var freeTeachers = teachers.Where(t => !teacherIdsInClubs.Contains(t.Id)).ToList();

            return freeTeachers;
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

        public List<TeachersReturnDto> GetTeachers()
        {
            List<TeachersReturnDto> teachersReturnDtos = new List<TeachersReturnDto>();
            var teachers = _appDbContext.Teachers.AsNoTracking().ToList();

            foreach ( var teacher in teachers)
            {
                var club = _appDbContext.Clubs.FirstOrDefault(x => x.TeacherId == teacher.Id);
                var department = _appDbContext.Departments.FirstOrDefault(x => x.Id == teacher.DepartmentId);
                var faculty = _appDbContext.Faculties.FirstOrDefault(x => x.Id == department.FacultyId);

                TeachersReturnDto teachersReturnDto = new TeachersReturnDto
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    Photo = teacher.Photo,
                    Phone = teacher.Phone,
                    Email = teacher.Email,
                    UserId = teacher.UserId,
                    Club = club is not null ? club.Name : "Клуб бериле элек",
                    Faculty = faculty.Name,
                    Department = department.Name
                };

                teachersReturnDtos.Add(teachersReturnDto);
            }

            return teachersReturnDtos;
        }
    }
}
