using Microsoft.EntityFrameworkCore;

namespace SportClubs.Models
{
    public class ScheduleDto
    {
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public string Place { get; set; }
        public string? Auditorium { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int ClubId { get; set; }
    }
}
