using Microsoft.AspNetCore.Mvc;
using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface ITeacherService
    {
        List<Teacher> GetTeachers();
        List<Teacher> GetFreeTeachers();
        Teacher GetTeacherByFullname(string email);
        ActionResult DeleteTeacher(int teacherId);
    }
}
