namespace SportClubs.Entities
{
    public class StudentClub
    {
        public Club ClubId { get; set; }
        public Student StudentId { get; set; }
        public string Place { get; set; }
        public bool Status { get; set; }
        public DateTime SelectionDate { get; set; }
    }
}
