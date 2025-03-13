using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.Data.Repository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // GET: api/Seats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
        {
            var seats = await _unitOfWork.Seat.GetAllAsync();
            return Ok(seats);
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(string id)
        {
            var seat = await _unitOfWork.Seat.GetAsync(u => u.Id == id);
            if (seat == null)
            {
                return NotFound();
            }
            return Ok(seat);
        }

        // PUT: api/Seats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat(string id, Seat seat)
        {
            var cancellationToken = HttpContext.RequestAborted;

            Seat? seatFromDb = await _unitOfWork.Seat.GetAsync(u => u.Id == id);
            if (seatFromDb == null)
            {
                return NotFound(new { message = "Seat not found" });
            }
            seatFromDb.Row = seat.Row;
            seatFromDb.Column = seat.Column;
            seatFromDb.ScreenId = seat.ScreenId;
            seatFromDb.Aisle = seat.Aisle;
            seatFromDb.SeatType = seat.SeatType;
            seatFromDb.Price = seat.Price;
            _unitOfWork.Seat.Update(seatFromDb);
            await _unitOfWork.Seat.SaveChangesAsync(cancellationToken);

            return Ok(seatFromDb);
        }

        // POST: api/Seats
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(Seat seat)
        {
            var cancellationToken = HttpContext.RequestAborted;

            await _unitOfWork.Seat.AddAsync(seat);
            await _unitOfWork.Seat.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetSeat), new { id = seat.Id }, seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var seat = await _unitOfWork.Seat.GetAsync(u => u.Id == id);
            if (seat == null)
            {
                return NotFound();
            }
            _unitOfWork.Seat.Remove(seat);
            await _unitOfWork.Seat.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
