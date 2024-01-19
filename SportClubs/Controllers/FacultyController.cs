using Microsoft.AspNetCore.Mvc;
using SportClubs.Interfaces;
using SportClubs.Models;
using SportClubs.Services;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class FacultyController : ControllerBase
    {
        IFacultyService _facultyService;
        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_facultyService.GetFaculties());
        }
    }
}
