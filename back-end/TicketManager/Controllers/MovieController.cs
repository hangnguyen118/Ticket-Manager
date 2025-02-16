using Microsoft.AspNetCore.Mvc;
using TicketManagerBE.Databases;

namespace TicketManagerBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieData _movieData;
        public MovieController() {
            _movieData = new();
        }
        [HttpGet]
        public async Task<IActionResult> GetMovies(CancellationToken token) {

            return Ok(await _movieData.GetAsyncMovies(token));
        }
    }
}
