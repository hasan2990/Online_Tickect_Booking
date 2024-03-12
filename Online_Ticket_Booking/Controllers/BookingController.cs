using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Services.Interfaces;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetBookings([FromQuery] BookingQueryParameters queryParameters)
        {
            try
            {
                var result = await _bookingService.GetBookingsAsync(queryParameters);

                if (result.isSuccess)
                {
                    return Ok(result.bookingList);
                }
                else
                {
                    return StatusCode(500, result.statusMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        /*[HttpPost]
        public async Task<IActionResult> BookSeat([FromBody] Booking booking)
        {
            try
            {
                var isBooked = await _bookingService.BookSeatAsync(booking);

                if (isBooked)
                {
                    return Ok("Seat booked successfully.");
                }
                else
                {
                    return StatusCode(400, "Failed to book seat. Seat might already be booked.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }*/
    }
}
