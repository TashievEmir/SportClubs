using SportClubs.Entities;

namespace SportClubs.Interfaces
{
    public interface IAnnouncementService
    {
        List<Announcement> GetAnnouncements();
    }
}
