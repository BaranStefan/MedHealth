using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace YourProjectName.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<User> Users { get; set; }

        // DbSet for other entities...
    }
}
