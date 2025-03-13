using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController(IBaseRepository<Cinema> cinemaRepository) : ControllerBase
    {
        private readonly IBaseRepository<Cinema> _cinemaRepository = cinemaRepository;

        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cinema>>> GetCinemas()
        {
            var cinemas = await _cinemaRepository.GetAllAsync();
            return Ok(cinemas);
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> GetCinema(string id)
        {
            var cinema = await _cinemaRepository.GetAsync(u=>u.Id == id);
            if (cinema == null)
            {   
                return NotFound();
            }
            return Ok(cinema);
        }

        // PUT: api/Cinemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinema(string id, Cinema cinema)
        {
            var cancellationToken = HttpContext.RequestAborted;

            Cinema? cinemaFromDb = await _cinemaRepository.GetAsync(u => u.Id == id);
            if (cinemaFromDb == null)
            {
                return NotFound(new { message = "Cinema not found" });
            }           
                cinemaFromDb.Name = cinema.Name;
                cinemaFromDb.City = cinema.City;
                cinemaFromDb.State = cinema.State;
                cinemaFromDb.StreetAddress = cinema.StreetAddress;

                _cinemaRepository.Update(cinemaFromDb);
                await _cinemaRepository.SaveChangesAsync(cancellationToken);

                return Ok(cinemaFromDb); 
        }

        // POST: api/Cinemas
        [HttpPost]
        public async Task<ActionResult<Cinema>> PostCinema(Cinema cinema)
        {
            var cancellationToken = HttpContext.RequestAborted;

            await _cinemaRepository.AddAsync(cinema);          
            await _cinemaRepository.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetCinema), new { id = cinema.Id }, cinema);
        }

        // DELETE: api/Cinemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var cinema = await _cinemaRepository.GetAsync(u=>u.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _cinemaRepository.Remove(cinema);
            await _cinemaRepository.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
