using Business.Movie.Interfaces;
using Core.Movie.Interfaces;

namespace Business.Movie.Apis
{
    public class MovieServerSideApi : IMovieApi
    {
        private readonly IMovieService movieService;
        public MovieServerSideApi(IMovieService movieService)
        {
            this.movieService = movieService;
        }
        public Task<List<Core.Movie.Dtos.Movie>> GetAllMovies()
        {
            return movieService.GetAllMovies();
        }
    }
}
