using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;
using TicketManager.API.EntityModels.Dto.ApplicationUser;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        // GET: api/ApplicationUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetApplicationUserDto>>> GetApplicationUsers()
        {
            var applicationUsers = await _unitOfWork.ApplicationUser.GetAllAsync();
            var records = _mapper.Map<List<GetApplicationUserDto>>(applicationUsers);
            return Ok(records);
        }

        // GET: api/ApplicationUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetApplicationUserDto>> GetApplicationUser(string id)
        {
            var applicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            var record = _mapper.Map<GetApplicationUserDto>(applicationUser);
            return Ok(record);
        }

        // PUT: api/ApplicationUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicationUser(string id, UpdateApplicationUserDto updateApplicationUserDto)
        {
            var cancellationToken = HttpContext.RequestAborted;
           
            ApplicationUser? applicationUserFromDb = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == id);
            if (applicationUserFromDb == null)
            {
                return NotFound(new { message = "ApplicationUser not found" });
            }            
            _mapper.Map(updateApplicationUserDto, applicationUserFromDb);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
           
            return NoContent();
        }

        // POST: api/ApplicationUsers
        [HttpPost]
        public async Task<ActionResult<GetApplicationUserDto>> PostApplicationUser(CreateApplicationUserDto createApplicationUserDto)
        {
            var cancellationToken = HttpContext.RequestAborted;
            var applicationUser = _mapper.Map<ApplicationUser>(createApplicationUserDto);

            await _unitOfWork.ApplicationUser.AddAsync(applicationUser);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var userDto = _mapper.Map<GetApplicationUserDto>(applicationUser);
            return CreatedAtAction(nameof(GetApplicationUser), new { id = applicationUser.Id }, userDto);
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
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
