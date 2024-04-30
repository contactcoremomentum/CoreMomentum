using System.ComponentModel;
using CoreMomentum.Services.StudentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMomentum.Services.StudentAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentFiles> StudentFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .HasIndex(u => u.email)
            .IsUnique();

            base.OnModelCreating(modelBuilder);

        }
    }
}
