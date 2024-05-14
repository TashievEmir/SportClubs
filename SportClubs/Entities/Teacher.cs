using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportClubs.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Club Club { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
