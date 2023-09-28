namespace SportClubs.Entities
{
    public class Teacher
    {
        public float TeacherId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Office { get; set; }
        public Department DepartmentId { get; set; }
    }
}
