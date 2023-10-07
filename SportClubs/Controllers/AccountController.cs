using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportClubs.Data;
using SportClubs.Interfaces;
using SportClubs.Models;
using System;
using System.Security.Cryptography;

namespace SportClubs.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        AppDbContext _context;
        IRegistrationService _registrationService;
        ILogInService _logInService;

        public AccountController(AppDbContext context, IMapper mapper, IRegistrationService registrationService, ILogInService logInService)
        {
            _context = context;
            _mapper = mapper;
            _registrationService = registrationService;
            _logInService = logInService;
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInDto request)
        {
            return Ok(_logInService.LogIn(request));
        }
        [HttpPost]
        public async Task<ActionResult<string>> Register(RegistrationDto user)
        {
            return  _registrationService.Register(user);
        }
    }
}
