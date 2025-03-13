using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.Data.Repository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            var images = await _unitOfWork.Image.GetAllAsync();
            return Ok(images);
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(string id)
        {
            var image = await _unitOfWork.Image.GetAsync(u => u.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        // PUT: api/Images/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImage(string id, Image image)
        {
            var cancellationToken = HttpContext.RequestAborted;

            Image? imageFromDb = await _unitOfWork.Image.GetAsync(u => u.Id == id);
            if (imageFromDb == null)
            {
                return NotFound(new { message = "Image not found" });
            }
            imageFromDb.ImageUrl = image.ImageUrl;
            imageFromDb.MovieId = image.MovieId;
            imageFromDb.ApplicationUserId = image.ApplicationUserId;
            imageFromDb.ImageType = image.ImageType;

            _unitOfWork.Image.Update(imageFromDb);
            await _unitOfWork.Image.SaveChangesAsync(cancellationToken);

            return Ok(imageFromDb);
        }

        // POST: api/Images
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            var cancellationToken = HttpContext.RequestAborted;

            await _unitOfWork.Image.AddAsync(image);
            await _unitOfWork.Image.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetImage), new { id = image.Id }, image);
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
            await _unitOfWork.Image.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
