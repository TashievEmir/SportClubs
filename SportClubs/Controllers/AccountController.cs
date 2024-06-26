﻿using AutoMapper;
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
        IRegistrationService _registrationService;
        ILogInService _logInService;
        IEmailService _emailService;

        public AccountController(IRegistrationService registrationService, ILogInService logInService, IEmailService emailService)
        {
            _registrationService = registrationService;
            _logInService = logInService;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<ActionResult> LogIn(LogInDto request)
        {
            return Ok(_logInService.LogIn(request));
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register([FromForm] RegistrationDto user)
        {
            _registrationService.Register(user);
            return Ok("Code has been sent to email");
        }

        [HttpPost]
        public async Task<ActionResult<string>> SendEmail(SendEmailSto email)
        {
            _emailService.SendEmail(email.Email);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<string>> VerifyEmail(VerifyEmailDto request)
        {
            return _registrationService.VerifyEmail(request);
        }

    }
}
