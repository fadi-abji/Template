using Business.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppWithIdentity.Data
{
    public class ApplicationDbContext : MainDbContext
    {
        public ApplicationDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }
    }
}
