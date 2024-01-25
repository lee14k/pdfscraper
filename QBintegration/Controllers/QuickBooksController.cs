[Route("api/[controller]")]
[ApiController]
public class QuickBooksController : ControllerBase
{
    private readonly QuickBooksService _service;

    public QuickBooksController(QuickBooksService service)
    {
        _service = service;
    }

    // Define your API endpoints here
}
