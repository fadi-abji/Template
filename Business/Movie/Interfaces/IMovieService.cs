﻿namespace Business.Movie.Interfaces
{
    public interface IMovieService
    {
        Task<List<Dto.Movie>> GetAllMovies();
        Task AddMovie(Dto.Movie movie);
        Task<Dto.Movie?> GetMovieById(int id);
        Task UpdateMovie(Dto.Movie movie);
    }
}