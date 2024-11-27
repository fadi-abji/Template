using Dal.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Business.DataBase
{
    public class MainDbContext(DbContextOptions<MainDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Define shared configurations
        }
        public DbSet<Dal.Movie> Movie { get; set; }
        public DbSet<Dal.Media> Media { get; set; }
        public DbSet<Dal.MovieMedia> MovieMedia { get; set; }
    }
}
