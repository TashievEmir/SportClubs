using Microsoft.AspNetCore.Mvc;
using SportClubs.Entities;
using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface ITeacherService
    {
        List<TeachersReturnDto> GetTeachers();
        List<Teacher> GetFreeTeachers();
        Teacher GetTeacherByFullname(string email);
        ActionResult DeleteTeacher(int teacherId);
    }
}
