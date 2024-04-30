using System.ComponentModel;
using CoreMomentum.Services.AdminsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreMomentum.Services.AdminsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AdminsFiles> AdminsFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }
    }
}
