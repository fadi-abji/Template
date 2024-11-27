using Core.Movie.Interfaces;
using System.Net.Http.Json;

namespace Core.Movie.Apis
{
    public class MovieApi : IMovieApi
    {

        private readonly HttpClient _httpClient;

        public MovieApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddMovie(Dto.Movie movie)
        {
            await _httpClient.PostAsJsonAsync<Dto.Movie>($"Data/Movie/AddMovie", movie);
        }

        public async Task<List<Dto.Movie>> GetAllMovies()
        {
            return await _httpClient.GetFromJsonAsync<List<Dto.Movie>>($"Data/Movie/GetAllMovies");
        }

        public async Task<Dto.Movie> GetMovieById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Dto.Movie>($"Data/Movie/GetMovieById{id}");
        }

        public async Task UpdateMovie(Dto.Movie movie)
        {
            await _httpClient.PutAsJsonAsync<Dto.Movie>($"Data/Movie/UpdateMovie", movie);
        }
    }
}
