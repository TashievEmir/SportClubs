using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface IDepartmentService
    {
        List<Department> GetDepartments();
        List<Department> GetDepartmentsById(int facultyId);
    }
}
