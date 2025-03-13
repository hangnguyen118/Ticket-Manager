using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // GET: api/ApplicationUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetApplicationUsers()
        {
            var applicationUsers = await _unitOfWork.ApplicationUser.GetAllAsync();
            return Ok(applicationUsers);
        }

        // GET: api/ApplicationUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetApplicationUser(string id)
        {
            var applicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return Ok(applicationUser);
        }

        // PUT: api/ApplicationUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationUser(string id, ApplicationUser applicationUser)
        {
            var cancellationToken = HttpContext.RequestAborted;

            ApplicationUser? applicationUserFromDb = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == id);
            if (applicationUserFromDb == null)
            {
                return NotFound(new { message = "ApplicationUser not found" });
            }
            applicationUserFromDb.FullName = applicationUser.FullName;           

            _unitOfWork.ApplicationUser.Update(applicationUserFromDb);
            await _unitOfWork.ApplicationUser.SaveChangesAsync(cancellationToken);

            return Ok(applicationUserFromDb);
        }

        // POST: api/ApplicationUsers
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> PostApplicationUser(ApplicationUser applicationUser)
        {
            var cancellationToken = HttpContext.RequestAborted;

            await _unitOfWork.ApplicationUser.AddAsync(applicationUser);
            await _unitOfWork.ApplicationUser.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetApplicationUser), new { id = applicationUser.Id }, applicationUser);
        }

        // DELETE: api/ApplicationUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationUser(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var applicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            _unitOfWork.ApplicationUser.Remove(applicationUser);
            await _unitOfWork.ApplicationUser.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
