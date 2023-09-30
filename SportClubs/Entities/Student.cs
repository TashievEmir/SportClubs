namespace SportClubs.Entities
{
    public class Student
    {
        public double StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public int? Grade { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<StudentClub> StudentClubs { get; set; }
        
    }
}
