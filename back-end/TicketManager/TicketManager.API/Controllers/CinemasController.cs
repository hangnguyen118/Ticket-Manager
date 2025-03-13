using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cinema>>> GetCinemas()
        {
            var cinemas = await _unitOfWork.Cinema.GetAllAsync();
            return Ok(cinemas);
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> GetCinema(string id)
        {
            var cinema = await _unitOfWork.Cinema.GetAsync(u=>u.Id == id);
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

            Cinema? cinemaFromDb = await _unitOfWork.Cinema.GetAsync(u => u.Id == id);
            if (cinemaFromDb == null)
            {
                return NotFound(new { message = "Cinema not found" });
            }           
                cinemaFromDb.Name = cinema.Name;
                cinemaFromDb.City = cinema.City;
                cinemaFromDb.State = cinema.State;
                cinemaFromDb.StreetAddress = cinema.StreetAddress;

               _unitOfWork.Cinema.Update(cinemaFromDb);
                await _unitOfWork.Cinema.SaveChangesAsync(cancellationToken);

                return Ok(cinemaFromDb); 
        }

        // POST: api/Cinemas
        [HttpPost]
        public async Task<ActionResult<Cinema>> PostCinema(Cinema cinema)
        {
            var cancellationToken = HttpContext.RequestAborted;

            await _unitOfWork.Cinema.AddAsync(cinema);          
            await _unitOfWork.Cinema.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetCinema), new { id = cinema.Id }, cinema);
        }

        // DELETE: api/Cinemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var cinema = await _unitOfWork.Cinema.GetAsync(u=>u.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
           _unitOfWork.Cinema.Remove(cinema);
            await _unitOfWork.Cinema.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
