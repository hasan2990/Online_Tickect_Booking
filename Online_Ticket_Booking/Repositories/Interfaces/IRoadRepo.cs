using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IRoadRepo
    {
        Task<string> RoadUser(Road use);
    }
}
