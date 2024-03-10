using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings(Booking book)
        {
            var result = await _bookingService.GetBookingsAsync(book);

            if (result.isSuccess)
            {
                return Ok(result.bookingList);
            }
            else
            {
                return StatusCode(500, result.statusMessage);
            }
        }
    }
}
