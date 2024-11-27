using Business.DataBase;
using Business.Movie.Interfaces;
using Dto;
using Microsoft.EntityFrameworkCore;
using DalObj = Dal.Movie;
using DtoObj = Dto.Movie;
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

        public async Task AddMovie(DtoObj movie)
        {
            using var context = dbFactory.CreateDbContext();
            await using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                // Convert DTO to DAL
                var movieDal = dataTranslationService.ReverseMapData<DalObj, DtoObj>(movie);

                // Add the Movie entity
                context.Movie.Add(movieDal);

                // Save changes to include Movie ID for related entities
                await context.SaveChangesAsync();

                // Commit the transaction
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<List<DtoObj>> GetAllMovies()
        {
            try
            {
                var context = dbFactory.CreateDbContext();
                List<DalObj> listMovieDals = await context.Movie.ToListAsync();
                var result = dataTranslationService.MapData<DtoObj, DalObj>(listMovieDals).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DtoObj?> GetMovieById(int id)
        {
            try
            {
                var context = dbFactory.CreateDbContext();
                var movieDal = context.Movie.FirstOrDefault(x => x.Id == id);
                return movieDal == null ? null : dataTranslationService.MapData<DtoObj, DalObj>(movieDal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateMovie(DtoObj movie)
        {
            using var context = dbFactory.CreateDbContext();
            //convert to Dal
            var movieDal = dataTranslationService.ReverseMapData<DalObj, DtoObj>(movie);
            context.Attach(movieDal!).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie!.Id))
                {
                    throw new DbUpdateConcurrencyException("Movie not found");
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private bool MovieExists(int id)
        {
            using var context = dbFactory.CreateDbContext();
            return context.Movie.Any(e => e.Id == id);
        }

        #region MovieMedia
        private async Task AddMovieMediaToMovie(MovieMedia media)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
