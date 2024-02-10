using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface IStudentService
    {
        Student GetStudentByUserId(int id);
    }
}
