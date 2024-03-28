using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IRegionService
    {
        Task<RegionResponse> GetAllRegionsAsync();
    }
}
