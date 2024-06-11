using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Text;
using MimeKit;
using Org.BouncyCastle.Asn1.Ocsp;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;
using SportClubs.Models;

namespace SportClubs.Services
{
    public class ClubService : IClubService
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;

        public ClubService(AppDbContext context, IUserService userService, IStudentService studentService, ITeacherService teacherService)
        {
            _context = context;
            _userService = userService;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        public ActionResult<string> AbandonClub(ClubApplicationDto request)
        {
            var user = _userService.GetUserByEmail(request.User);
            var student = _studentService.GetStudentByUserId(user.Id);
            var club = GetClubByName(request.Club);
            var studentClub = _context.StudentClubs.AsNoTracking().FirstOrDefault(x => x.ClubId == club.Id && x.StudentId == student.Id);
            var teacher = _context.Teachers.AsNoTracking().FirstOrDefault(x => x.Id == club.TeacherId);

            try
            {
                _context.StudentClubs.Remove(studentClub);
                _context.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception($"{error.Message}");
            }

            var message = $"{request.Club} клубундан {student.LastName} {student.FirstName} аттуу студент баш тартты";
            SendEmail(teacher.Email, message);

            return new OkObjectResult("Your request done succesfully");
        }

        public ActionResult<string> ApplyToClub(ClubApplicationDto request)
        {
            var user = _userService.GetUserByEmail(request.User);
            var student = _context.Students.FirstOrDefault(x => x.UserId == user.Id);
            var club = GetClubByName(request.Club);
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == club.TeacherId);

            StudentClub studentClub = new StudentClub()
            {
                ClubId = club.Id,
                StudentId = student.Id,
                Place = "test",
                Status = false,
                SelectionDate = DateTime.Now.ToUniversalTime()
            };

            try
            {
                _context.StudentClubs.Add(studentClub);
                _context.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception($"{error.Message}");
            }

            var message = $"{request.Club} клубуна {student.LastName} {student.FirstName} аттуу студент табыштама жөнөтү";
            SendEmail(teacher.Email, message);

            return new OkObjectResult("Your request has been sent to teacher");
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

        public ActionResult CreateClub(ClubCreationDto club)
        {
            var teacher = _teacherService.GetTeacherByFullname(club.Teacher);

            if (teacher is not null)
            {
                Club _club = new Club
                {
                    Name = club.Name,
                    Description = club.Description,
                    TeacherId = teacher.Id,
                    Photo = club.Photo
                };

                try
                {
                    _context.Clubs.Add(_club);
                    _context.SaveChanges();
                }
                catch (Exception error)
                {
                    throw new NotImplementedException($" {error.Message} ");
                }

                return new OkObjectResult("New club saved succesfully");
            }

            throw new NotImplementedException("There is no such teacher");
        }

        public List<Student> GetCandidates(int clubId)
        {
            List<StudentClub> candidates = new List<StudentClub>();
            List<Student> students = new List<Student>();
            try
            {
                candidates = _context.StudentClubs.Where(x => x.Status == false && x.ClubId == clubId).AsNoTracking().ToList();
                foreach(var item in candidates)
                {
                    var student = _context.Students.AsNoTracking().FirstOrDefault(x => x.Id == item.StudentId);
                    students.Add(student);
                }
                
            }
            catch (Exception error)
            {
                throw new NotImplementedException("Can't get candidates");
            }
            return students;
        }

        public Club GetClubByName(string name)
        {
            return _context.Clubs.AsNoTracking().FirstOrDefault(x => x.Name == name);
        }

        public Club GetClubByTeacherId(int userId)
        {
            var teacher = _context.Teachers.AsNoTracking().FirstOrDefault(x => x.UserId == userId);
            var club = _context.Clubs.AsNoTracking().FirstOrDefault(x => x.TeacherId == teacher.Id);
            return club;
        }

        public List<Club> GetClubs()
        {
            return _context.Clubs.AsNoTracking().ToList();
        }

        public List<StudentReturnDto> GetMembersByClubId(int clubId)
        {
            var studentIds = _context.StudentClubs.Where(x => x.ClubId == clubId && x.Status == true).AsNoTracking().Select(x => x.StudentId).ToList();
            
            List<StudentReturnDto> students = new List<StudentReturnDto>();
            foreach (var student in studentIds)
            {
                var pupil = _context.Students.FirstOrDefault(x => x.Id == student);
                var department = _context.Departments.FirstOrDefault(x => x.Id == pupil.DepartmentId);
                var faculty = _context.Faculties.FirstOrDefault(x => x.Id == department.FacultyId);

                students.Add(new StudentReturnDto
                {
                    Id = pupil.Id,
                    LastName = pupil.LastName,
                    FirstName = pupil.FirstName,
                    Photo = pupil.Photo,
                    Email = pupil.Email,
                    Phone = pupil.Phone,
                    FacultyName = faculty.Name,
                    DepartmentName = department.Name
                });
            }
            return students;
        }

        public Schedule GetTimetable(int clubId)
        {
            return _context.Schedules.FirstOrDefault(x => x.ClubId == clubId);
        }

        public ActionResult<string> UpdateSchedule(ScheduleDto schedule)
        {
           var isSchedule = _context.Schedules.AsNoTracking().FirstOrDefault(x => x.ClubId == schedule.ClubId);

            if (isSchedule is not null)
            {
                isSchedule.Monday = schedule.Monday;
                isSchedule.Tuesday = schedule.Tuesday;
                isSchedule.Wednesday = schedule.Wednesday;
                isSchedule.Thursday = schedule.Thursday;
                isSchedule.Friday = schedule.Friday;
                isSchedule.Place = schedule.Place;
                isSchedule.Auditorium = schedule.Auditorium;
                isSchedule.StartTime = schedule.StartTime;
                isSchedule.EndTime = schedule.EndTime;

                _context.Schedules.Update(isSchedule);
                _context.SaveChanges();

                return new OkObjectResult("Updated succesfully");
            }

            Schedule newSchedule = new()
            {
                Monday = schedule.Monday,
                Tuesday = schedule.Tuesday,
                Wednesday = schedule.Wednesday,
                Thursday = schedule.Thursday,
                Friday = schedule.Friday,
                Place = schedule.Place,
                Auditorium = schedule.Auditorium,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                ClubId = schedule.ClubId,
            };

            _context.Schedules.Add(newSchedule);
            _context.SaveChanges();

            return new OkObjectResult("Schedul has been added");
        }
    }
}
