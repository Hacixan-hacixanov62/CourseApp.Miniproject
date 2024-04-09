using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Education> Educations { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-LQO56E8\\SQLEXPRESS;Database=EFCourseApp;Trusted_Connection=true;TrustServerCertificate=True");
        }

    }





}
