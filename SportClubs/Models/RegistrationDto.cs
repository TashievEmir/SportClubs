namespace SportClubs.Models
{
    public class RegistrationDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string Phone { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
    }
}
