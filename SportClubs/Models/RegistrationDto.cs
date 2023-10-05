namespace SportClubs.Models
{
    public class RegistrationDto
    {
        public string Number { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string Phone { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
    }
}
