using Microsoft.EntityFrameworkCore;
using Torshia.Models;
using Torshia.Models.Enums;

namespace Torshia.Data
{
    public class TorshiaDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Models.Sector> Sectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(user => user.Id);
            modelBuilder.Entity<Task>()
                .HasKey(task => task.Id);
            modelBuilder.Entity<Task>()
                .Property(t => t.IsReported)
                .HasDefaultValue(false);
            modelBuilder.Entity<Report>()
                .HasKey(report => report.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
