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
        public Club Club { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
