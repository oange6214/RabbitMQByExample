
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    private readonly ILogger<BookingController> _logger;

    public BookingController(ILogger<BookingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBooking")]
    public IEnumerable<BookingController> Get()
    {
        
    }
}
