using Business.DataBase;
using Business.Movie.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Business.Movie.Services
{
    public class MovieService : IMovieService
    {
        private readonly IDbContextFactory<MainDbContext> dbFactory;
        private readonly DataTranslationService dataTranslationService;

        public MovieService(IDbContextFactory<MainDbContext> DbFactory, DataTranslationService dataTranslationService)
        {
            this.dbFactory = DbFactory;
            this.dataTranslationService = dataTranslationService;
        }

        public async Task AddMovie(Core.Movie.Dtos.Movie movie)
        {
            try
            {
                using var context = dbFactory.CreateDbContext();
                //convert to Dal
                var movieDal = dataTranslationService.ReverseMapData<Dal.Models.Movie, Core.Movie.Dtos.Movie>(movie);
                context.Movie.Add(movieDal);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Core.Movie.Dtos.Movie>> GetAllMovies()
        {
            try
            {
                var context = dbFactory.CreateDbContext();
                List<Dal.Models.Movie> listMovieDals = await context.Movie.ToListAsync();
                var result = dataTranslationService.MapData<Core.Movie.Dtos.Movie, Dal.Models.Movie>(listMovieDals).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
