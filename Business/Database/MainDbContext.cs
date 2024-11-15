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
        public DbSet<Dal.Models.Movie> Movie { get; set; }
    }
}
