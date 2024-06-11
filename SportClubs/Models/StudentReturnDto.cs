using SportClubs.Entities;

namespace SportClubs.Models
{
    public class StudentReturnDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FacultyName { get; set; }
        public string DepartmentName { get; set; }
    }
}
