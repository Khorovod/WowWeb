using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WowWeb.Shared;

namespace WowWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        static List<Movie> _dummyMoviesFromDb = new List<Movie>()
        {
            new Movie{Id = 1, Title = "Drive", Description = "Best movie ever, Gosling didnt dies at the end...", Rating = 10, Genre = new Genre{Name = "Deep"}},
            new Movie{Id = 2, Title = "In Bruges", Description = "Movie about a midgets!", Rating = 9, Genre = new Genre{Name = "Drama"}},
            new Movie{Id = 3, Title = "The Grand Budapest Hotel", Description = "Wes Anderson + Ralph Fiennes as Monsieur Gustave H.", Rating = 10, Genre = new Genre{Name = "Comedy"}}

        };
        List<Genre> _genresFromDb = new List<Genre>()
        {
            new Genre{Id = 0, Name = "Hmmmm"},
            new Genre{Id = 1, Name = "Action"},
            new Genre{Id = 2, Name = "Deep"},
            new Genre{Id = 3, Name = "Drama"},
            new Genre{Id = 4, Name = "Comedy"},
            new Genre{Id = 5, Name = "Horror"}
        };

        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(_genresFromDb);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(_dummyMoviesFromDb);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = _dummyMoviesFromDb.SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound("Movie not found");
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            movie.Id = _dummyMoviesFromDb.Max(i => i.Id + 1);
            _dummyMoviesFromDb.Add(movie);
            return Ok(_dummyMoviesFromDb);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(Movie movie, int id)
        {
            var movieToUpd = _dummyMoviesFromDb.SingleOrDefault(m => m.Id == id);
            if (movieToUpd == null)
            {
                return NotFound("Movie not found");
            }
            var index =_dummyMoviesFromDb.IndexOf(movieToUpd);

            _dummyMoviesFromDb[index] = movie;
            return Created("", movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movieToDelete = _dummyMoviesFromDb.SingleOrDefault(m => m.Id == id);
            if (movieToDelete == null)
            {
                return NotFound("Movie not found");
            }
            _dummyMoviesFromDb.Remove(movieToDelete);
            return Ok(_dummyMoviesFromDb);
        }
    }
}
