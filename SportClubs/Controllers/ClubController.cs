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
    }
}
