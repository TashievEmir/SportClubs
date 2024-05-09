using Microsoft.AspNetCore.Mvc;
using SportClubs.Entities;
using SportClubs.Models;

namespace SportClubs.Interfaces
{
    public interface IAnnouncementService
    {
        List<Announcement> GetAnnouncements();
        ActionResult CreateAnnouncement(AnnouncementCreationDto announcement);
        ActionResult DeleteAnnouncement(int announcementId);
    }
}
