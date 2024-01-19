using Microsoft.AspNetCore.Mvc;
using SportClubs.Interfaces;
using SportClubs.Models;
using SportClubs.Services;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_departmentService.GetDepartments());
        }
    }
}
