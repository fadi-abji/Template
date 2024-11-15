namespace Business.Movie.Interfaces
{
    public interface IMovieService
    {
        Task<List<Core.Movie.Dtos.Movie>> GetAllMovies();
    }
}