using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface IClubService
    {
        List<Club> GetClubs();
        List<Student> GetMembersByClubId(int id);
        Schedule GetTimetable(int id);
    }
}
