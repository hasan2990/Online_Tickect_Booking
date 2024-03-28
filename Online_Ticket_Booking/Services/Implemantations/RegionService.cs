using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;
using System.Text.Json;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository, ILogService ilogService)
        {
            _regionRepository = regionRepository;
        }

        public async Task<RegionResponse> GetAllRegionsAsync()
        {
            RegionResponse response = new RegionResponse();
            List<Region> regions = await _regionRepository.GetAllRegionsAsync();

            if (regions.Count > 0)
            {
                response.isSuccess = true;
                response.statusMessage = "Data found";
                response.listregion = regions;
            }
            else
            {
                response.isSuccess = false;
                response.statusMessage = "Data not found";
            }
            return response;
        }
    }
}
