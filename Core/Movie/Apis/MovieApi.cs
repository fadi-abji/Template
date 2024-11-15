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
        public async Task<List<Dtos.Movie>> GetAllMovies()
        {
            return await _httpClient.GetFromJsonAsync<List<Dtos.Movie>>($"Data/Movie/GetAllMovies");
        }
    }
}
