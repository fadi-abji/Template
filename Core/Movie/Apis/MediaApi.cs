using Core.Movie.Interfaces;
using System.Net.Http.Json;

namespace Core.Movie.Apis
{
    public class MediaApi : IMediaApi
    {

        private readonly HttpClient _httpClient;

        public MediaApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Dto.Media> AddMedia()
        {
            return await _httpClient.GetFromJsonAsync<Dto.Media>($"Data/Media/AddMedia");
        }
    }
}
