using System;
using System.Collections.Generic;
using WowWeb.Shared;
using System.Threading.Tasks;

namespace WowWeb.Client.Services
{
    public interface IMovieService
    {
        List<Movie> Movies { get; set; }

        event Action OnMoviesChange;

        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovie(int id);
        Task<List<Movie>> AddMovie(Movie movie);
        Task<Movie> UpdateMovie(Movie movie);
        Task<List<Movie>> DeleteMovie(int id);
    }
}
