using Microsoft.AspNetCore.Mvc;
using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface IStudentService
    {
        Student GetStudentByUserId(int id);
        ActionResult<string> RemoveFromClub(string email);
        ActionResult<string> ApproveToClub(string email);
        ActionResult<string> RejectFromClub(string email);
    }
}
