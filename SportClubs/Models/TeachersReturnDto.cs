﻿using SportClubs.Entities;

namespace SportClubs.Models
{
    public class TeachersReturnDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Club { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public int UserId { get; set; }
    }
}
