using Microsoft.AspNetCore.Mvc;
using SportClubs.Interfaces;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        public ClubController( IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_clubService.GetClubs());
        }

        [HttpGet]
        public async Task<ActionResult> GetMembers(int id)
        {
            return Ok(_clubService.GetMembersByClubId(id));
        }

        [HttpGet]
        public async Task<ActionResult> GetSchedule(int id)
        {
            return Ok(_clubService.GetTimetable(id));
        }
    }
}
