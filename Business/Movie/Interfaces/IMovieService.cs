namespace Business.Movie.Interfaces
{
    public interface IMovieService
    {
        Task<List<Core.Movie.Dtos.Movie>> GetAllMovies();
        Task AddMovie(Core.Movie.Dtos.Movie movie);
        Task<Core.Movie.Dtos.Movie?> GetMovieById(int id);
        Task UpdateMovie(Core.Movie.Dtos.Movie movie);
    }
}