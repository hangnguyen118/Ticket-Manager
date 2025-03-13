using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.Data.Repository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetCinemas()
        {
            var movies = await _unitOfWork.Movie.GetAllAsync();
            return Ok(movies);
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetCinema(string id)
        {
            var movie = await _unitOfWork.Movie.GetAsync(u => u.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // PUT: api/Cinemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinema(string id, Movie movie)
        {
            var cancellationToken = HttpContext.RequestAborted;

            Movie? cinemaFromDb = await _unitOfWork.Movie.GetAsync(u => u.Id == id);
            if (cinemaFromDb == null)
            {
                return NotFound(new { message = "Movie not found" });
            }
            cinemaFromDb.Title = movie.Title;
            cinemaFromDb.Description = movie.Description;
            cinemaFromDb.Genre = movie.Genre;
            cinemaFromDb.ReleaseDate = movie.ReleaseDate;
            cinemaFromDb.Rating = movie.Rating;
            cinemaFromDb.Duration = movie.Duration;

            _unitOfWork.Movie.Update(cinemaFromDb);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Ok(cinemaFromDb);
        }

        // POST: api/Cinemas
        [HttpPost]
        public async Task<ActionResult<Movie>> PostCinema(Movie movie)
        {
            var cancellationToken = HttpContext.RequestAborted;

            await _unitOfWork.Movie.AddAsync(movie);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetCinema), new { id = movie.Id }, movie);
        }

        // DELETE: api/Cinemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var movie = await _unitOfWork.Movie.GetAsync(u => u.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _unitOfWork.Movie.Remove(movie);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
