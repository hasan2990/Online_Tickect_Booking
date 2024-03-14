using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IRoadService
    {
        Task<ResponseModel> ServiceRoadUser(RoadInfo use);

    }
}
