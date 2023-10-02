using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportClubs.Data;
using SportClubs.Models;
using System.Security.Cryptography;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        AppDbContext _context;

        public AccountController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInRequest request)
        {
            

            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterRequest user)
        {
            

            return Ok();
        }
    }
}
