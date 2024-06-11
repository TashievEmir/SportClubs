using Microsoft.AspNetCore.Mvc;
using SportClubs.Entities;
using SportClubs.Interfaces;
using SportClubs.Models;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        public ClubController( IClubService clubService, IStudentService studentService, ITeacherService teacherService)
        {
            _clubService = clubService;
            _studentService = studentService;
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_clubService.GetClubs());
        }

        [HttpGet]
        public async Task<ActionResult> GetTeacherClub(int userId)
        {
            return Ok(_clubService.GetClubByTeacherId(userId));
        }

        [HttpGet]
        public async Task<ActionResult> GetMembers(int clubId)
        {
            return Ok(_clubService.GetMembersByClubId(clubId));
        }

        [HttpGet]
        public async Task<ActionResult> GetSchedule(int clubId)
        {
            return Ok(_clubService.GetTimetable(clubId));
        }

        [HttpPost]
        public async Task<ActionResult> Apply(ClubApplicationDto request)
        {
            return Ok(_clubService.ApplyToClub(request));
        }

        [HttpDelete]
        public async Task<ActionResult> Abandon(ClubApplicationDto request)
        {
            return Ok(_clubService.AbandonClub(request));
        }

        [HttpGet]
        public async Task<ActionResult> GetCandidates(int clubId)
        {
            return Ok(_clubService.GetCandidates(clubId));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm]ClubCreationDto club)
        {
            return Ok(_clubService.CreateClub(club));
        }

        [HttpDelete("{studentEmail}")]
        public async Task<ActionResult> RemoveStudent(string studentEmail)
        {
            return Ok(_studentService.RemoveFromClub(studentEmail));
        }

        [HttpPut]
        public async Task<ActionResult> ApproveStudent(StudentEmailDto student)
        {
            return Ok(_studentService.ApproveToClub(student.Email, student.ClubId));
        }

        [HttpDelete("{studentEmail}")]
        public async Task<ActionResult> RejectStudent(string studentEmail, int clubId)
        {
            return Ok(_studentService.RejectFromClub(studentEmail, clubId));
        }

        [HttpGet]
        public async Task<ActionResult> GetStudentStatus(int userId, int clubId)
        {
            return Ok(_studentService.GetStatusInClub(userId, clubId));
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSchedule(ScheduleDto schedule)
        {
            return Ok(_clubService.UpdateSchedule(schedule));
        }
    }
}
