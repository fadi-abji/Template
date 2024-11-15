using Business.DataBase;
using Business.Movie.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Movie.Services
{
    public class MovieService : IMovieService
    {
        private readonly IDbContextFactory<ApplicationDbContext> dbFactory;
        private readonly DataTranslationService dataTranslationService;

        public MovieService(IDbContextFactory<ApplicationDbContext> DbFactory, DataTranslationService dataTranslationService)
        {
            this.dbFactory = DbFactory;
            this.dataTranslationService = dataTranslationService;
        }
        public async Task<List<Core.Movie.Dtos.Movie>> GetAllMovies()
        {
            var context = dbFactory.CreateDbContext();
            List<Dal.Models.Movie> listMovieDals = await context.Movie.ToListAsync();
            var result = dataTranslationService.MapData<Core.Movie.Dtos.Movie, Dal.Models.Movie>(listMovieDals).ToList();
            return result;
        }
    }
}
