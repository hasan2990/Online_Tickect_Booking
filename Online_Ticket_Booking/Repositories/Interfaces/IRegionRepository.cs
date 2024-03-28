using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegionsAsync();
    }
}
