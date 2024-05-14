using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportClubs.Data;
using SportClubs.Entities;
using SportClubs.Interfaces;
using SportClubs.Models;
using System.Text;

namespace SportClubs.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly AppDbContext _context;
        public AnnouncementService(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult CreateAnnouncement(AnnouncementCreationDto announcement)
        {
            Announcement _announcement = new Announcement()
            {
                Title = announcement.Title,
                Description = announcement.Description,
                Date = announcement.CreationDate,
                Photo = announcement.Photo
            };
            /*using (MemoryStream memoryStream = new MemoryStream())
            {
                announcement.Photo.CopyTo(memoryStream);
                _announcement.Photo = memoryStream.ToArray();
            }*/
            try
            {
                _context.Announcements.Add(_announcement);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Can't save announcement");
            }

            return new OkObjectResult("Announcement saved succesfully");
        }

        public ActionResult DeleteAnnouncement(int announcementId)
        {
            var announcement = _context.Announcements.FirstOrDefault(x => x.Id == announcementId);

            try
            {
                _context.Announcements.Remove(announcement);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Can't delete announcement");
            }

            return new OkObjectResult("Announcement deleted succesfully");
        }

        public List<Announcement> GetAnnouncements()
        {
            return _context.Announcements.AsNoTracking().ToList();
        }
    }
}
