using Microsoft.AspNetCore.Mvc;
using SportClubs.Interfaces;
using SportClubs.Models;
using SportClubs.Services;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController ( IAnnouncementService announcementService )
        {
            _announcementService = announcementService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_announcementService.GetAnnouncements());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] AnnouncementCreationDto announcement)
        {
            return Ok(_announcementService.CreateAnnouncement(announcement));
        }
    }
}
