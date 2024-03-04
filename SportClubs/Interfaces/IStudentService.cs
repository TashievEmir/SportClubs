using Microsoft.AspNetCore.Mvc;
using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface IStudentService
    {
        Student GetStudentByUserId(int id);
        Task RemoveFromClub(string email);
    }
}
