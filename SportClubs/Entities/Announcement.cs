namespace SportClubs.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public DateOnly Date { get; set; }
    }
}
