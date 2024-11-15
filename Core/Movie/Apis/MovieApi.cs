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

        public async Task AddMovie(Dtos.Movie movie)
        {
            await _httpClient.PostAsJsonAsync<Dtos.Movie>($"Data/Movie/AddMovie", movie);
        }

        public async Task<List<Dtos.Movie>> GetAllMovies()
        {
            return await _httpClient.GetFromJsonAsync<List<Dtos.Movie>>($"Data/Movie/GetAllMovies");
        }

        public async Task<Dtos.Movie> GetMovieById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Dtos.Movie>($"Data/Movie/GetMovieById{id}");
        }

        public async Task UpdateMovie(Dtos.Movie movie)
        {
            await _httpClient.PutAsJsonAsync<Dtos.Movie>($"Data/Movie/UpdateMovie", movie);
        }
    }
}
