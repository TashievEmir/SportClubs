using Microsoft.AspNetCore.Mvc;
using SportClubs.Enums;
using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface IRegistrationService
    {
        void Register(RegistrationDto request);
        void RegisterUser(RegistrationDto request, Role role);
        void RegisterStudent(RegistrationDto request);
        void RegisterTeacher(RegistrationDto request);
        int GenerateVerifyCode();
        ActionResult<string> VerifyEmail(VerifyEmailDto request);
    }
}
