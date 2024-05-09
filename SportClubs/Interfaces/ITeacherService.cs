using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface ITeacherService
    {
        List<Teacher> GetTeachers();
        List<Teacher> GetFreeTeachers();
        Teacher GetTeacherByFullname(string email);
    }
}
