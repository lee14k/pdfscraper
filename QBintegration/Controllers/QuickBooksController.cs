using Microsoft.AspNetCore.Mvc;
using YourProjectName.Services;
using YourProjectName.Models; // Assuming this is where your BillData model is located
using System.Threading.Tasks; // For asynchronous method

namespace QuickBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickBooksController : ControllerBase
    {
        private readonly IQuickBooksService _quickBooksService;

        public QuickBooksController(IQuickBooksService quickBooksService)
        {
            _quickBooksService = quickBooksService;
        }

        [HttpGet("connect")]
        public IActionResult ConnectToQuickBooks()
        {
            var authUrl = _quickBooksService.GetAuthorizationUrl();
            return Redirect(authUrl);
        }

        [HttpPost("test/createbill")] // Using POST because we're creating a resource
        public async Task<IActionResult> TestCreateBill()
        {
            // Create dummy bill data
            var dummyBillData = new BillData
            {
                VendorName = "Test Vendor",
                BillDate = System.DateTime.Now,
                LineItems = new System.Collections.Generic.List<LineItem>
                {
                    new LineItem { Description = "Test Item 1", Amount = 100.00m },
                    new LineItem { Description = "Test Item 2", Amount = 200.00m }
                }
            };

            try
            {
                // Assuming CreateBillAsync is a method in your QuickBooksService
                // that handles the logic for creating a bill in QuickBooks
                await _quickBooksService.CreateBillAsync(dummyBillData);
                return Ok("Bill created successfully with test data.");
            }
            catch (System.Exception ex)
            {
                // Handle any exceptions (like issues with QuickBooks API)
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        // Other controller methods...
    }
}
