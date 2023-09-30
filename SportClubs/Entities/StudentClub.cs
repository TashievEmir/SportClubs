namespace SportClubs.Entities
{
    public class StudentClub
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public double StudentId { get; set; }
        public Student Student { get; set; }
        public string Place { get; set; }
        public bool Status { get; set; }
        public DateTime SelectionDate { get; set; }
    }
}
