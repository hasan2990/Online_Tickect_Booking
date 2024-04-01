using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IRoadRepo
    {
        Task<int> RoadUser(RoadInfo use);
    }
}
