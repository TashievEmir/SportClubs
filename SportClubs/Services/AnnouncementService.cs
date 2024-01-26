using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;

namespace SportClubs.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly AppDbContext _context;
        public AnnouncementService(AppDbContext context)
        {
            _context = context;
        }
        public List<Announcement> GetAnnouncements()
        {
            return _context.Announcements.ToList();
        }
    }
}
