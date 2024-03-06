using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        [HttpPost]
        [Route("BusDetails")]

        public async Task<IActionResult> BusDetails(BusInfo use)
        {
            var businfo = await _busService.ServiceBusUser(use);
            return Ok(businfo);
        }
    }
}
