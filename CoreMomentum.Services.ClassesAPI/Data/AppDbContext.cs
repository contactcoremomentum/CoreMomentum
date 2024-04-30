using CoreMomentum.Services.ClassesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMomentum.Services.ClassesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Classes> Classess { get; set; }
        public DbSet<ClassWeekday> ClassWeekday { get; set; }
        public DbSet<Weekday> Weekday { get; set; }

        public DbSet<ClassFeedback> ClassFeedback { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>()
            .HasIndex(u => u.ClassesCode)
            .IsUnique();

            base.OnModelCreating(modelBuilder);

        }
    }
}
