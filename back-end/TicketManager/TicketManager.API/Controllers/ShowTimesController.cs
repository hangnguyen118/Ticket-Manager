using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.Data.Repository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // GET: api/ShowTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowTime>>> GetShowTimes()
        {
            var showTimes = await _unitOfWork.ShowTime.GetAllAsync();
            return Ok(showTimes);
        }

        // GET: api/ShowTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShowTime>> GetshowTimes(string id)
        {
            var showTimes = await _unitOfWork.ShowTime.GetAsync(u => u.Id == id, includeProperties: "Movie, Screen");
            if (showTimes == null)
            {
                return NotFound();
            }
            return Ok(showTimes);
        }

        // PUT: api/ShowTimes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutshowTimes(string id, ShowTime showTimes)
        {
            var cancellationToken = HttpContext.RequestAborted;

            ShowTime? showTimesFromDb = await _unitOfWork.ShowTime.GetAsync(u => u.Id == id);
            if (showTimesFromDb == null)
            {
                return NotFound(new { message = "Showtimes not found" });
            }
            Screen? screenFromDb = await _unitOfWork.Screen.GetAsync(u => u.Id == showTimes.ScreenId);
            if(screenFromDb == null)
            {
                return NotFound(new { message = $"Screen id={showTimes.ScreenId} not found" });
            }
            Movie? movieFromDb = await _unitOfWork.Movie.GetAsync(u => u.Id == showTimes.MovieId);
            if (movieFromDb == null)
            {
                return NotFound(new { message = $"Movie id={showTimes.MovieId} not found" });
            }

            showTimesFromDb.StartTime = showTimes.StartTime;
            showTimesFromDb.EndTime = showTimes.EndTime;
            showTimesFromDb.MovieId = showTimes.MovieId;
            showTimesFromDb.ScreenId = showTimes.ScreenId;

            _unitOfWork.ShowTime.Update(showTimesFromDb);
            await _unitOfWork.ShowTime.SaveChangesAsync(cancellationToken);

            return Ok(showTimesFromDb);
        }

        // POST: api/ShowTimes
        [HttpPost]
        public async Task<ActionResult<ShowTime>> PostshowTimes(ShowTime showTimes)
        {
            var cancellationToken = HttpContext.RequestAborted;

            Screen? screenFromDb = await _unitOfWork.Screen.GetAsync(u => u.Id == showTimes.ScreenId);
            if (screenFromDb == null)
            {
                return NotFound(new { message = $"Screen id={showTimes.ScreenId} not found" });
            }
            Movie? movieFromDb = await _unitOfWork.Movie.GetAsync(u => u.Id == showTimes.MovieId);
            if (movieFromDb == null)
            {
                return NotFound(new { message = $"Movie id={showTimes.MovieId} not found" });
            }
            await _unitOfWork.ShowTime.AddAsync(showTimes);
            await _unitOfWork.ShowTime.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetshowTimes), new { id = showTimes.Id }, showTimes);
        }

        // DELETE: api/ShowTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteshowTimes(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var showTimes = await _unitOfWork.ShowTime.GetAsync(u => u.Id == id);
            if (showTimes == null)
            {
                return NotFound();
            }
            _unitOfWork.ShowTime.Remove(showTimes);
            await _unitOfWork.ShowTime.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
