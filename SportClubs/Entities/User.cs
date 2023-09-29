namespace SportClubs.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
