using Microsoft.AspNetCore.Mvc;
using SportClubs.Entities;
using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface IClubService
    {
        List<Club> GetClubs();
        Club GetClubByTeacherId(int teacherId);
        List<StudentReturnDto> GetMembersByClubId(int clubId);
        Schedule GetTimetable(int clubId);
        ActionResult<string> ApplyToClub(ClubApplicationDto request);
        ActionResult<string> AbandonClub(ClubApplicationDto request);
        Club GetClubByName(string name);
        List<StudentReturnDto> GetCandidates(int clubId);
        ActionResult CreateClub(ClubCreationDto club);
        ActionResult<string> UpdateSchedule(ScheduleDto schedule);
    }
}
