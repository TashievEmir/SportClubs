namespace SportClubs.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Faculty FacultyId { get; set; }
    }
}
