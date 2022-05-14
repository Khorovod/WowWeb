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
        List<Movie> _dummyMovies = new List<Movie>()
        {
            new Movie{Id = 1, Title = "Drive", Description = "Best movie ever, Gosling didnt dies at the end...", Rating = 10, Genre = new Genre{Name = Genres.Think}},
            new Movie{Id = 2, Title = "In Bruges", Description = "Ralph Fiennes is enraged...", Rating = 10, Genre = new Genre{Name = Genres.Drama}},
            new Movie{Id = 3, Title = "The Grand Budapest Hotel", Description = "Wes Anderson + Ralph Fiennes as Monsieur Gustave H.", Rating = 10, Genre = new Genre{Name = Genres.Comedy}}

        };
        List<Genre> _genres = new List<Genre>()
        {
            new Genre(Name )
        };

        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            return Ok(_genres);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(_dummyMovies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = _dummyMovies.SingleOrDefault(m => m.Id == id);
            if(movie != null)
            {
                return Ok(movie);
            }
            return NotFound("Movie not found");
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            _dummyMovies.Add(movie);
            return Ok(_dummyMovies);
        }
    }
}
