using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;
using TicketManager.API.EntityModels.Dto.Cinema;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        // GET: api/Cinemas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCinemaDto>>> GetCinemas()
        {
            var cinemas = await _unitOfWork.Cinema.GetAllAsync();
            var records = _mapper.Map<List<GetCinemaDto>>(cinemas);
            return Ok(records);
        }

        // GET: api/Cinemas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCinemaDto>> GetCinema(string id)
        {
            var cinema = await _unitOfWork.Cinema.GetAsync(u => u.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<GetCinemaDto>(cinema);
            return Ok(record);
        }

        // PUT: api/Cinemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCinema(string id, UpdateCinemaDto updateCinemaDto)
        {
            var cancellationToken = HttpContext.RequestAborted;

            Cinema? cinemaFromDb = await _unitOfWork.Cinema.GetAsync(u => u.Id == id);
            if (cinemaFromDb == null)
            {
                return NotFound(new { message = "Cinema not found" });
            }

            _mapper.Map(updateCinemaDto, cinemaFromDb);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        // POST: api/Cinemas
        [HttpPost]
        public async Task<ActionResult<Cinema>> PostCinema(CreateCinemaDto createCinemaDto)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var cinema = _mapper.Map<Cinema>(createCinemaDto);
            await _unitOfWork.Cinema.AddAsync(cinema);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var cinemaDto = _mapper.Map<GetCinemaDto>(cinema);
            return CreatedAtAction(nameof(GetCinema), new { id = cinema.Id }, cinemaDto);
        }

        // DELETE: api/Cinemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCinema(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var cinema = await _unitOfWork.Cinema.GetAsync(u => u.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _unitOfWork.Cinema.Remove(cinema);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
