﻿namespace SportClubs.Entities
{
    public class SportCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public Schedule Schedule { get; set; }
        public List<StudentClub> StudentClubs { get; set; }
    }
}
