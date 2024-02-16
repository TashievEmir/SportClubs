using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface ITeacherService
    {
        List<Teacher> GetTeachers();
        Teacher GetTeacherByFullname(string email);
    }
}
