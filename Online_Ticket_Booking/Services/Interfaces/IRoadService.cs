using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IRoadService
    {
        Task<string> ServiceRoadUser(RoadInfo use);
    }
}
