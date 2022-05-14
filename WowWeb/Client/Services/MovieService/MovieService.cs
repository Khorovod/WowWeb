using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WowWeb.Shared;

namespace WowWeb.Client.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<Movie>> AddMovie(Movie movie)
        {
            var mess = _httpClient.PostAsJsonAsync("api/movie", movie);
            return mess.Result.Content.ReadFromJsonAsync<List<Movie>>();
        }

        public Task<Movie> GetMovie(int id)
        {
            return _httpClient.GetFromJsonAsync<Movie>($"api/movie/{id}");
        }

        public Task<List<Movie>> GetMovies()
        {
            return _httpClient.GetFromJsonAsync<List<Movie>>("api/movie");
        }
    }
}
