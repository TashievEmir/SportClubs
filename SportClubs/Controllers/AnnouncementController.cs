using Microsoft.AspNetCore.Mvc;
using SportClubs.Interfaces;
using SportClubs.Models;

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
    }
}
