using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            try
            {
                _context.StudentClubs.Remove(studentClub);
                _context.SaveChanges();
            }
            catch (Exception error)
            {
                throw new Exception($"{error.Message}");
            }


            return new OkObjectResult("Your request done succesfully");
        }

        public ActionResult<string> ApplyToClub(ClubApplicationDto request)
        {
            var user = _userService.GetUserByEmail(request.User);
            var student = _context.Students.FirstOrDefault(x => x.UserId == user.Id);
            var club = GetClubByName(request.Club);

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

            return new OkObjectResult("Your request has been sent to teacher");
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

        public Club GetClubByTeacherId(int teacherId)
        {
            var club = _context.Clubs.AsNoTracking().FirstOrDefault(x => x.TeacherId == teacherId);11
            return club;
        }

        public List<Club> GetClubs()
        {
            return _context.Clubs.AsNoTracking().ToList();
        }

        public List<Student> GetMembersByClubId(int clubId)
        {
            var studentIds = _context.StudentClubs.Where(x => x.ClubId == clubId && x.Status == true).AsNoTracking().Select(x => x.StudentId).ToList();

            List<Student> students = new List<Student>();
            foreach (var student in studentIds)
            {
                students.Add(_context.Students.FirstOrDefault(x => x.Id == student));
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
