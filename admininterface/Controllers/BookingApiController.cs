using admininterface.Data;
using admininterface.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    [Route("api/booking")]
    [ApiController]
    public class BookingApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/bookings
        // Hämta alla bokningar
        [HttpGet]
        public async Task<IActionResult> GetBooking() 
        {
            if(_context.Bookings == null)
            {
                return NotFound();
            }

            return Ok(await _context.Bookings.ToListAsync());
        }

    }
}
