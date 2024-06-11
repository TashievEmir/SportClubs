using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
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

        public ActionResult<string> ApproveToClub(string email, int clubId)
        {
            var student = _context.Students.AsNoTracking().FirstOrDefault(x => x.Email == email);

            var studentClub = _context.StudentClubs.FirstOrDefault(x => x.StudentId == student.Id && x.ClubId == clubId);

            var club = _context.Clubs.FirstOrDefault(x => x.Id == clubId);

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

            string message = $"Сиз {club.Name} клубуна кабыл алындыңыз";
            SendEmail(email, message);

            return new OkObjectResult("Student has been approved");
        }

        private void SendEmail(string mail, string message)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("tes01.star@gmail.com"));
            email.To.Add(MailboxAddress.Parse(mail));
            email.Subject = "Title";
            email.Body = new TextPart(TextFormat.Html) { Text = $"{message}" };

            // send email
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("tes01.star@gmail.com", "hwxrwoardwqjpdkn");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public Student GetStudentByUserId(int id)
        {
            return _context.Students.AsNoTracking().FirstOrDefault(x => x.UserId == id);
        }

        public ActionResult<string> RejectFromClub(string email, int clubId)
        {
            var student = _context.Students.AsNoTracking().FirstOrDefault(x => x.Email == email);

            var studentClub = _context.StudentClubs.FirstOrDefault(x => x.StudentId == (student == null ? 0 : student.Id)  && x.ClubId == clubId);

            var club = _context.Clubs.FirstOrDefault(x => x.Id == clubId);

            try
            {
                _context.StudentClubs.Remove(studentClub);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            string message = $"Сиз {club.Name} клубуна кабыл алынган жоксуңуз!";
            SendEmail(email, message);

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
