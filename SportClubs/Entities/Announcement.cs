namespace SportClubs.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public DateTime Date { get; set; }
        public List<Image> Images { get; set; }
    }
}
