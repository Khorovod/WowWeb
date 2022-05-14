using System;
using System.Collections.Generic;
using WowWeb.Shared;
using System.Threading.Tasks;

namespace WowWeb.Client.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovie(int id);
        Task<List<Movie>> AddMovie(Movie movie);

    }
}
