using Microsoft.AspNetCore.Mvc;
using TicketManager.API.Data.Repository.IRepository;
using TicketManager.API.EntityModels;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        // GET: api/PaymentMethod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetpaymentMethod()
        {
            var paymentMethod = await _unitOfWork.PaymentMethod.GetAllAsync();
            return Ok(paymentMethod);
        }

        // GET: api/PaymentMethod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> GetpaymentMethod(string id)
        {
            var paymentMethod = await _unitOfWork.PaymentMethod.GetAsync(u => u.Id == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return Ok(paymentMethod);
        }

        // PUT: api/PaymentMethod/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutpaymentMethod(string id, PaymentMethod paymentMethod)
        {
            var cancellationToken = HttpContext.RequestAborted;

            PaymentMethod? paymentMethodFromDb = await _unitOfWork.PaymentMethod.GetAsync(u => u.Id == id);
            if (paymentMethodFromDb == null)
            {
                return NotFound(new { message = "Payment method not found" });
            }
            paymentMethodFromDb.Name = paymentMethod.Name;
          
            _unitOfWork.PaymentMethod.Update(paymentMethodFromDb);
            await _unitOfWork.PaymentMethod.SaveChangesAsync(cancellationToken);

            return Ok(paymentMethodFromDb);
        }

        // POST: api/PaymentMethod
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> PostpaymentMethod(PaymentMethod paymentMethod)
        {
            var cancellationToken = HttpContext.RequestAborted;

            await _unitOfWork.PaymentMethod.AddAsync(paymentMethod);
            await _unitOfWork.PaymentMethod.SaveChangesAsync(cancellationToken);
            return CreatedAtAction(nameof(GetpaymentMethod), new { id = paymentMethod.Id }, paymentMethod);
        }

        // DELETE: api/PaymentMethod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletepaymentMethod(string id)
        {
            var cancellationToken = HttpContext.RequestAborted;

            var paymentMethod = await _unitOfWork.PaymentMethod.GetAsync(u => u.Id == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            _unitOfWork.PaymentMethod.Remove(paymentMethod);
            await _unitOfWork.PaymentMethod.SaveChangesAsync(cancellationToken);
            return NoContent();
        }
    }
}
