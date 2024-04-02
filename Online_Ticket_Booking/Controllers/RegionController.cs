using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Services.Interfaces;
using System;

namespace Online_Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        [Authorize]
        [HttpGet]
        [Route("GetRegionDetails")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionService.GetAllRegionsAsync();
            Console.Out.WriteLine(regions);
            return Ok(regions);
        }
    }
}
