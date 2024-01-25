using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace QuickBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickBooksController : ControllerBase
    {
        private readonly QuickBooksService _service;

        public QuickBooksController(QuickBooksService service)
        {
            _service = service;
        }

        [HttpGet("test")]
        public IActionResult TestEndpoint()
        {
            return Ok("QuickBooks API service is running.");
        }

        [HttpPost("createbill")]
        public async Task<IActionResult> CreateBill([FromBody] BillData billData)
        {
            try
            {
                await _service.CreateBillAsync(billData);
                return Ok("Bill created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Add other endpoints as needed
    }
}
