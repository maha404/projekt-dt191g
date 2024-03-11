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

        // GET: api/booking
        // Get all bookings
        [HttpGet]
        public async Task<IActionResult> GetBooking() 
        {
            if(_context.Bookings == null)
            {
                return NotFound();
            }

            return Ok(await _context.Bookings.ToListAsync());
        }

        // POST: api/booking
        // Book a treatment
        [HttpPost]
        public async Task<ActionResult<int>> PostBooking(BookingModel booking) 
        {
            DateTime selectedDateTime = new DateTime(
                booking.DateTime.Year,
                booking.DateTime.Month,
                booking.DateTime.Day,
                booking.DateTime.Hour,
                booking.DateTime.Minute, 0
            );

            booking.DateTime = selectedDateTime;
            booking.Status = true;

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return booking.Id;
        }


        // DELETE: api/booking
        // Cancel a booking
        [HttpDelete("{id}")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingModel bookingModel)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingModel.Id);

            if(booking == null )
            {
                return NotFound();
            }

            if(!string.IsNullOrEmpty(bookingModel.Name) && booking.Name != bookingModel.Name)
            {
                return BadRequest("Namnet matchar inte bokningen");
            }

            if(!string.IsNullOrEmpty(bookingModel.PhoneNumber) && booking.PhoneNumber != bookingModel.PhoneNumber)
            {
                return BadRequest("Telefonnumret matchar inte bokningen");
            }

            booking.Status = false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: api/booking
        // Get all treatments sorted by treatmentId 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingTimes(int id)
        {
            var bookings = await _context.Bookings
                           .Where(b => b.TreatmentId == id)
                           .ToListAsync();

            if(bookings == null || bookings.Count == 0)
            {
                return NotFound();
            }

            return Ok(bookings);

        }

    }
}
