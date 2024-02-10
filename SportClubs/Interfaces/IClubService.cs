using Microsoft.AspNetCore.Mvc;
using SportClubs.Entities;
using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface IClubService
    {
        List<Club> GetClubs();
        List<Student> GetMembersByClubId(int id);
        Schedule GetTimetable(int id);
        ActionResult<string> ApplyToClub(ClubApplicationDto request);
    }
}
