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
        IAccountService _accountService;

        public AccountController(AppDbContext context, IMapper mapper, IAccountService accountService)
        {
            _context = context;
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInDto request)
        {
            return Ok(_accountService.LogIn(request));
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegistrationDto user)
        {
            

            return Ok();
        }
    }
}
