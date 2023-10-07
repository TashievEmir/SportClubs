using Microsoft.AspNetCore.Mvc;
using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface IRegistrationService
    {
        ActionResult<string> Register(RegistrationDto request);
        void RegisterUser(RegistrationDto request, string role);
        void RegisterStudent(RegistrationDto request);
        void RegisterTeacher(RegistrationDto request);
    }
}
