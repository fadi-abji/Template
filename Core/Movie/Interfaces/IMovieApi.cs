namespace Core.Movie.Interfaces
{
    public interface IMovieApi
    {
        Task<List<Dtos.Movie>> GetAllMovies();
    }
}
