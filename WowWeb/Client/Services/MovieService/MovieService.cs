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

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public async Task<List<Movie>> AddMovie(Movie movie)
        {
            var mess = await _httpClient.PostAsJsonAsync("api/movie", movie);
            Movies = await mess.Content.ReadFromJsonAsync<List<Movie>>();
            return Movies;
        }

        public Task<Movie> GetMovie(int id)
        {
            return _httpClient.GetFromJsonAsync<Movie>($"api/movie/{id}");
        }

        public async Task<List<Movie>> GetMovies()
        {
            Movies = await _httpClient.GetFromJsonAsync<List<Movie>>("api/movie");
            return Movies;
        }
    }
}
