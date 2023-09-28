namespace SportClubs.Entities
{
    public class Student
    {
        public float StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public int? Grade { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Department DepartmentId { get; set; }
        public User UserId { get; set; }
        
    }
}
