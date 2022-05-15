using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WowWeb.Shared;

namespace WowWeb.Client.Services
{
    public class GenreService : IGenreService
    {
        private readonly HttpClient _httpClient;

        public GenreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public async Task GetGenres()
        {
            Genres = await _httpClient.GetFromJsonAsync<List<Genre>>("api/movie/genres");
        }
    }
}