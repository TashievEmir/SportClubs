namespace SportClubs.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public string Place { get; set; }
        public string? Auditorium { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Club ClubId { get; set; }
    }
}
