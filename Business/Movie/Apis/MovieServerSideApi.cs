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

        public Task AddMovie(Dto.Movie movie)
        {
            return movieService.AddMovie(movie);
        }

        public Task<List<Dto.Movie>> GetAllMovies()
        {
            return movieService.GetAllMovies();
        }

        public Task<Dto.Movie?> GetMovieById(int id)
        {
            return movieService.GetMovieById(id);
        }

        public Task UpdateMovie(Dto.Movie movie)
        {
            return movieService.UpdateMovie(movie);
        }
    }
}
