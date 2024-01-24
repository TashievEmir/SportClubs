using Microsoft.AspNetCore.Mvc;
using SportClubs.Models;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AnnouncementController : ControllerBase
    {
        public AnnouncementController ()
        {
            
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
        }
    }
}
