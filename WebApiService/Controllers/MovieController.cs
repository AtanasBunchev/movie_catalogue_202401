using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MC.Data.Entities;
using MC.ApplicationServices.Messaging;
using MC.ApplicationServices.Messaging.Responses;
using MC.ApplicationServices.Messaging.Requests;
using MC.ApplicationServices.Interfaces;

namespace MC.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesService _services;

        public MovieController(IMoviesService services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MC.ApplicationServices.Messaging.Responses.MovieModel>>> GetMovies()
        {
            return Ok(await _services.GetMoviesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MC.ApplicationServices.Messaging.Responses.MovieModel>> GetMovie(int id)
        {
            return Ok(await _services.GetByIdAsync(new (id)));
        }

        [HttpPost]
        public async Task<ActionResult<MC.ApplicationServices.Messaging.Responses.MovieModel>> PostMovie(MC.ApplicationServices.Messaging.Requests.MovieModel movie)
        {
            return Ok(await _services.CreateMovieAsync(new (movie)));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MC.ApplicationServices.Messaging.Responses.DeleteMovieResponse>> DeleteMovie(int id)
        {
            return Ok(await _services.DeleteMovieAsync(new (id)));
        }

        /// <summary>
        ///     Find movie with a given title
        /// </summary>
        /// <param name="title"> Movie title</param>
        /// <returns></returns>
        [HttpGet("search/{title}")]
        [ProducesResponseType(typeof(GetByTitleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByTitle([FromRoute] string title)
        {
            return Ok(await _services.GetByTitleAsync(new (title)));
        }

        /*
        // GET: api/Movie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
          if (_context.Movies == null)
          {
              return NotFound();
          }
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.ID)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
          if (_context.Movies == null)
          {
              return Problem("Entity set 'MovieDbContext.Movies'  is null.");
          }
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.ID }, movie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return (_context.Movies?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        */



    }
}
