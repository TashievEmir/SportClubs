using Microsoft.EntityFrameworkCore;
using SportClubs.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SportClubs.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public AppDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);
        }
    }
}
