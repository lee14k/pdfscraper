using Microsoft.AspNetCore.Mvc;
using YourProjectName.Services;

namespace YourProjectName.Controllers
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

    }
}
