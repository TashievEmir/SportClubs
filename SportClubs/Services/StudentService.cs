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

        public ActionResult<string> ApproveToClub(string email)
        {
            var student = _context.Students.AsNoTracking().FirstOrDefault(x => x.Email == email);

            var studentClub = _context.StudentClubs.FirstOrDefault(x => x.StudentId == student.Id);

            if (studentClub is not null)
            {
                studentClub.Status = true;
            }

            try
            {
                _context.StudentClubs.Update(studentClub);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return new OkObjectResult("Student has been approved");
        }

        public Student GetStudentByUserId(int id)
        {
            return _context.Students.AsNoTracking().FirstOrDefault(x => x.UserId == id);
        }

        public ActionResult<string> RejectFromClub(string email)
        {
            var student = _context.Students.AsNoTracking().FirstOrDefault(x => x.Email == email);

            var studentClub = _context.StudentClubs.FirstOrDefault(x => x.StudentId == (student == null ? 0 : student.Id));

            try
            {
                _context.StudentClubs.Remove(studentClub);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new OkObjectResult("Student has been rejected succesfully");
        }

        public ActionResult<string> RemoveFromClub(string email)
        {
            var student = _context.Students.AsNoTracking().FirstOrDefault(x => x.Email == email);

            var studentClub = _context.StudentClubs.FirstOrDefault(x => x.StudentId == student.Id);

            try
            {
                _context.StudentClubs.Remove(studentClub);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new OkObjectResult("Student has been deleted succesfully");
        }

        public StudentClub GetStatusInClub(int userId, int clubId)
        {
            var student = _context.Students.AsNoTracking().FirstOrDefault(x => x.UserId == userId);

            return  _context.StudentClubs.FirstOrDefault(x => x.StudentId == student.Id && x.ClubId == clubId);

        }
    }
}
