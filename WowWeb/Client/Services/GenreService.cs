using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<Genres>> GetGenres()
        {
            return _httpClient.GetFromJsonAsync<List<Genres>>("api/genres");
        }
    }
}
