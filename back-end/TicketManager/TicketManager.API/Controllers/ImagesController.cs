using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using AutoMapper;
using TicketManager.API.EntityModels.Dto.Image;
using Image = TicketManager.API.EntityModels.Image;
using TicketManager.API.Utility;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetImageDto>>> GetImages()
        {
            var images = await _unitOfWork.Image.GetAllAsync();
            var records = _mapper.Map<List<GetImageDto>>(images);
            return Ok(records);
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetImageDto>> GetImage(string id)
        {
            var image = await _unitOfWork.Image.GetAsync(u => u.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            var imageDto = _mapper.Map<GetImageDto>(image);
            return Ok(imageDto);
        }

        // PUT: api/Images/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(string id, UpdateImageDto imageDto)
        {
            var cancellationToken = HttpContext.RequestAborted;

            Image? imageFromDb = await _unitOfWork.Image.GetAsync(u => u.Id == id);
            if (imageFromDb == null)
            {
                return NotFound(new { message = "Image not found" });
            }
            _mapper.Map(imageDto, imageFromDb);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return NoContent();
        }

        // POST: api/Images
        [HttpPost]
        public async Task<ActionResult<GetImageDto>> PostImage(CreateImageDto createImageDto)
        {
            var cancellationToken = HttpContext.RequestAborted;
            if (string.IsNullOrEmpty(createImageDto.MovieId) && string.IsNullOrEmpty(createImageDto.ApplicationUserId))
            {
                return BadRequest("Either ApplicationUserId or MovieId must be provided.");
            }
            else if(createImageDto.ImageType == SD.Image_Movie)
            {
                var movie = await _unitOfWork.Movie.GetAsync(u => u.Id == createImageDto.MovieId);
                if (movie == null)
                {
                    return NotFound("Movie Not Found");
                }
            }
            else if (createImageDto.ImageType == SD.Image_User)
            {
                var applicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == createImageDto.ApplicationUserId);
                if (applicationUser == null)
                {
                    return NotFound("User Not Found");
                }
            }            
            var image = _mapper.Map<Image>(createImageDto);
            await _unitOfWork.Image.AddAsync(image);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var imageDto = _mapper.Map<GetImageDto>(image);
            return CreatedAtAction(nameof(GetImage), new { id = image.Id }, imageDto);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var image = await _unitOfWork.Image.GetAsync(u => u.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            _unitOfWork.Image.Remove(image);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
