using Azure;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IBusService
    {
        Task<ResponseModel> ServiceBusUser(BusInfo use);
    }
}
