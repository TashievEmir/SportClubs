namespace SportClubs.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Teacher TeacherId { get; set; }
    }
}
