namespace Core.Movie.Interfaces
{
    public interface IMovieApi
    {
        Task<List<Dtos.Movie>> GetAllMovies();
        Task AddMovie(Dtos.Movie movie);
        Task<Dtos.Movie?> GetMovieById(int id);
        Task UpdateMovie(Dtos.Movie movie);
    }
}
