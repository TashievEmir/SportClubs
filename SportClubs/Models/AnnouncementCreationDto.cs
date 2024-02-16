namespace SportClubs.Models
{
    public class AnnouncementCreationDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public IFormFile Photo { get; set; }
    }
}
