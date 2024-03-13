using AutoMapper.Configuration.Conventions;

namespace SportClubs.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public int? ClubId {get; set;}
        public Club Club { get; set;}
        public int? AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }
    }
}
