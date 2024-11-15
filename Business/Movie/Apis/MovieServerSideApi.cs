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

        public Task AddMovie(Core.Movie.Dtos.Movie movie)
        {
            return movieService.AddMovie(movie);
        }

        public Task<List<Core.Movie.Dtos.Movie>> GetAllMovies()
        {
            return movieService.GetAllMovies();
        }

        public Task<Core.Movie.Dtos.Movie?> GetMovieById(int id)
        {
            return movieService.GetMovieById(id);
        }

        public Task UpdateMovie(Core.Movie.Dtos.Movie movie)
        {
            return movieService.UpdateMovie(movie);
        }
    }
}
