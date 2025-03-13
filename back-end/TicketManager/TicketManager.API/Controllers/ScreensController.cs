using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreensController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // GET: api/Screens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Screen>>> GetScreens()
        {
            var Screens = await _unitOfWork.Screen.GetAllAsync();
            return Ok(Screens);
        }

        // GET: api/Screens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Screen>> GetScreen(string id)
        {
            var Screen = await _unitOfWork.Screen.GetAsync(u => u.Id == id, includeProperties: "Cinema");
            if (Screen == null)
            {
                return NotFound();
            }
            return Ok(Screen);
        }

        // PUT: api/Screens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScreen(string id, Screen screen)
        {
            var cancellationToken = HttpContext.RequestAborted;

            Screen? screenFromDb = await _unitOfWork.Screen.GetAsync(u => u.Id == id, includeProperties: "Cinema");
            //Cinema? cinema = await unitWorkRepository.GetA
            if (screenFromDb == null)
            {
                return NotFound(new { message = "Screen not found" });
            }
            screenFromDb.ScreenNumber = screen.ScreenNumber;
            screenFromDb.Capacity = screen.Capacity;
            screenFromDb.CinemaId = screen.CinemaId;

            _unitOfWork.Screen.Update(screenFromDb);
            await _unitOfWork.Screen.SaveChangesAsync(cancellationToken);

            return Ok(screenFromDb);
        }

        // POST: api/Screens
        [HttpPost]
        public async Task<ActionResult<Screen>> PostScreen(Screen screen)
        {
            var cancellationToken = HttpContext.RequestAborted;

            await _unitOfWork.Screen.AddAsync(screen);
            await _unitOfWork.Screen.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetScreen), new { id = screen.Id }, screen);
        }

        // DELETE: api/Screens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreen(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var screen = await _unitOfWork.Screen.GetAsync(u => u.Id == id);
            if (screen == null)
            {
                return NotFound();
            }
            _unitOfWork.Screen.Remove(screen);
            await _unitOfWork.Screen.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
